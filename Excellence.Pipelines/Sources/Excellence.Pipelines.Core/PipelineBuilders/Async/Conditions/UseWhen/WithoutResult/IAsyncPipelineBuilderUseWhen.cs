namespace Excellence.Pipelines.Core.PipelineBuilders.Async;

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderUseWhen<TParam, TPipelineBuilder> :
    IAsyncPipelineBuilderUseWhenConditionPredicate<TParam, TPipelineBuilder>,
    IAsyncPipelineBuilderUseWhenConditionInterface<TParam, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderUseWhen<TParam, TPipelineBuilder> { }
