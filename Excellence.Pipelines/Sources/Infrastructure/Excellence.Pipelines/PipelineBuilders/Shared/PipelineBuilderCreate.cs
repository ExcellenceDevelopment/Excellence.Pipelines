using System;
using System.Collections.Generic;
using System.Linq;

namespace Excellence.Pipelines.PipelineBuilders.Shared
{
    public partial class PipelineBuilderFromDelegate<TPipelineDelegate, TPipelineBuilder, TPipeline>
    {
        /// <inheritdoc />
        public virtual TPipelineBuilder New()
        {
            var newInstance = (PipelineBuilderFromDelegate<TPipelineDelegate, TPipelineBuilder, TPipeline>)this.MemberwiseClone();
            newInstance.Components = new List<Func<TPipelineDelegate, TPipelineDelegate>>();
            newInstance.Target = null;
            newInstance.ServiceProvider = this.ServiceProvider;

            return (TPipelineBuilder)(object)newInstance;
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder Copy()
        {
            var newInstance = (PipelineBuilderFromDelegate<TPipelineDelegate, TPipelineBuilder, TPipeline>)this.MemberwiseClone();
            newInstance.Components = this.Components.Select(item => (Func<TPipelineDelegate, TPipelineDelegate>)item.Clone()).ToList();
            newInstance.Target = (TPipelineDelegate?)this.Target?.Clone();
            newInstance.ServiceProvider = this.ServiceProvider;

            return (TPipelineBuilder)(object)newInstance;
        }
    }
}
