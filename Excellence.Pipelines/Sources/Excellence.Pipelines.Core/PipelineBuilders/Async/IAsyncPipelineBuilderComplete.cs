using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Core.PipelineBuilders.Async
{
    /// <summary>
    /// The pipeline builder with all available features
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    public interface IAsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder> :
        IPipelineBuilderCore<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IPipelineBuilderCoreUtils<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>,
        IAsyncPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder>,
        IAsyncPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder>,
        IAsyncPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder>
        where TPipelineBuilder : IAsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder> { }
}
