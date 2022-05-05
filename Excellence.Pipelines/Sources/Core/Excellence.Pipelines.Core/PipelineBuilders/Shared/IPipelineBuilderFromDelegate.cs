using System;

namespace Excellence.Pipelines.Core.PipelineBuilders.Shared
{
    /// <summary>
    /// The pipeline builder combining all the pipeline builder interfaces which accept pipeline delegate as type argument.
    /// </summary>
    /// <typeparam name="TPipelineDelegate">The pipeline builder delegate type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderFromDelegate<TPipelineDelegate, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder, TPipeline>,
        IPipelineBuilderCreate<TPipelineDelegate, TPipelineBuilder, TPipeline>,
        IPipelineBuilderServiceProvider<TPipelineDelegate, TPipelineBuilder, TPipeline>
        where TPipelineDelegate : Delegate
        where TPipelineBuilder : IPipelineBuilderFromDelegate<TPipelineDelegate, TPipelineBuilder, TPipeline> { }
}
