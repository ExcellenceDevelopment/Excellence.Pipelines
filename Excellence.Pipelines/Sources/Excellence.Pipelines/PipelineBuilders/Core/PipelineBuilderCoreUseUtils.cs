namespace Excellence.Pipelines.PipelineBuilders.Core
{
    public partial class PipelineBuilderCoreComplete<TPipelineDelegate, TPipelineBuilder>
    {
        /// <inheritdoc />
        public TPipelineBuilder Use(IEnumerable<Func<TPipelineDelegate, TPipelineDelegate>> components)
        {
            ArgumentNullException.ThrowIfNull(components);

            foreach (var component in components)
            {
                this.Use(component);
            }

            return (TPipelineBuilder)(object)this;
        }
    }
}
