using System;
using System.Collections.Generic;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.PipelineBuilders.Shared
{
    /// <inheritdoc />
    public abstract partial class PipelineBuilderFromDelegate<TPipelineDelegate, TPipelineBuilder, TPipeline> :
        IPipelineBuilderFromDelegate<TPipelineDelegate, TPipelineBuilder, TPipeline>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder : IPipelineBuilderFromDelegate<TPipelineDelegate, TPipelineBuilder, TPipeline>
    {
        protected List<Func<TPipelineDelegate, TPipelineDelegate>> Components { get; set; } =
            new List<Func<TPipelineDelegate, TPipelineDelegate>>();

        protected TPipelineDelegate? Target { get; set; }

        protected PipelineBuilderFromDelegate(IServiceProvider? serviceProvider = null) => this.ServiceProvider = serviceProvider;

        /// <inheritdoc />
        public virtual TPipelineBuilder Use(Func<TPipelineDelegate, TPipelineDelegate> component)
        {
            ExceptionUtils.Process(component, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(component)));

            this.Components.Add(component);

            return (TPipelineBuilder)(object)this;
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder UseTarget(TPipelineDelegate target)
        {
            ExceptionUtils.Process(target, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(target)));

            this.Target = target;

            return (TPipelineBuilder)(object)this;
        }

        /// <inheritdoc />
        public virtual TPipeline BuildPipeline()
        {
            ExceptionUtils.Process
            (
                this.Target,
                ExceptionUtils.IsNull,
                () => new InvalidOperationException(ErrorMessageUtils.CreateNoTargetErrorMessage(this.GetType()))
            );

            var next = this.Target!;

            for (var a = this.Components.Count - 1; a >= 0; a--)
            {
                next = this.Components[a].Invoke(next);
            }

            return this.CreatePipeline(next);
        }

        protected abstract TPipeline CreatePipeline(TPipelineDelegate pipelineStartDelegate);
    }
}
