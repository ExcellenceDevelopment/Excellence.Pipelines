using System;

namespace Excellence.Pipelines.Core.PipelineBuilders.Core
{
    /// <summary>
    /// The core pipeline builder utils.
    /// </summary>
    /// <typeparam name="TPipelineDelegate">The pipeline builder delegate type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    public interface IPipelineBuilderCoreUtils<TPipelineDelegate, out TPipelineBuilder> :
        IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder : IPipelineBuilderCoreUtils<TPipelineDelegate, TPipelineBuilder>
    {
        /// <summary>
        /// Copies the pipeline builder.
        /// </summary>
        /// <returns>The new pipeline builder instance that has the same configuration as the current one.</returns>
        public TPipelineBuilder Copy();
    }
}
