using System;

using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.PipelineSteps;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Default.Complete
{
    public class PipelineBuilderTests : PipelineBuilderTestsBase
    {
        #region Shared

        protected static Func<int, int> TargetBranchResult =>
            (param) => param * 2;

        protected static int TargetBranch(int param) =>
            TargetBranchResult.Invoke(param);

        #region Steps

        protected class SquareStep : IPipelineStep<int, int>
        {
            public virtual int Invoke(int param, Func<int, int> next)
            {
                var nextResult = next.Invoke(param);

                return nextResult * nextResult;
            }
        }

        #endregion Steps

        #region Conditions

        protected class PipelineConditionParamGreaterThanZero : IPipelineCondition<int>
        {
            public bool Invoke(int param) => param > 0;
        }

        protected class PipelineConditionParamLessThanZero : IPipelineCondition<int>
        {
            public bool Invoke(int param) => param < 0;
        }

        protected class PipelineConditionTrue : IPipelineCondition<int>
        {
            public bool Invoke(int param) => true;
        }

        protected class PipelineConditionFalse : IPipelineCondition<int>
        {
            public bool Invoke(int param) => false;
        }

        #endregion Conditions

        #endregion Shared

        #region Multiple steps

        public static TheoryData<int, int> MultipleTestData => new TheoryData<int, int>()
        {
            { 5, 1679616 },
            { -5, 4096 }
        };

        [Theory]
        [MemberData(nameof(MultipleTestData))]
        public void Multiple_AddsComponentsToPipeline(int arg, int expectedResult)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<PipelineConditionParamGreaterThanZero>()
                .AddTransient<PipelineConditionParamLessThanZero>()
                .AddTransient<PipelineConditionTrue>()
                .AddTransient<PipelineConditionFalse>()
                .AddTransient<SquareStep>()
                .BuildServiceProvider();

            var sut = CreateSut(serviceProvider)
                .Use(next => (param) => next.Invoke(param + 1))
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

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion Multiple steps
    }
}
