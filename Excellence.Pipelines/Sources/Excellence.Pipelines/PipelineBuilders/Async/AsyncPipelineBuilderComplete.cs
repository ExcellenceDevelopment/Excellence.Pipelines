using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Async;
using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.PipelineBuilders.Shared;

namespace Excellence.Pipelines.PipelineBuilders.Async
{
    /// <inheritdoc cref="IPipelineBuilderCore{TPipelineDelegate, TPipelineBuilder} " />
    /// <inheritdoc cref="IPipelineBuilderCoreUtils{TPipelineDelegate, TPipelineBuilder} " />
    /// <inheritdoc cref="IPipelineBuilderCoreUseUtils{TPipelineDelegate, TPipelineBuilder} " />
    /// <inheritdoc cref="IAsyncPipelineBuilderStepInterface{TParam, TResult, TPipelineBuilder} " />
    /// <inheritdoc cref="IAsyncPipelineBuilderUseWhen{TParam, TResult, TPipelineBuilder} " />
    /// <inheritdoc cref="IAsyncPipelineBuilderBranchWhen{TParam, TResult, TPipelineBuilder} " />
    public partial class AsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder> :
        PipelineBuilderCoreComplete<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IPipelineBuilderCore<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IPipelineBuilderCoreUtils<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IAsyncPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder>,
        IAsyncPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder>,
        IAsyncPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder>
        where TPipelineBuilder : IPipelineBuilderCore<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IPipelineBuilderCoreUtils<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IPipelineBuilderCoreUseUtils<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IAsyncPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder>,
        IAsyncPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder>,
        IAsyncPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder>
    {
        public AsyncPipelineBuilderComplete(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }
}
