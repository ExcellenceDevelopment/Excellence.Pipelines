using Excellence.Pipelines.Core.PipelineBuilders.Async;
using Excellence.Pipelines.Core.PipelineBuilders.Core;

namespace Excellence.Pipelines.Core.PipelineBuilders;

/// <summary>
/// The async pipeline builder.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
public interface IAsyncPipelineBuilder<TParam, TResult> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task<TResult>>, IAsyncPipelineBuilder<TParam, TResult>>,
    IPipelineBuilderCoreUtils<Func<TParam, CancellationToken, Task<TResult>>, IAsyncPipelineBuilder<TParam, TResult>>,
    IPipelineBuilderCoreUseUtils<Func<TParam, CancellationToken, Task<TResult>>, IAsyncPipelineBuilder<TParam, TResult>>,
    IAsyncPipelineBuilderStepInterface<TParam, TResult, IAsyncPipelineBuilder<TParam, TResult>>,
    IAsyncPipelineBuilderUseWhen<TParam, TResult, IAsyncPipelineBuilder<TParam, TResult>>,
    IAsyncPipelineBuilderBranchWhen<TParam, TResult, IAsyncPipelineBuilder<TParam, TResult>> { }