using System;

using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.PipelineBuilders.Default;

namespace Excellence.Pipelines.PipelineBuilders
{
    /// <inheritdoc cref="IPipelineBuilder{TParam, TResult}"/>
    public class PipelineBuilder<TParam, TResult> :
        PipelineBuilderComplete<TParam, TResult, IPipelineBuilder<TParam, TResult>, IPipeline<TParam, TResult>>,
        IPipelineBuilder<TParam, TResult>
    {
        public PipelineBuilder(IServiceProvider? serviceProvider = null) : base(serviceProvider) { }
    }
}
