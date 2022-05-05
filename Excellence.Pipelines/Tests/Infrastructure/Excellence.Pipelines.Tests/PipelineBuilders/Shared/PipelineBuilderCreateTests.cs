using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Shared
{
    public partial class PipelineBuilderSharedTests
    {
        #region Shared

        protected Func<Func<int, CancellationToken, Task<int>>, Func<int, CancellationToken, Task<int>>> Component =>
            next => async (param, cancellationToken) =>
            {
                var nextResult = await next.Invoke(param, cancellationToken);

                return nextResult * nextResult;
            };

        #endregion Shared

        #region New

        [Fact]
        public async Task New_CreatesEmptyPipelineBuilder()
        {
            var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

            var expectedResultSourcePipeline = targetMainResult * targetMainResult * targetMainResult * targetMainResult;
            var expectedResultPipelineNew = targetMainResult;

            var serviceProvider = new ServiceCollection().BuildServiceProvider();

            var sourcePipelineBuilder = CreateSut(serviceProvider)
                .Use(this.Component)
                .Use(this.Component)
                .UseTarget(TargetMain);

            var pipelineBuilderNew = sourcePipelineBuilder
                .New()
                .UseTarget(TargetMain);

            var sourcePipeline = sourcePipelineBuilder.BuildPipeline();
            var actualResultSourcePipeline = await sourcePipeline.InvokeAsync(this.Arg, CancellationToken.None);

            var pipelineNew = pipelineBuilderNew.BuildPipeline();
            var actualResultPipelineNew = await pipelineNew.InvokeAsync(this.Arg, CancellationToken.None);

            Assert.Equal(pipelineBuilderNew.ServiceProvider, sourcePipelineBuilder.ServiceProvider);
            Assert.True(ReferenceEquals(pipelineBuilderNew.ServiceProvider, sourcePipelineBuilder.ServiceProvider));

            Assert.Equal(expectedResultSourcePipeline, actualResultSourcePipeline);
            Assert.Equal(expectedResultPipelineNew, actualResultPipelineNew);
        }

        #endregion New

        #region Copy

        public static TheoryData<bool> CopyTargetSetOrderTestData => new TheoryData<bool>()
        {
            { true },
            { false }
        };

        [Theory]
        [MemberData(nameof(CopyTargetSetOrderTestData))]
        public async Task Copy_CopiesPipelineBuilder(bool setTargetBeforeCopying)
        {
            var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

            var expectedResultSourcePipeline = targetMainResult * targetMainResult * targetMainResult * targetMainResult;
            var expectedResultPipelineCopy = expectedResultSourcePipeline * expectedResultSourcePipeline;

            var serviceProvider = new ServiceCollection().BuildServiceProvider();

            var sourcePipelineBuilder = CreateSut(serviceProvider)
                .Use(this.Component)
                .Use(this.Component);

            if (setTargetBeforeCopying)
            {
                sourcePipelineBuilder.UseTarget(TargetMain);
            }

            var pipelineBuilderCopy = sourcePipelineBuilder
                .Copy()
                .Use(this.Component);

            if (!setTargetBeforeCopying)
            {
                sourcePipelineBuilder.UseTarget(TargetMain);
                pipelineBuilderCopy.UseTarget(TargetMain);
            }

            var sourcePipeline = sourcePipelineBuilder.BuildPipeline();
            var actualResultSourcePipeline = await sourcePipeline.InvokeAsync(this.Arg, CancellationToken.None);

            var pipelineCopy = pipelineBuilderCopy.BuildPipeline();
            var actualResultPipelineCopy = await pipelineCopy.InvokeAsync(this.Arg, CancellationToken.None);

            Assert.Equal(pipelineBuilderCopy.ServiceProvider, sourcePipelineBuilder.ServiceProvider);
            Assert.True(ReferenceEquals(pipelineBuilderCopy.ServiceProvider, sourcePipelineBuilder.ServiceProvider));

            Assert.Equal(expectedResultSourcePipeline, actualResultSourcePipeline);
            Assert.Equal(expectedResultPipelineCopy, actualResultPipelineCopy);
        }

        #endregion Copy
    }
}
