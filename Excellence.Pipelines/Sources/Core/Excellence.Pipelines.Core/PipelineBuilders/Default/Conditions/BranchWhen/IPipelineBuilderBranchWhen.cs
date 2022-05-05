using Excellence.Pipelines.Core.Pipelines;

namespace Excellence.Pipelines.Core.PipelineBuilders.Default
{
    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderBranchWhenConditionPredicate<TParam, TResult, TPipelineBuilder, TPipeline>,
        IPipelineBuilderBranchWhenConditionInterface<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult> { }
}
