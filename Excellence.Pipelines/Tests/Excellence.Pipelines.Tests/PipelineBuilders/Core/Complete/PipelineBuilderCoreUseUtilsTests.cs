using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Core
{
    public class PipelineBuilderCoreUseUtilsTests : PipelineBuilderCoreCompleteTestsBase
    {
        #region Use

        [Fact]
        public void Use_Components_IsNull_ThrowsException()
        {
            var sut = CreateSut(new ServiceCollection().BuildServiceProvider());

            IEnumerable<Func<Func<int, CancellationToken, Task<int>>, Func<int, CancellationToken, Task<int>>>>? components = null;

            Assert.Throws<ArgumentNullException>(() => sut.Use(components!));
        }

        [Fact]
        public async Task Use_AddsComponentsToPipeline()
        {
            const int incrementValue = 10;

            var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

            var expectedResult = targetMainResult + incrementValue * 2;

            Func<Func<int, CancellationToken, Task<int>>, Func<int, CancellationToken, Task<int>>> component =
                next => async (param, cancellationToken) => await next.Invoke(param, cancellationToken) + incrementValue;

            var components = new[] { component, component };

            var sut = CreateSut(new ServiceCollection().BuildServiceProvider())
                .Use(components)
                .UseTarget(TargetMain);

            var pipeline = sut.BuildPipeline();

            var actualResult = await pipeline.Invoke(this.Arg, CancellationToken.None);

            Assert.Equal(expectedResult, actualResult);
        }

        #endregion Use
    }
}
