using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.Pipelines;

using Xunit;

namespace Excellence.Pipelines.Tests.Pipelines
{
    public class AsyncPipelineTests
    {
        #region Shared

        private IAsyncPipeline<int, int> CreateSut(Func<int, CancellationToken, Task<int>> pipelineDelegate) =>
            new AsyncPipeline<int, int>(pipelineDelegate);

        private Func<int, CancellationToken, Task<int>> PipelineDelegate => (param, _) => Task.FromResult(param + 1);

        #endregion Shared

        #region Constructors

        [Fact]
        public void Constructor_PipelineDelegateIsNull_ThrowsException() => Assert.Throws<ArgumentNullException>(() => this.CreateSut(null!));

        [Fact]
        public void Constructor_CreatesPipeline()
        {
            var sut = this.CreateSut(this.PipelineDelegate);

            Assert.NotNull(sut);
        }

        #endregion Constructors

        #region InvokeAsync

        [Fact]
        public async Task InvokeAsync_InvokesPipelineDelegate()
        {
            var arg = 10;

            var expectedResult = arg + 1;

            var sut = this.CreateSut(this.PipelineDelegate);

            var actualResult = await sut.InvokeAsync(arg, CancellationToken.None);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion InvokeAsync
    }
}
