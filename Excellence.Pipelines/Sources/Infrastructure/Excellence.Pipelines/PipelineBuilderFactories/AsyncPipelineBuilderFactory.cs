using System;

using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.PipelineBuilders;

namespace Excellence.Pipelines.PipelineBuilderFactories
{
    /// <inheritdoc />
    public class AsyncPipelineBuilderFactory : IAsyncPipelineBuilderFactory
    {
        /// <inheritdoc />
        public virtual IAsyncPipelineBuilder<TParam, TResult> Create<TParam, TResult>(IServiceProvider? serviceProvider = null) =>
            new AsyncPipelineBuilder<TParam, TResult>(serviceProvider);
    }
}
