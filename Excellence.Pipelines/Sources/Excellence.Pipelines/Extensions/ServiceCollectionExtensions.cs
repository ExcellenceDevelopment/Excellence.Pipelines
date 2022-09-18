using System;

using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.Utils;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        /// <param name="services">The services.</param>
        /// <returns>The passed <see cref="IServiceCollection"/> instance with the added dependencies.</returns>
        /// <exception cref="ArgumentNullException">The exception when the argument is <see langword="null"/>.</exception>
        public static IServiceCollection AddPipelines(this IServiceCollection services)
        {
            ExceptionUtils.Process(services, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(services)));

            services.TryAddSingleton<IPipelineBuilderFactory>(serviceProvider => new PipelineBuilderFactory(serviceProvider));
            services.TryAddSingleton<IAsyncPipelineBuilderFactory>(serviceProvider => new AsyncPipelineBuilderFactory(serviceProvider));

            return services;
        }
    }
}
