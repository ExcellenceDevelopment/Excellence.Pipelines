using System;

using Excellence.Pipelines.Core.PipelineSteps;

namespace Excellence.Pipelines.PipelineBuilders.Default
{
    public partial class PipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
    {
        /// <inheritdoc />
        public virtual TPipelineBuilder Use<TPipelineStep>(Func<TPipelineStep> pipelineStepFactory) where TPipelineStep : class, IPipelineStep<TParam, TResult>
        {
            var instance = this.GetFromFactory(pipelineStepFactory);

            return this.UsePipelineStep(instance);
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder Use<TPipelineStep>(Func<IServiceProvider, TPipelineStep> pipelineStepFactory) where TPipelineStep : class, IPipelineStep<TParam, TResult>
        {
            var pipelineStepInstance = this.GetFromFactory(pipelineStepFactory);

            return this.UsePipelineStep(pipelineStepInstance);
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder Use<TPipelineStep>() where TPipelineStep : class, IPipelineStep<TParam, TResult>
        {
            var instance = this.GetFromServiceProvider<TPipelineStep>();

            return this.UsePipelineStep(instance);
        }

        protected virtual TPipelineBuilder UsePipelineStep<TPipelineStep>(TPipelineStep pipelineStep) where TPipelineStep : class, IPipelineStep<TParam, TResult>
        {
            ArgumentNullException.ThrowIfNull(pipelineStep);

            Func<Func<TParam, TResult>, Func<TParam, TResult>> component =
                next =>
                    (param) => pipelineStep.Invoke(param, next);

            return this.Use(component);
        }
    }
}
