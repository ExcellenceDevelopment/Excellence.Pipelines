using System;
using System.Collections.Generic;
using System.Linq;

using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.PipelineBuilders.Shared
{
    public partial class PipelineBuilderCoreComplete<TPipelineDelegate, TPipelineBuilder>
    {
        /// <inheritdoc />
        public TPipelineBuilder Use(IEnumerable<Func<TPipelineDelegate, TPipelineDelegate>> components)
        {
            var componentList = components?.ToList();

            ExceptionUtils.Process(componentList, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(components)));

            foreach (var component in componentList!)
            {
                this.Use(component);
            }

            return (TPipelineBuilder)(object)this;
        }
    }
}
