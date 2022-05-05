using System;

namespace Excellence.Pipelines.Core.PipelineBuilders.Shared
{
    /// <summary>
    /// The core pipeline builder with the creation functionality.
    /// </summary>
    /// <typeparam name="TPipelineDelegate">The pipeline builder delegate type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderCreate<TPipelineDelegate, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder, TPipeline>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder : IPipelineBuilderCreate<TPipelineDelegate, TPipelineBuilder, TPipeline>
    {
        /// <summary>
        /// Creates the new pipeline builder instance of the same type without the components added and the target set.
        /// </summary>
        /// <returns>The new pipeline builder instance without the components added and the target set.</returns>
        public TPipelineBuilder New();

        /// <summary>
        /// Copies the pipeline builder.
        /// </summary>
        /// <returns>The new pipeline builder instance that has the same configuration as the current one.</returns>
        public TPipelineBuilder Copy();
    }
}
