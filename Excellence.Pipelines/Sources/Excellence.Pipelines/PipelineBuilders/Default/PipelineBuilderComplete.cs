using System;

using Excellence.Pipelines.Core.PipelineBuilders.Default;
using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.PipelineBuilders.Shared;

namespace Excellence.Pipelines.PipelineBuilders.Default
{
    /// <inheritdoc cref="IPipelineBuilderCore{TPipelineDelegate, TPipelineBuilder} " />
    /// <inheritdoc cref="IPipelineBuilderCoreUtils{TPipelineDelegate, TPipelineBuilder} " />
    /// <inheritdoc cref="IPipelineBuilderCoreUseUtils{TPipelineDelegate, TPipelineBuilder} " />
    /// <inheritdoc cref="IPipelineBuilderStepInterface{TParam, TResult, TPipelineBuilder} " />
    /// <inheritdoc cref="IPipelineBuilderUseWhen{TParam, TResult, TPipelineBuilder} " />
    /// <inheritdoc cref="IPipelineBuilderBranchWhen{TParam, TResult, TPipelineBuilder} " />
    public partial class PipelineBuilderComplete<TParam, TResult, TPipelineBuilder> :
        PipelineBuilderCoreComplete<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderCore<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderCoreUtils<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder>,
        IPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder>,
        IPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder>
        where TPipelineBuilder : IPipelineBuilderCore<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderCoreUtils<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder>,
        IPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder>,
        IPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder>
    {
        public PipelineBuilderComplete(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }
}
