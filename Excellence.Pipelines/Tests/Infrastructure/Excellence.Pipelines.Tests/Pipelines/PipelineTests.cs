using System;

using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.Pipelines;

using Xunit;

namespace Excellence.Pipelines.Tests.Pipelines
{
    public class PipelineTests
    {
        #region Shared

        private IPipeline<int, int> CreateSut(Func<int, int> pipelineDelegate) =>
            new Pipeline<int, int>(pipelineDelegate);

        private Func<int, int> PipelineDelegate => (param) => param + 1;

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

        #region Invoke

        [Fact]
        public void Invoke_InvokesPipelineDelegate()
        {
            var arg = 10;

            var expectedResult = arg + 1;

            var sut = this.CreateSut(this.PipelineDelegate);

            var actualResult = sut.Invoke(arg);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion Invoke
    }
}
