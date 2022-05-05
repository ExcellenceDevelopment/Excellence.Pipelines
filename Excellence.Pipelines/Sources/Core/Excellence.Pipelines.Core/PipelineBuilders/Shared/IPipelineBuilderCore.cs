﻿using System;

namespace Excellence.Pipelines.Core.PipelineBuilders.Shared
{
    /// <summary>
    /// The core pipeline builder.
    /// </summary>
    /// <typeparam name="TPipelineDelegate">The pipeline builder delegate type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderCore<TPipelineDelegate, out TPipelineBuilder, out TPipeline>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder : IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder, TPipeline>
    {
        /// <summary>
        /// Adds the component to the pipeline builder.
        /// </summary>
        /// <param name="component">The component.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder Use(Func<TPipelineDelegate, TPipelineDelegate> component);

        /// <summary>
        /// Sets the target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder UseTarget(TPipelineDelegate target);

        /// <summary>
        /// Builds the pipeline.
        /// </summary>
        /// <returns>The pipeline.</returns>
        public TPipeline BuildPipeline();
    }
}
