using System;
using System.Collections.Generic;

namespace Excellence.Pipelines.Core.PipelineBuilders.Core
{
    /// <summary>
    /// The core pipeline builder Use utils.
    /// </summary>
    /// <typeparam name="TPipelineDelegate">The pipeline builder delegate type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    public interface IPipelineBuilderCoreUseUtils<TPipelineDelegate, out TPipelineBuilder> :
        IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder : IPipelineBuilderCoreUseUtils<TPipelineDelegate, TPipelineBuilder>
    {
        /// <summary>
        /// Adds the components to the pipeline builder.
        /// </summary>
        /// <param name="components">The components.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder Use(IEnumerable<Func<TPipelineDelegate, TPipelineDelegate>> components);
    }
}
