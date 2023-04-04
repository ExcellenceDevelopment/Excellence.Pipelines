using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.PipelineBuilders.Core;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Core.Core;

public class PipelineBuilderCoreTests : PipelineBuilderCoreTestsBase
{
    #region Shared

    protected interface IPipelineBuilderCoreTestSut :
        IPipelineBuilderCore<Func<PipelineArg, CancellationToken, Task>, IPipelineBuilderCoreTestSut> { }


    protected class PipelineBuilderCoreTestSut :
        PipelineBuilderCore<Func<PipelineArg, CancellationToken, Task>, IPipelineBuilderCoreTestSut>,
        IPipelineBuilderCoreTestSut { }

    protected static IPipelineBuilderCoreTestSut CreateSut() =>
        new PipelineBuilderCoreTestSut();

    #endregion

    #region Use

    [Fact]
    public void Use_Component_IsNull_ThrowsException()
    {
        var sut = CreateSut();

        Func<Func<PipelineArg, CancellationToken, Task>, Func<PipelineArg, CancellationToken, Task>>? component = null;

        Assert.Throws<ArgumentNullException>(() => sut.Use(component!));
    }

    [Fact]
    public async Task Use_AddsComponentToPipeline()
    {
        const int incrementValue = 10;

        var tempArg = new PipelineArg();
        await TargetMainResult.Invoke(tempArg, CancellationToken.None);

        var expectedResult = tempArg.Value + incrementValue;

        Func<Func<PipelineArg, CancellationToken, Task>, Func<PipelineArg, CancellationToken, Task>> component =
            next => async (param, cancellationToken) =>
            {
                await next.Invoke(param, cancellationToken);

                param.Value += incrementValue;
            };

        var sut = CreateSut()
            .Use(component)
            .UseTarget(TargetMain);

        var pipeline = sut.BuildPipeline();

        var arg = new PipelineArg();
        await pipeline.Invoke(arg, CancellationToken.None);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
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
        var tempArg = new PipelineArg();
        await TargetMainResult.Invoke(tempArg, CancellationToken.None);

        var expectedResult = tempArg.Value;

        var sut = CreateSut()
            .UseTarget(TargetMain);

        var pipeline = sut.BuildPipeline();

        var arg = new PipelineArg();
        await pipeline.Invoke(arg, CancellationToken.None);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
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
        var tempArg = new PipelineArg();
        await TargetMainResult.Invoke(tempArg, CancellationToken.None);

        var expectedResult = tempArg.Value;

        var sut = CreateSut()
            .UseTarget(TargetMain);

        var pipeline = sut.BuildPipeline();

        var arg = new PipelineArg();
        await pipeline.Invoke(arg, CancellationToken.None);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
    }

    #endregion
}
