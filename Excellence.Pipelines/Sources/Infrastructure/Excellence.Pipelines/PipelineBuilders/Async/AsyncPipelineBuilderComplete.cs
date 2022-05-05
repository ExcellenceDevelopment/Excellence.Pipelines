using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Async;
using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.PipelineBuilders.Shared;
using Excellence.Pipelines.Pipelines;

namespace Excellence.Pipelines.PipelineBuilders.Async
{
    /// <inheritdoc cref="IAsyncPipelineBuilderComplete{TParam, TResult, TPipelineBuilder, TPipeline}"/>
    public abstract partial class AsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline> :
        PipelineBuilderFromDelegate<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder, TPipeline>,
        IAsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult>
    {
        protected AsyncPipelineBuilderComplete(IServiceProvider? serviceProvider = null) : base(serviceProvider) { }

        protected override TPipeline CreatePipeline(Func<TParam, CancellationToken, Task<TResult>> pipelineStartDelegate) =>
            (TPipeline)(object)new AsyncPipeline<TParam, TResult>(pipelineStartDelegate);
    }
}
