using System;

using Excellence.Pipelines.Core.PipelineBuilders.Default;
using Excellence.Pipelines.PipelineBuilders.Shared;

namespace Excellence.Pipelines.PipelineBuilders.Default
{
    /// <inheritdoc cref="IPipelineBuilderComplete{TParam, TResult, TPipelineBuilder}"/>
    public partial class PipelineBuilderComplete<TParam, TResult, TPipelineBuilder> :
        PipelineBuilderCoreUtils<Func<TParam, TResult>, TPipelineBuilder>,
        IPipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
        where TPipelineBuilder : IPipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
    {
        public PipelineBuilderComplete(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }
}
