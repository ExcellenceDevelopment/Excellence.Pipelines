using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.PipelineSteps;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async.Complete
{
    public class AsyncPipelineBuilderTests : AsyncPipelineBuilderTestsBase
    {
        #region Shared

        protected static Func<int, CancellationToken, Task<int>> TargetBranchResult =>
            (param, _) => Task.FromResult(param * 2);

        protected static Task<int> TargetBranch(int param, CancellationToken cancellationToken) =>
            TargetBranchResult.Invoke(param, cancellationToken);

        #region Steps

        protected class SquareStep : IAsyncPipelineStep<int, int>
        {
            public virtual async Task<int> InvokeAsync(int param, CancellationToken cancellationToken, Func<int, CancellationToken, Task<int>> next)
            {
                var nextResult = await next.Invoke(param, cancellationToken);

                return nextResult * nextResult;
            }
        }

        #endregion Steps

        #region Conditions

        protected class PipelineConditionParamGreaterThanZero : IAsyncPipelineCondition<int>
        {
            public Task<bool> InvokeAsync(int param) => Task.FromResult(param > 0);
        }

        protected class PipelineConditionParamLessThanZero : IAsyncPipelineCondition<int>
        {
            public Task<bool> InvokeAsync(int param) => Task.FromResult(param < 0);
        }

        protected class PipelineConditionTrue : IAsyncPipelineCondition<int>
        {
            public Task<bool> InvokeAsync(int param) => Task.FromResult(true);
        }

        protected class PipelineConditionFalse : IAsyncPipelineCondition<int>
        {
            public Task<bool> InvokeAsync(int param) => Task.FromResult(false);
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
        public async Task Multiple_AddsComponentsToPipeline(int arg, int expectedResult)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<PipelineConditionParamGreaterThanZero>()
                .AddTransient<PipelineConditionParamLessThanZero>()
                .AddTransient<PipelineConditionTrue>()
                .AddTransient<PipelineConditionFalse>()
                .AddTransient<SquareStep>()
                .BuildServiceProvider();

            var sut = CreateSut(serviceProvider)
                .Use(next => (param, cancellationToken) => next.Invoke(param + 1, cancellationToken))
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

            var actualResult = await pipeline.InvokeAsync(arg, CancellationToken.None);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion Multiple steps
    }
}
