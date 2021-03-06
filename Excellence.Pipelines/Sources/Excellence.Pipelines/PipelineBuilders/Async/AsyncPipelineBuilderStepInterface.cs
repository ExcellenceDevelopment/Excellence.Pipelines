using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.PipelineBuilders.Async
{
    public partial class AsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
    {
        /// <inheritdoc />
        public virtual TPipelineBuilder Use<TPipelineStep>(Func<TPipelineStep> pipelineStepFactory) where TPipelineStep : IAsyncPipelineStep<TParam, TResult>
        {
            var instance = this.GetFromFactory(pipelineStepFactory);

            return this.UsePipelineStep(instance);
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder Use<TPipelineStep>(Func<IServiceProvider, TPipelineStep> pipelineStepFactory) where TPipelineStep : IAsyncPipelineStep<TParam, TResult>
        {
            var pipelineStepInstance = this.GetFromFactory(pipelineStepFactory);

            return this.UsePipelineStep(pipelineStepInstance);
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder Use<TPipelineStep>() where TPipelineStep : IAsyncPipelineStep<TParam, TResult>
        {
            var instance = this.GetFromServiceProvider<TPipelineStep>();

            return this.UsePipelineStep(instance);
        }

        protected virtual TPipelineBuilder UsePipelineStep<TPipelineStep>(TPipelineStep pipelineStep) where TPipelineStep : IAsyncPipelineStep<TParam, TResult>
        {
            ExceptionUtils.Process((object?)pipelineStep, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(pipelineStep)));

            Func<Func<TParam, CancellationToken, Task<TResult>>, Func<TParam, CancellationToken, Task<TResult>>> component =
                next => (param, cancellationToken) => pipelineStep.Invoke(param, cancellationToken, next);

            return this.Use(component);
        }
    }
}
