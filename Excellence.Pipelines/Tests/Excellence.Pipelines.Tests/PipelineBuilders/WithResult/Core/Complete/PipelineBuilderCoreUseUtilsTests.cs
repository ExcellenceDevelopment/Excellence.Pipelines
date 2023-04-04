using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Core;

public class PipelineBuilderCoreUseUtilsTests : PipelineBuilderCoreCompleteTestsBase
{
    #region Use

    [Fact]
    public void Use_Components_IsNull_ThrowsException()
    {
        var sut = CreateSut(new ServiceCollection().BuildServiceProvider());

        IEnumerable<Func<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, Func<PipelineArg, CancellationToken, Task<PipelineArg>>>>? components = null;

        Assert.Throws<ArgumentNullException>(() => sut.Use(components!));
    }

    [Fact]
    public async Task Use_AddsComponentsToPipeline()
    {
        const int incrementValue = 10;

        var targetMainResult = await TargetMainResult.Invoke(new PipelineArg(), CancellationToken.None);

        var expectedResult = targetMainResult.Value + incrementValue * 2;

        Func<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, Func<PipelineArg, CancellationToken, Task<PipelineArg>>> component =
            next => async (param, cancellationToken) =>
            {
                var result = await next.Invoke(param, cancellationToken);

                result.Value += incrementValue;

                return result;
            };

        var components = new[] { component, component };

        var sut = CreateSut(new ServiceCollection().BuildServiceProvider())
            .Use(components)
            .UseTarget(TargetMain);

        var pipeline = sut.BuildPipeline();

        var actualResult = await pipeline.Invoke(new PipelineArg(), CancellationToken.None);

        Assert.Equal(expectedResult, actualResult.Value);
    }

    #endregion
}
