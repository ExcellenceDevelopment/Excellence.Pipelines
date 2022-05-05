using System;

using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.PipelineBuilders;

namespace Excellence.Pipelines.PipelineBuilderFactories
{
    /// <inheritdoc />
    public class PipelineBuilderFactory : IPipelineBuilderFactory
    {
        /// <inheritdoc />
        public virtual IPipelineBuilder<TParam, TResult> Create<TParam, TResult>(IServiceProvider? serviceProvider = null) =>
            new PipelineBuilder<TParam, TResult>(serviceProvider);
    }
}
