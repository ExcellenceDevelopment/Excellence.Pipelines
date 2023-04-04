using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Core.Complete;

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
        var argSourceTemp = new PipelineArg();
        await TargetMainResult.Invoke(argSourceTemp, CancellationToken.None);

        var argSourceValue = argSourceTemp.Value;
        var expectedResultSourcePipeline = argSourceValue * argSourceValue * argSourceValue * argSourceValue;

        var argCopyTemp = new PipelineArg();
        await TargetMainResult.Invoke(argCopyTemp, CancellationToken.None);

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
        var argSource = new PipelineArg();
        await sourcePipeline.Invoke(argSource, CancellationToken.None);
        var actualResultSourcePipeline = argSource.Value;

        var pipelineCopy = pipelineBuilderCopy.BuildPipeline();
        var argCopy = new PipelineArg();
        await pipelineCopy.Invoke(argCopy, CancellationToken.None);
        var actualResultPipelineCopy = argCopy.Value;

        Assert.Equal(pipelineBuilderCopy.ServiceProviderPublic, sourcePipelineBuilder.ServiceProviderPublic);
        Assert.True(ReferenceEquals(pipelineBuilderCopy.ServiceProviderPublic, sourcePipelineBuilder.ServiceProviderPublic));

        Assert.Equal(expectedResultSourcePipeline, actualResultSourcePipeline);
        Assert.Equal(expectedResultPipelineCopy, actualResultPipelineCopy);
    }

    #endregion
}
