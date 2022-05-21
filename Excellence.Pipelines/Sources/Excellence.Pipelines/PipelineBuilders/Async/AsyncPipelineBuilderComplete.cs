using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Async;
using Excellence.Pipelines.PipelineBuilders.Shared;

namespace Excellence.Pipelines.PipelineBuilders.Async
{
    /// <inheritdoc cref="IAsyncPipelineBuilderComplete{TParam, TResult, TPipelineBuilder}"/>
    public partial class AsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder> :
        PipelineBuilderCoreUtils<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IAsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
        where TPipelineBuilder : IAsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
    {
        public AsyncPipelineBuilderComplete(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }
}
