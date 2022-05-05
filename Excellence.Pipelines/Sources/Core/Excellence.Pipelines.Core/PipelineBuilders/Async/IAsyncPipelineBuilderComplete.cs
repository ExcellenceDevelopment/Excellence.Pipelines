using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.Core.Pipelines;

namespace Excellence.Pipelines.Core.PipelineBuilders.Async
{
    /// <summary>
    /// The pipeline builder with all available features
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderFromDelegate<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder, TPipeline>,
        IAsyncPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder, TPipeline>,
        IAsyncPipelineBuilderUseWhen<TParam, TResult, TPipelineBuilder, TPipeline>,
        IAsyncPipelineBuilderBranchWhen<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult> { }
}
