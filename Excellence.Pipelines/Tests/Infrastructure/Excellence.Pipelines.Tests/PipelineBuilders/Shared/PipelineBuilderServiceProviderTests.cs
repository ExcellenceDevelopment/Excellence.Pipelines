using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Shared
{
    public partial class PipelineBuilderSharedTests
    {
        [Fact]
        public void Constructor_ServiceProvider_IsSet()
        {
            var serviceProvider = new ServiceCollection().BuildServiceProvider();

            var sut = CreateSut(serviceProvider);

            Assert.Equal(serviceProvider, sut.ServiceProvider);
        }

        [Fact]
        public void UseServiceProvider_IsSet()
        {
            var serviceProvider = new ServiceCollection().BuildServiceProvider();

            var sut = CreateSut()
                .UseServiceProvider(serviceProvider);

            Assert.Equal(serviceProvider, sut.ServiceProvider);
        }
    }
}
