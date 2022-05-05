using System;

namespace Excellence.Pipelines.PipelineBuilders.Shared
{
    public partial class PipelineBuilderFromDelegate<TPipelineDelegate, TPipelineBuilder, TPipeline>
    {
        /// <inheritdoc />
        public IServiceProvider? ServiceProvider { get; protected set; }

        /// <inheritdoc />
        public virtual TPipelineBuilder UseServiceProvider(IServiceProvider? serviceProvider)
        {
            this.ServiceProvider = serviceProvider;

            return (TPipelineBuilder)(object)this;
        }
    }
}
