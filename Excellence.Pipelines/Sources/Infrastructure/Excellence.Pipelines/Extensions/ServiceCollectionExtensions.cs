using System;

using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.Utils;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Extensions
{
    /// <summary>
    /// The service collection extensions.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the dependencies needed for the the pipelines.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>The passed <see cref="IServiceCollection"/> instance with the added dependencies.</returns>
        /// <exception cref="ArgumentNullException">The exception when the argument is <see langword="null"/>.</exception>
        public static IServiceCollection AddPipelines(this IServiceCollection serviceCollection)
        {
            ExceptionUtils.Process(serviceCollection, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(serviceCollection)));

            serviceCollection.AddSingleton<IPipelineBuilderFactory, PipelineBuilderFactory>();
            serviceCollection.AddSingleton<IAsyncPipelineBuilderFactory, AsyncPipelineBuilderFactory>();

            return serviceCollection;
        }
    }
}
