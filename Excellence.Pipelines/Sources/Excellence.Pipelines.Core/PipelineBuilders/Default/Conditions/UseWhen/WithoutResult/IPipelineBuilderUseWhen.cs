namespace Excellence.Pipelines.Core.PipelineBuilders.Default;

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderUseWhen<TParam, TPipelineBuilder> :
    IPipelineBuilderUseWhenConditionPredicate<TParam, TPipelineBuilder>,
    IPipelineBuilderUseWhenConditionInterface<TParam, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderUseWhen<TParam, TPipelineBuilder> { }
