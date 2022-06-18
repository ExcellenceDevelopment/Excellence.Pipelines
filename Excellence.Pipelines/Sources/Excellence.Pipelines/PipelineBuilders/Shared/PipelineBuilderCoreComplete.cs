using System;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;

namespace Excellence.Pipelines.PipelineBuilders.Shared
{
    /// <inheritdoc cref="Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore{TPipelineDelegate, TPipelineBuilder}" />
    /// <inheritdoc cref="Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCoreUtils{TPipelineDelegate, TPipelineBuilder}" />
    /// <inheritdoc cref="Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCoreUseUtils{TPipelineDelegate, TPipelineBuilder}" />
    public partial class PipelineBuilderCoreComplete<TPipelineDelegate, TPipelineBuilder> :
        PipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>,
        IPipelineBuilderCoreUtils<TPipelineDelegate, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<TPipelineDelegate, TPipelineBuilder>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder :
        IPipelineBuilderCoreUtils<TPipelineDelegate, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<TPipelineDelegate, TPipelineBuilder> { }
}
