using System;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;

namespace Excellence.Pipelines.PipelineBuilders.Shared
{
    public partial class PipelineBuilderCoreComplete<TPipelineDelegate, TPipelineBuilder> :
        PipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>,
        IPipelineBuilderCoreUtils<TPipelineDelegate, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<TPipelineDelegate, TPipelineBuilder>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder :
        IPipelineBuilderCoreUtils<TPipelineDelegate, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<TPipelineDelegate, TPipelineBuilder> { }
}
