using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilders;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilderFactories
{
    public class AsyncPipelineBuilderFactoryTests
    {
        #region Shared

        private IAsyncPipelineBuilderFactory CreateSut() => new AsyncPipelineBuilderFactory();

        #endregion Shared

        [Fact]
        public void Create_CreatesPipelineBuilder()
        {
            var sut = this.CreateSut();

            var pipelineBuilder = sut.Create<int, int>();

            Assert.NotNull(pipelineBuilder);
            Assert.IsType<AsyncPipelineBuilder<int, int>>(pipelineBuilder);
        }
    }
}
