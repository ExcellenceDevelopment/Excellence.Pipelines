using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.PipelineBuilders.Core;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Core;

public class PipelineBuilderCoreTests : PipelineBuilderCoreTestsBase
{
    #region Shared

    protected interface IPipelineBuilderCoreTestSut :
        IPipelineBuilderCore<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, IPipelineBuilderCoreTestSut> { }


    protected class PipelineBuilderCoreTestSut :
        PipelineBuilderCore<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, IPipelineBuilderCoreTestSut>,
        IPipelineBuilderCoreTestSut { }

    protected static IPipelineBuilderCoreTestSut CreateSut() =>
        new PipelineBuilderCoreTestSut();

    #endregion

    #region Use

    [Fact]
    public void Use_Component_IsNull_ThrowsException()
    {
        var sut = CreateSut();

        Func<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, Func<PipelineArg, CancellationToken, Task<PipelineArg>>>? component = null;

        Assert.Throws<ArgumentNullException>(() => sut.Use(component!));
    }

    [Fact]
    public async Task Use_AddsComponentToPipeline()
    {
        const int incrementValue = 10;

        var targetMainResult = await TargetMainResult.Invoke(new PipelineArg(), CancellationToken.None);

        var expectedResult = targetMainResult.Value + incrementValue;

        Func<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, Func<PipelineArg, CancellationToken, Task<PipelineArg>>> component =
            next => async (param, cancellationToken) =>
            {
                var result = await next.Invoke(param, cancellationToken);

                result.Value += incrementValue;

                return result;
            };

        var sut = CreateSut()
            .Use(component)
            .UseTarget(TargetMain);

        var pipeline = sut.BuildPipeline();

        var actualResult = await pipeline.Invoke(new PipelineArg(), CancellationToken.None);

        Assert.Equal(expectedResult, actualResult.Value);
    }

    #endregion

    #region UseTarget

    [Fact]
    public void UseTarget_IsNull_ThrowsException()
    {
        var sut = CreateSut();

        Assert.Throws<ArgumentNullException>(() => sut.UseTarget(null!));
    }

    [Fact]
    public async Task UseTarget_SetsTarget()
    {
        var targetMainResult = await TargetMainResult.Invoke(new PipelineArg(), CancellationToken.None);

        var expectedResult = targetMainResult.Value;

        var sut = CreateSut()
            .UseTarget(TargetMain);

        var pipeline = sut.BuildPipeline();

        var actualResult = await pipeline.Invoke(new PipelineArg(), CancellationToken.None);

        Assert.Equal(expectedResult, actualResult.Value);
    }

    #endregion

    #region BuildPipeline

    [Fact]
    public void BuildPipeline_Target_IsNull_ThrowsException()
    {
        var sut = CreateSut();

        var expectedResultMessage = $"The {sut.GetType()} does not have a target.";

        var actualResult = Assert.Throws<InvalidOperationException>(() => sut.BuildPipeline());

        Assert.Equal(expectedResultMessage, actualResult.Message);
    }

    [Fact]
    public async Task BuildPipeline_BuildsPipeline()
    {
        var targetMainResult = await TargetMainResult.Invoke(new PipelineArg(), CancellationToken.None);

        var expectedResult = targetMainResult.Value;

        var sut = CreateSut()
            .UseTarget(TargetMain);

        var pipeline = sut.BuildPipeline();

        var actualResult = await pipeline.Invoke(new PipelineArg(), CancellationToken.None);

        Assert.Equal(expectedResult, actualResult.Value);
    }

    #endregion
}
