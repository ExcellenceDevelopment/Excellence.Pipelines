using System;

using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.PipelineBuilders;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async
{
    public class AsyncPipelineBuilderTests
    {
        #region Shared

        protected IAsyncPipelineBuilder<int, int> CreateSut(IServiceProvider? serviceProvider = null) =>
            new AsyncPipelineBuilder<int, int>(serviceProvider);

        #endregion Shared

        #region Constructors

        public static TheoryData<IServiceProvider?> ConstructorDefaultTestData => new TheoryData<IServiceProvider?>()
        {
            null,
            new ServiceCollection().BuildServiceProvider()
        };

        [Theory]
        [MemberData(nameof(ConstructorDefaultTestData))]
        public void Constructor_CreatesPipelineBuilder(IServiceProvider? serviceProvider)
        {
            var sut = this.CreateSut(serviceProvider);

            Assert.NotNull(sut);
            Assert.True(sut.ServiceProvider == serviceProvider);
        }

        #endregion Constructors
    }
}
