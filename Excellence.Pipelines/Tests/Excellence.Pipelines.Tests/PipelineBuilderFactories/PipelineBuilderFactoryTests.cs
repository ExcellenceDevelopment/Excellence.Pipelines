using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilders;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilderFactories;

public class PipelineBuilderFactoryTests
{
    #region Shared

    private IPipelineBuilderFactory CreateSut(IServiceProvider? serviceProvider = null)
        => new PipelineBuilderFactory(serviceProvider ?? new ServiceCollection().BuildServiceProvider());

    #endregion

    #region Constructors

    [Fact]
    public void Constructor_Argument_IsNull_ThrowsException() => Assert.Throws<ArgumentNullException>(() => new PipelineBuilderFactory(null!));

    [Fact]
    public void Constructor_CreatesInstance()
    {
        var actualResult = this.CreateSut(new ServiceCollection().BuildServiceProvider());

        Assert.NotNull(actualResult);
    }

    #endregion

    #region CreatePipelineBuilder (without result)

    [Fact]
    public void CreatePipelineBuilder_WithoutResult_CreatesPipelineBuilder()
    {
        var sut = this.CreateSut();

        var pipelineBuilder = sut.CreatePipelineBuilder<int>();

        Assert.NotNull(pipelineBuilder);
        Assert.IsType<PipelineBuilder<int>>(pipelineBuilder);
    }

    #endregion

    #region CreatePipelineBuilder (with result)

    [Fact]
    public void CreatePipelineBuilder_WithResult_CreatesPipelineBuilder()
    {
        var sut = this.CreateSut();

        var pipelineBuilder = sut.CreatePipelineBuilder<int, int>();

        Assert.NotNull(pipelineBuilder);
        Assert.IsType<PipelineBuilder<int, int>>(pipelineBuilder);
    }

    #endregion
}
