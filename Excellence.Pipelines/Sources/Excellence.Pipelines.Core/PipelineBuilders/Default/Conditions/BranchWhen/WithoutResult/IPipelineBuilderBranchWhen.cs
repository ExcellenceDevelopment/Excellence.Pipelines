namespace Excellence.Pipelines.Core.PipelineBuilders.Default;

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderBranchWhen<TParam, TPipelineBuilder> :
    IPipelineBuilderBranchWhenConditionPredicate<TParam, TPipelineBuilder>,
    IPipelineBuilderBranchWhenConditionInterface<TParam, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderBranchWhen<TParam, TPipelineBuilder> { }
