using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Core.Complete;

public class PipelineBuilderCoreUseUtilsTests : PipelineBuilderCoreCompleteTestsBase
{
    #region Use

    [Fact]
    public void Use_Components_IsNull_ThrowsException()
    {
        var sut = CreateSut(new ServiceCollection().BuildServiceProvider());

        IEnumerable<Func<Func<PipelineArg, CancellationToken, Task>, Func<PipelineArg, CancellationToken, Task>>>? components = null;

        Assert.Throws<ArgumentNullException>(() => sut.Use(components!));
    }

    [Fact]
    public async Task Use_AddsComponentsToPipeline()
    {
        const int incrementValue = 10;

        var tempArg = new PipelineArg();
        await TargetMainResult.Invoke(tempArg, CancellationToken.None);

        var expectedResult = tempArg.Value + incrementValue * 2;

        Func<Func<PipelineArg, CancellationToken, Task>, Func<PipelineArg, CancellationToken, Task>> component =
            next => async (param, cancellationToken) =>
            {
                await next.Invoke(param, cancellationToken);

                param.Value += incrementValue;
            };

        var components = new[] { component, component };

        var sut = CreateSut(new ServiceCollection().BuildServiceProvider())
            .Use(components)
            .UseTarget(TargetMain);

        var pipeline = sut.BuildPipeline();

        var arg = new PipelineArg();
        await pipeline.Invoke(arg, CancellationToken.None);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
    }

    #endregion
}
