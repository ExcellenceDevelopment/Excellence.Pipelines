using System;

namespace Excellence.Pipelines.Core.PipelineBuilders.Shared
{
    /// <summary>
    /// The core pipeline builder with the service provider.
    /// </summary>
    /// <typeparam name="TPipelineDelegate">The pipeline builder delegate type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderServiceProvider<TPipelineDelegate, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder, TPipeline>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder : IPipelineBuilderServiceProvider<TPipelineDelegate, TPipelineBuilder, TPipeline>
    {
        /// <summary>
        /// The service provider.
        /// </summary>
        public IServiceProvider? ServiceProvider { get; }

        /// <summary>
        /// Sets the service provider.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder UseServiceProvider(IServiceProvider? serviceProvider);
    }
}
