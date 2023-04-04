using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Async.Complete;

public class AsyncPipelineBuilderCompleteTests : AsyncPipelineBuilderCompleteTestsBase
{
    #region Shared

    protected static Func<PipelineArg, CancellationToken, Task> TargetBranchResult =>
        (param, _) =>
        {
            param.Value *= 2;

            return Task.CompletedTask;
        };

    protected static Task TargetBranch(PipelineArg param, CancellationToken cancellationToken) =>
        TargetBranchResult.Invoke(param, cancellationToken);

    #region Steps

    protected class SquareStep : IAsyncPipelineStep<PipelineArg>
    {
        public virtual async Task Invoke(PipelineArg param, CancellationToken cancellationToken, Func<PipelineArg, CancellationToken, Task> next)
        {
            await next.Invoke(param, cancellationToken);

            param.Value *= param.Value;
        }
    }

    #endregion

    #region Conditions

    protected class PipelineConditionParamGreaterThanZero : IAsyncPipelineCondition<PipelineArg>
    {
        public Task<bool> Invoke(PipelineArg param) => Task.FromResult(param.Value > 0);
    }

    protected class PipelineConditionParamLessThanZero : IAsyncPipelineCondition<PipelineArg>
    {
        public Task<bool> Invoke(PipelineArg param) => Task.FromResult(param.Value < 0);
    }

    protected class PipelineConditionTrue : IAsyncPipelineCondition<PipelineArg>
    {
        public Task<bool> Invoke(PipelineArg param) => Task.FromResult(true);
    }

    protected class PipelineConditionFalse : IAsyncPipelineCondition<PipelineArg>
    {
        public Task<bool> Invoke(PipelineArg param) => Task.FromResult(false);
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
    public async Task Multiple_AddsComponentsToPipeline(int argValue, int expectedResult)
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
                next => (param, cancellationToken) =>
                {
                    param.Value += 1;

                    return next.Invoke(param, cancellationToken);
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

        await pipeline.Invoke(arg, CancellationToken.None);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
    }

    #endregion
}
