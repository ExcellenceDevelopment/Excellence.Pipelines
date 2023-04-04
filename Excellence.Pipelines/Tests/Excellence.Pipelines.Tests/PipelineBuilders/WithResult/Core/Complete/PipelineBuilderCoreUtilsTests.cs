using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Core;

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

    #endregion

    #region Copy

    public static TheoryData<bool> CopyTargetSetOrderTestData => new TheoryData<bool>() { true, false };

    [Theory]
    [MemberData(nameof(CopyTargetSetOrderTestData))]
    public async Task Copy_CopiesPipelineBuilder(bool setTargetBeforeCopying)
    {
        var targetMainResult = await TargetMainResult.Invoke(new PipelineArg(), CancellationToken.None);
        var targetMainResultValue = targetMainResult.Value;

        var expectedResultSourcePipeline = targetMainResultValue * targetMainResultValue * targetMainResultValue * targetMainResultValue;
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
        var actualResultSourcePipeline = await sourcePipeline.Invoke(new PipelineArg(), CancellationToken.None);

        var pipelineCopy = pipelineBuilderCopy.BuildPipeline();
        var actualResultPipelineCopy = await pipelineCopy.Invoke(new PipelineArg(), CancellationToken.None);

        Assert.Equal(pipelineBuilderCopy.ServiceProviderPublic, sourcePipelineBuilder.ServiceProviderPublic);
        Assert.True(ReferenceEquals(pipelineBuilderCopy.ServiceProviderPublic, sourcePipelineBuilder.ServiceProviderPublic));

        Assert.Equal(expectedResultSourcePipeline, actualResultSourcePipeline.Value);
        Assert.Equal(expectedResultPipelineCopy, actualResultPipelineCopy.Value);
    }

    #endregion
}
