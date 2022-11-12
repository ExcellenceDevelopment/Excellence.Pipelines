using System;

using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.PipelineBuilders;

namespace Excellence.Pipelines.PipelineBuilderFactories
{
    /// <inheritdoc />
    public class AsyncPipelineBuilderFactory : IAsyncPipelineBuilderFactory
    {
        protected IServiceProvider ServiceProvider { get; }

        public AsyncPipelineBuilderFactory(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider);

            this.ServiceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public virtual IAsyncPipelineBuilder<TParam, TResult> CreateAsyncPipelineBuilder<TParam, TResult>() =>
            new AsyncPipelineBuilder<TParam, TResult>(this.ServiceProvider);
    }
}
