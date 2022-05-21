namespace Excellence.Pipelines.Core.PipelineBuilders.Async
{
    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    public interface IAsyncPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder> :
        IAsyncPipelineBuilderUseWhenConditionPredicate<TParam, TResult, TPipelineBuilder>,
        IAsyncPipelineBuilderUseWhenConditionInterface<TParam, TResult, TPipelineBuilder>
        where TPipelineBuilder : IAsyncPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder> { }
}
