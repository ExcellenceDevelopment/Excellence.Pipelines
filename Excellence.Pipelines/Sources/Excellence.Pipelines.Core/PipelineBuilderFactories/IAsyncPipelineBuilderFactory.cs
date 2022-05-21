using Excellence.Pipelines.Core.PipelineBuilders;

namespace Excellence.Pipelines.Core.PipelineBuilderFactories
{
    /// <summary>
    /// The pipeline builder factory.
    /// </summary>
    public interface IAsyncPipelineBuilderFactory
    {
        /// <summary>
        /// Creates the new async pipeline builder instance.
        /// </summary>
        /// <typeparam name="TParam">The parameter type.</typeparam>
        /// <typeparam name="TResult">The result type.</typeparam>
        /// <returns>The pipeline builder.</returns>
        public IAsyncPipelineBuilder<TParam, TResult> CreateAsyncPipelineBuilder<TParam, TResult>();
    }
}
