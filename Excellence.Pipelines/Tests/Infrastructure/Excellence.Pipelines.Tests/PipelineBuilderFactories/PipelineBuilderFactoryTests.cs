using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilders;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilderFactories
{
    public class PipelineBuilderFactoryTests
    {
        #region Shared

        private IPipelineBuilderFactory CreateSut() => new PipelineBuilderFactory();

        #endregion Shared

        [Fact]
        public void Create_CreatesPipelineBuilder()
        {
            var sut = this.CreateSut();

            var pipelineBuilder = sut.Create<int, int>();

            Assert.NotNull(pipelineBuilder);
            Assert.IsType<PipelineBuilder<int, int>>(pipelineBuilder);
        }
    }
}
