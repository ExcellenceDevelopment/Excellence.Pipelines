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
            var componentCollection = components?.ToList();

            ExceptionUtils.Process(componentCollection, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(components)));

            foreach (var component in componentCollection!)
            {
                this.Use(component);
            }

            return (TPipelineBuilder)(object)this;
        }
    }
}
