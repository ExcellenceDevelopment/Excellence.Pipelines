namespace Excellence.Pipelines.Core.PipelineBuilders.Default;

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder> :
    IPipelineBuilderUseWhenConditionPredicate<TParam, TResult, TPipelineBuilder>,
    IPipelineBuilderUseWhenConditionInterface<TParam, TResult, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder> { }