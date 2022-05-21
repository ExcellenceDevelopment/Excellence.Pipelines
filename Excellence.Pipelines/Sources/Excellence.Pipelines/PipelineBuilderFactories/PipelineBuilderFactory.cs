using System;

using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.PipelineBuilders;
using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.PipelineBuilderFactories
{
    /// <inheritdoc />
    public class PipelineBuilderFactory : IPipelineBuilderFactory
    {
        protected IServiceProvider ServiceProvider { get; }

        public PipelineBuilderFactory(IServiceProvider serviceProvider)
        {
            ExceptionUtils.Process(serviceProvider, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(serviceProvider)));

            this.ServiceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public virtual IPipelineBuilder<TParam, TResult> CreatePipelineBuilder<TParam, TResult>() =>
            new PipelineBuilder<TParam, TResult>(this.ServiceProvider);
    }
}
