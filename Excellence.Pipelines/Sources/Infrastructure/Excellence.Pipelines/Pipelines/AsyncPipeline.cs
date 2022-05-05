using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.Pipelines
{
    /// <inheritdoc />
    public class AsyncPipeline<TParam, TResult> : IAsyncPipeline<TParam, TResult>
    {
        protected Func<TParam, CancellationToken, Task<TResult>> PipelineDelegate { get; }

        public AsyncPipeline(Func<TParam, CancellationToken, Task<TResult>> pipelineDelegate)
        {
            ExceptionUtils.Process(pipelineDelegate, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(pipelineDelegate)));

            this.PipelineDelegate = pipelineDelegate;
        }

        /// <inheritdoc />
        public virtual Task<TResult> InvokeAsync(TParam param, CancellationToken cancellationToken = default) =>
            this.PipelineDelegate.Invoke(param, cancellationToken);
    }
}
