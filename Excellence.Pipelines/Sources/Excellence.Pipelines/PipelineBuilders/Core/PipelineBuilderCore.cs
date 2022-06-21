using System;
using System.Collections.Generic;

using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.PipelineBuilders.Core
{
    /// <inheritdoc />
    public class PipelineBuilderCore<TPipelineDelegate, TPipelineBuilder> :
        IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder : IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>
    {
        protected IList<Func<TPipelineDelegate, TPipelineDelegate>> Components { get; set; } =
            new List<Func<TPipelineDelegate, TPipelineDelegate>>();

        protected TPipelineDelegate? Target { get; set; }

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
        public virtual TPipelineDelegate BuildPipeline()
        {
            ExceptionUtils.Process
            (
                this.Target,
                ExceptionUtils.IsNull,
                () => new InvalidOperationException($"The {this.GetType()} does not have a target.")
            );

            var next = this.Target!;

            for (var index = this.Components.Count - 1; index >= 0; index--)
            {
                next = this.Components[index].Invoke(next);
            }

            return next;
        }
    }
}
