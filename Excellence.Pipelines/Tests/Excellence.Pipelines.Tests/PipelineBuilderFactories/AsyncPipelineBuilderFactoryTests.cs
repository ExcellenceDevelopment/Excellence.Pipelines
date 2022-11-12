using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilders;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilderFactories
{
    public class AsyncPipelineBuilderFactoryTests
    {
        #region Shared

        private IAsyncPipelineBuilderFactory CreateSut(IServiceProvider? serviceProvider = null)
            => new AsyncPipelineBuilderFactory(serviceProvider ?? new ServiceCollection().BuildServiceProvider());

        #endregion Shared

        #region Constructors

        [Fact]
        public void Constructor_Argument_IsNull_ThrowsException() => Assert.Throws<ArgumentNullException>(() => new AsyncPipelineBuilderFactory(null!));

        [Fact]
        public void Constructor_CreatesInstance()
        {
            var actualResult = this.CreateSut(new ServiceCollection().BuildServiceProvider());

            Assert.NotNull(actualResult);
        }

        #endregion Constructors

        #region CreateAsyncPipelineBuilder

        [Fact]
        public void CreateAsyncPipelineBuilder_CreatesPipelineBuilder()
        {
            var sut = this.CreateSut();

            var pipelineBuilder = sut.CreateAsyncPipelineBuilder<int, int>();

            Assert.NotNull(pipelineBuilder);
            Assert.IsType<AsyncPipelineBuilder<int, int>>(pipelineBuilder);
        }

        #endregion CreateAsyncPipelineBuilder
    }
}
