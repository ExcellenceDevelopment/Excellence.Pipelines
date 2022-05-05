using System;

using Excellence.Pipelines.Core.PipelineBuilders;

namespace Excellence.Pipelines.Core.PipelineBuilderFactories
{
    /// <summary>
    /// The pipeline builder factory.
    /// </summary>
    public interface IPipelineBuilderFactory
    {
        /// <summary>
        /// Creates the new pipeline builder instance.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <typeparam name="TParam">The parameter type.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <returns>The pipeline builder.</returns>
        public IPipelineBuilder<TParam, TResult> Create<TParam, TResult>(IServiceProvider? serviceProvider = null);
    }
}
