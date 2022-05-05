using Excellence.Pipelines.Core.Pipelines;

namespace Excellence.Pipelines.Core.PipelineBuilders.Async
{
    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IAsyncPipelineBuilderUseWhenConditionPredicate<TParam, TResult, TPipelineBuilder, TPipeline>,
        IAsyncPipelineBuilderUseWhenConditionInterface<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult> { }
}
