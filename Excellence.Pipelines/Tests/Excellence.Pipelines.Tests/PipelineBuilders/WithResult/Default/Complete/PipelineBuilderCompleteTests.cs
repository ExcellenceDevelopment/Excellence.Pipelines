using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Default;

public class PipelineBuilderCompleteTests : PipelineBuilderCompleteTestsBase
{
    #region Shared

    protected static Func<PipelineArg, PipelineArg> TargetBranchResult =>
        (param) =>
        {
            param.Value *= 2;

            return param;
        };

    protected static PipelineArg TargetBranch(PipelineArg param) =>
        TargetBranchResult.Invoke(param);

    #region Steps

    protected class SquareStep : IPipelineStep<PipelineArg, PipelineArg>
    {
        public virtual PipelineArg Invoke(PipelineArg param, Func<PipelineArg, PipelineArg> next)
        {
            var nextResult = next.Invoke(param);

            nextResult.Value *= nextResult.Value;

            return nextResult;
        }
    }

    #endregion

    #region Conditions

    protected class PipelineConditionParamGreaterThanZero : IPipelineCondition<PipelineArg>
    {
        public bool Invoke(PipelineArg param) => param.Value > 0;
    }

    protected class PipelineConditionParamLessThanZero : IPipelineCondition<PipelineArg>
    {
        public bool Invoke(PipelineArg param) => param.Value < 0;
    }

    protected class PipelineConditionTrue : IPipelineCondition<PipelineArg>
    {
        public bool Invoke(PipelineArg param) => true;
    }

    protected class PipelineConditionFalse : IPipelineCondition<PipelineArg>
    {
        public bool Invoke(PipelineArg param) => false;
    }

    #endregion

    #endregion

    #region Multiple steps

    public static TheoryData<int, int> MultipleTestData => new TheoryData<int, int>()
    {
        { 5, -196306143 },
        { -5, 4096 }
    };

    [Theory]
    [MemberData(nameof(MultipleTestData))]
    public void Multiple_AddsComponentsToPipeline(int argValue, int expectedResult)
    {
        var arg = new PipelineArg(argValue);

        var serviceProvider = new ServiceCollection()
            .AddTransient<PipelineConditionParamGreaterThanZero>()
            .AddTransient<PipelineConditionParamLessThanZero>()
            .AddTransient<PipelineConditionTrue>()
            .AddTransient<PipelineConditionFalse>()
            .AddTransient<SquareStep>()
            .BuildServiceProvider();

        var sut = CreateSut(serviceProvider)
            .Use
            (
                next => (param) =>
                {
                    param.Value += 1;

                    return next.Invoke(param);
                }
            )
            .UseWhen
            (
                () => new PipelineConditionParamGreaterThanZero(),
                builder => builder.Use(() => new SquareStep()),
                () => CreateSut(serviceProvider)
            )
            .UseWhen<PipelineConditionTrue>(builder => builder.Use(() => new SquareStep()))
            .BranchWhen<PipelineConditionFalse>(builder => builder.Use(() => new SquareStep()).UseTarget(TargetBranch))
            .BranchWhen
            (
                (_) => new PipelineConditionParamLessThanZero(),
                builder => builder.Use(() => new SquareStep()).UseTarget(TargetBranch),
                (_) => CreateSut(serviceProvider)
            )
            .Use<SquareStep>()
            .UseTarget(TargetMain);

        var pipeline = sut.BuildPipeline();

        var actualResult = pipeline.Invoke(arg);

        Assert.Equal(expectedResult, actualResult.Value);
    }

    #endregion
}
