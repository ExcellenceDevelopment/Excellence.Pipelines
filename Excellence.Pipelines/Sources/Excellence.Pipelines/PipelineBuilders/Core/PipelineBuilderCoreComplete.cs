using System;

using Excellence.Pipelines.Core.PipelineBuilders.Core;

namespace Excellence.Pipelines.PipelineBuilders.Core
{
    /// <inheritdoc cref="IPipelineBuilderCore{TPipelineDelegate,TPipelineBuilder}" />
    /// <inheritdoc cref="IPipelineBuilderCoreUtils{TPipelineDelegate,TPipelineBuilder}" />
    /// <inheritdoc cref="IPipelineBuilderCoreUseUtils{TPipelineDelegate,TPipelineBuilder}" />
    public partial class PipelineBuilderCoreComplete<TPipelineDelegate, TPipelineBuilder> :
        PipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>,
        IPipelineBuilderCoreUtils<TPipelineDelegate, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<TPipelineDelegate, TPipelineBuilder>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder :
        IPipelineBuilderCoreUtils<TPipelineDelegate, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<TPipelineDelegate, TPipelineBuilder> { }
}
