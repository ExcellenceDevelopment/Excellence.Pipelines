using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.PipelineBuilders.Core;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Core
{
    public class PipelineBuilderCoreTests : PipelineBuilderCoreTestsBase
    {
        #region Shared

        protected interface IPipelineBuilderCoreTestSut :
            IPipelineBuilderCore<Func<int, CancellationToken, Task<int>>, IPipelineBuilderCoreTestSut> { }


        protected class PipelineBuilderCoreTestSut :
            PipelineBuilderCore<Func<int, CancellationToken, Task<int>>, IPipelineBuilderCoreTestSut>,
            IPipelineBuilderCoreTestSut { }

        protected static IPipelineBuilderCoreTestSut CreateSut() =>
            new PipelineBuilderCoreTestSut();

        #endregion Shared

        #region Use

        [Fact]
        public void Use_Component_IsNull_ThrowsException()
        {
            var sut = CreateSut();

            Func<Func<int, CancellationToken, Task<int>>, Func<int, CancellationToken, Task<int>>>? component = null;

            Assert.Throws<ArgumentNullException>(() => sut.Use(component!));
        }

        [Fact]
        public async Task Use_AddsComponentToPipeline()
        {
            const int incrementValue = 10;

            var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

            var expectedResult = targetMainResult + incrementValue;

            Func<Func<int, CancellationToken, Task<int>>, Func<int, CancellationToken, Task<int>>> component =
                next => async (param, cancellationToken) => await next.Invoke(param, cancellationToken) + incrementValue;

            var sut = CreateSut()
                .Use(component)
                .UseTarget(TargetMain);

            var pipeline = sut.BuildPipeline();

            var actualResult = await pipeline.Invoke(this.Arg, CancellationToken.None);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion Use

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
            var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

            var expectedResult = targetMainResult;

            var sut = CreateSut()
                .UseTarget(TargetMain);

            var pipeline = sut.BuildPipeline();

            var actualResult = await pipeline.Invoke(this.Arg, CancellationToken.None);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion UseTarget

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
            var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

            var expectedResult = targetMainResult;

            var sut = CreateSut()
                .UseTarget(TargetMain);

            var pipeline = sut.BuildPipeline();

            var actualResult = await pipeline.Invoke(this.Arg, CancellationToken.None);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion BuildPipeline
    }
}
