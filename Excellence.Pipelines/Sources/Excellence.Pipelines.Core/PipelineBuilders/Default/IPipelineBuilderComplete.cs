using System;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Core.PipelineBuilders.Default
{
    /// <summary>
    /// The pipeline builder with all available features
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    public interface IPipelineBuilderComplete<TParam, TResult, TPipelineBuilder> :
        IPipelineBuilderCore<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderCoreUtils<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder>,
        IPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder>,
        IPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder>
        where TPipelineBuilder : IPipelineBuilderComplete<TParam, TResult, TPipelineBuilder> { }
}
