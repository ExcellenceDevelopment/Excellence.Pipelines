using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilders;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilderFactories
{
    public class PipelineBuilderFactoryTests
    {
        #region Shared

        private IPipelineBuilderFactory CreateSut(IServiceProvider? serviceProvider = null)
            => new PipelineBuilderFactory(serviceProvider ?? new ServiceCollection().BuildServiceProvider());

        #endregion Shared

        #region Constructors

        [Fact]
        public void Constructor_Argument_IsNull_ThrowsException() => Assert.Throws<ArgumentNullException>(() => new PipelineBuilderFactory(null!));

        [Fact]
        public void Constructor_CreatesInstance()
        {
            var actualResult = this.CreateSut(new ServiceCollection().BuildServiceProvider());

            Assert.NotNull(actualResult);
        }

        #endregion Constructors

        #region CreatePipelineBuilder

        [Fact]
        public void CreatePipelineBuilder_CreatesPipelineBuilder()
        {
            var sut = this.CreateSut();

            var pipelineBuilder = sut.CreatePipelineBuilder<int, int>();

            Assert.NotNull(pipelineBuilder);
            Assert.IsType<PipelineBuilder<int, int>>(pipelineBuilder);
        }

        #endregion CreatePipelineBuilder
    }
}
