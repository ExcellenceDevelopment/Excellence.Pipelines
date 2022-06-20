using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Core
{
    public class PipelineBuilderCoreUtilsTests : PipelineBuilderCoreCompleteTestsBase
    {
        #region Constructors

        [Fact]
        public void Constructor_ServiceProvider_IsNull_ThrowsException() => Assert.Throws<ArgumentNullException>(() => CreateSut(null!));

        [Fact]
        public void Constructor_ServiceProvider_IsSet()
        {
            var serviceProvider = new ServiceCollection().BuildServiceProvider();

            var sut = CreateSut(serviceProvider);

            Assert.Equal(serviceProvider, sut.ServiceProviderPublic);
        }

        #endregion Constructors

        #region Copy

        public static TheoryData<bool> CopyTargetSetOrderTestData => new TheoryData<bool>() { { true }, { false } };

        [Theory]
        [MemberData(nameof(CopyTargetSetOrderTestData))]
        public async Task Copy_CopiesPipelineBuilder(bool setTargetBeforeCopying)
        {
            var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

            var expectedResultSourcePipeline = targetMainResult * targetMainResult * targetMainResult * targetMainResult;
            var expectedResultPipelineCopy = expectedResultSourcePipeline * expectedResultSourcePipeline;

            var sourcePipelineBuilder = CreateSut(new ServiceCollection().BuildServiceProvider())
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
            var actualResultSourcePipeline = await sourcePipeline.Invoke(this.Arg, CancellationToken.None);

            var pipelineCopy = pipelineBuilderCopy.BuildPipeline();
            var actualResultPipelineCopy = await pipelineCopy.Invoke(this.Arg, CancellationToken.None);

            Assert.Equal(pipelineBuilderCopy.ServiceProviderPublic, sourcePipelineBuilder.ServiceProviderPublic);
            Assert.True(ReferenceEquals(pipelineBuilderCopy.ServiceProviderPublic, sourcePipelineBuilder.ServiceProviderPublic));

            Assert.Equal(expectedResultSourcePipeline, actualResultSourcePipeline);
            Assert.Equal(expectedResultPipelineCopy, actualResultPipelineCopy);
        }

        #endregion Copy
    }
}
