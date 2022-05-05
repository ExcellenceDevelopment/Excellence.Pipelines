using System;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.Core.Pipelines;

namespace Excellence.Pipelines.Core.PipelineBuilders.Default
{
    /// <summary>
    /// The pipeline builder with all available features
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderFromDelegate<Func<TParam, TResult>, TPipelineBuilder, TPipeline>,
        IPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder, TPipeline>,
        IPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder, TPipeline>,
        IPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult> { }
}
