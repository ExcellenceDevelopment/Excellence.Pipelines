using System.Threading;
using System.Threading.Tasks;

namespace Excellence.Pipelines.Core.Pipelines
{
    /// <summary>
    /// The async pipeline.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    public interface IAsyncPipeline<in TParam, TResult>
    {
        /// <summary>
        /// Invokes the pipeline.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The async pipeline result.</returns>
        public Task<TResult> InvokeAsync(TParam param, CancellationToken cancellationToken = default);
    }
}
