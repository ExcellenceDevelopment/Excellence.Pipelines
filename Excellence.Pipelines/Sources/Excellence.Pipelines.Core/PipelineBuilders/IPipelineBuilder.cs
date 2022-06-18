using System;

using Excellence.Pipelines.Core.PipelineBuilders.Default;
using Excellence.Pipelines.Core.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Core.PipelineBuilders
{
    /// <summary>
    /// The pipeline builder.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    public interface IPipelineBuilder<TParam, TResult> :
        IPipelineBuilderCore<Func<TParam, TResult>, IPipelineBuilder<TParam, TResult>>,
        IPipelineBuilderCoreUtils<Func<TParam, TResult>, IPipelineBuilder<TParam, TResult>>,
        IPipelineBuilderCoreUseUtils<Func<TParam, TResult>, IPipelineBuilder<TParam, TResult>>,
        IPipelineBuilderStepInterface<TParam, TResult, IPipelineBuilder<TParam, TResult>>,
        IPipelineBuilderUseWhen<TParam, TResult, IPipelineBuilder<TParam, TResult>>,
        IPipelineBuilderBranchWhen<TParam, TResult, IPipelineBuilder<TParam, TResult>> { }
}
