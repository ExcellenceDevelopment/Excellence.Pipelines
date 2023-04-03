using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.PipelineBuilders.Default;

namespace Excellence.Pipelines.PipelineBuilders;

/// <inheritdoc cref="IPipelineBuilder{TParam}"/>
public class PipelineBuilder<TParam> :
    PipelineBuilderComplete<TParam, IPipelineBuilder<TParam>>,
    IPipelineBuilder<TParam>
{
    public PipelineBuilder(IServiceProvider serviceProvider) : base(serviceProvider) { }
}

/// <inheritdoc cref="IPipelineBuilder{TParam, TResult}"/>
public class PipelineBuilder<TParam, TResult> :
    PipelineBuilderComplete<TParam, TResult, IPipelineBuilder<TParam, TResult>>,
    IPipelineBuilder<TParam, TResult>
{
    public PipelineBuilder(IServiceProvider serviceProvider) : base(serviceProvider) { }
}
