using Excellence.Pipelines.Core.PipelineBuilders.Core;

namespace Excellence.Pipelines.PipelineBuilders.Core
{
    /// <inheritdoc />
    public class PipelineBuilderCore<TPipelineDelegate, TPipelineBuilder> :
        IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder : class, IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>
    {
        protected IList<Func<TPipelineDelegate, TPipelineDelegate>> Components { get; set; } =
            new List<Func<TPipelineDelegate, TPipelineDelegate>>();

        protected TPipelineDelegate? Target { get; set; }

        /// <inheritdoc />
        public virtual TPipelineBuilder Use(Func<TPipelineDelegate, TPipelineDelegate> component)
        {
            ArgumentNullException.ThrowIfNull(component);

            this.Components.Add(component);

            return (TPipelineBuilder)(object)this;
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder UseTarget(TPipelineDelegate target)
        {
            ArgumentNullException.ThrowIfNull(target);

            this.Target = target;

            return (TPipelineBuilder)(object)this;
        }

        /// <inheritdoc />
        public virtual TPipelineDelegate BuildPipeline()
        {
            if (this.Target == null)
            {
                throw new InvalidOperationException($"The {this.GetType()} does not have a target.");
            }

            var next = this.Target!;

            for (var index = this.Components.Count - 1; index >= 0; index--)
            {
                next = this.Components[index].Invoke(next);
            }

            return next;
        }
    }
}
