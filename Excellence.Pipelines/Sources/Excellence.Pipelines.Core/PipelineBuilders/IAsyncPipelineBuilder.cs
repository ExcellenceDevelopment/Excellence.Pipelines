using Excellence.Pipelines.Core.PipelineBuilders.Async;

namespace Excellence.Pipelines.Core.PipelineBuilders
{
    /// <summary>
    /// The async pipeline builder.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    public interface IAsyncPipelineBuilder<TParam, TResult> :
        IAsyncPipelineBuilderComplete<TParam, TResult, IAsyncPipelineBuilder<TParam, TResult>> { }
}
