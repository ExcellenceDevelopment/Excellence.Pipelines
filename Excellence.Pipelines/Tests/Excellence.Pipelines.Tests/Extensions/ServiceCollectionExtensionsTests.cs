using System;

using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.Extensions;
using Excellence.Pipelines.PipelineBuilderFactories;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.Extensions
{
    public class ServiceCollectionExtensionsTests
    {
        #region AddPipelines

        [Fact]
        public void AddPipelines_Argument_IsNull_ThrowsException()
        {
            var sut = default(IServiceCollection);

            Assert.Throws<ArgumentNullException>(() => sut!.AddPipelines());
        }

        [Fact]
        public void AddPipelines_AddsPipelines()
        {
            var expectedType = typeof(PipelineBuilderFactory);
            var expectedAsyncType = typeof(AsyncPipelineBuilderFactory);

            var sut = new ServiceCollection();

            var actualResult = sut.AddPipelines();

            var serviceProvider = actualResult.BuildServiceProvider();

            var factory = serviceProvider.GetRequiredService<IPipelineBuilderFactory>();

            Assert.NotNull(factory);
            Assert.Equal(expectedType, factory.GetType());

            var asyncFactory = serviceProvider.GetRequiredService<IAsyncPipelineBuilderFactory>();

            Assert.NotNull(asyncFactory);
            Assert.Equal(expectedAsyncType, asyncFactory.GetType());
        }

        #endregion AddPipelines
    }
}
