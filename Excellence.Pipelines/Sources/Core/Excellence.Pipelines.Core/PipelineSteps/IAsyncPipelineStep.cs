using System;
using System.Threading;
using System.Threading.Tasks;

namespace Excellence.Pipelines.Core.PipelineSteps
{
    /// <summary>
    /// The async pipeline step.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    public interface IAsyncPipelineStep<TParam, TResult>
    {
        /// <summary>
        /// Executes the pipeline step logic.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="next">The pipeline next step delegate.</param>
        /// <returns>The result.</returns>
        public Task<TResult> InvokeAsync(TParam param, CancellationToken cancellationToken, Func<TParam, CancellationToken, Task<TResult>> next);
    }
}
