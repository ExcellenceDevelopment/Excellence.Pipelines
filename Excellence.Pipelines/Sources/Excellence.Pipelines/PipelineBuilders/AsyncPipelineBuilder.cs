using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.PipelineBuilders.Async;

namespace Excellence.Pipelines.PipelineBuilders;

/// <inheritdoc cref="IAsyncPipelineBuilder{TParam}"/>
public class AsyncPipelineBuilder<TParam> :
    AsyncPipelineBuilderComplete<TParam, IAsyncPipelineBuilder<TParam>>,
    IAsyncPipelineBuilder<TParam>
{
    public AsyncPipelineBuilder(IServiceProvider serviceProvider) : base(serviceProvider) { }
}

/// <inheritdoc cref="IAsyncPipelineBuilder{TParam ,TResult}"/>
public class AsyncPipelineBuilder<TParam, TResult> :
    AsyncPipelineBuilderComplete<TParam, TResult, IAsyncPipelineBuilder<TParam, TResult>>,
    IAsyncPipelineBuilder<TParam, TResult>
{
    public AsyncPipelineBuilder(IServiceProvider serviceProvider) : base(serviceProvider) { }
}
