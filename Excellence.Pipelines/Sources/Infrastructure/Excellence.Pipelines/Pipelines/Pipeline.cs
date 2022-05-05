using System;

using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.Pipelines
{
    /// <inheritdoc />
    public class Pipeline<TParam, TResult> : IPipeline<TParam, TResult>
    {
        protected Func<TParam, TResult> PipelineDelegate { get; }

        public Pipeline(Func<TParam, TResult> pipelineDelegate)
        {
            ExceptionUtils.Process(pipelineDelegate, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(pipelineDelegate)));

            this.PipelineDelegate = pipelineDelegate;
        }

        /// <inheritdoc />
        public virtual TResult Invoke(TParam param) => this.PipelineDelegate.Invoke(param);
    }
}
