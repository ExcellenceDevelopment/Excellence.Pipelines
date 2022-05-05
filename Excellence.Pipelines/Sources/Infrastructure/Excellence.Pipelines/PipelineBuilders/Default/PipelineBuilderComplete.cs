using System;

using Excellence.Pipelines.Core.PipelineBuilders.Default;
using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.PipelineBuilders.Shared;
using Excellence.Pipelines.Pipelines;

namespace Excellence.Pipelines.PipelineBuilders.Default
{
    /// <inheritdoc cref="IPipelineBuilderComplete{TParam, TResult, TPipelineBuilder, TPipeline}"/>
    public abstract partial class PipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline> :
        PipelineBuilderFromDelegate<Func<TParam, TResult>, TPipelineBuilder, TPipeline>,
        IPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        protected PipelineBuilderComplete(IServiceProvider? serviceProvider = null) : base(serviceProvider) { }

        protected override TPipeline CreatePipeline(Func<TParam, TResult> pipelineStartDelegate) =>
            (TPipeline)(object)new Pipeline<TParam, TResult>(pipelineStartDelegate);
    }
}
