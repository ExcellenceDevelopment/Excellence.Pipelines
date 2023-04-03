namespace Excellence.Pipelines.Core.PipelineBuilders.Async;

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderBranchWhen<TParam, TPipelineBuilder> :
    IAsyncPipelineBuilderBranchWhenConditionPredicate<TParam, TPipelineBuilder>,
    IAsyncPipelineBuilderBranchWhenConditionInterface<TParam, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderBranchWhen<TParam, TPipelineBuilder> { }
