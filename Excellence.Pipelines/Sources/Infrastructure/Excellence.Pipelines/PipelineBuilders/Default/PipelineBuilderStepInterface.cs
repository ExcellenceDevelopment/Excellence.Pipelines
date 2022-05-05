using System;

using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.PipelineBuilders.Default
{
    public partial class PipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline>
    {
        /// <inheritdoc />
        public virtual TPipelineBuilder Use<TPipelineStep>(Func<TPipelineStep> pipelineStepFactory) where TPipelineStep : IPipelineStep<TParam, TResult>
        {
            var instance = this.GetFromFactory(pipelineStepFactory);

            return this.UsePipelineStep(instance);
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder Use<TPipelineStep>(Func<IServiceProvider, TPipelineStep> pipelineStepFactory) where TPipelineStep : IPipelineStep<TParam, TResult>
        {
            var pipelineStepInstance = this.GetFromFactory(pipelineStepFactory);

            return this.UsePipelineStep(pipelineStepInstance);
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder Use<TPipelineStep>() where TPipelineStep : IPipelineStep<TParam, TResult>
        {
            var instance = this.GetFromServiceProvider<TPipelineStep>();

            return this.UsePipelineStep(instance);
        }

        protected virtual TPipelineBuilder UsePipelineStep<TPipelineStep>(TPipelineStep pipelineStep) where TPipelineStep : IPipelineStep<TParam, TResult>
        {
            ExceptionUtils.Process((object?)pipelineStep, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(pipelineStep)));

            Func<Func<TParam, TResult>, Func<TParam, TResult>> component =
                next =>
                    (param) => pipelineStep.Invoke(param, next);

            return this.Use(component);
        }
    }
}
