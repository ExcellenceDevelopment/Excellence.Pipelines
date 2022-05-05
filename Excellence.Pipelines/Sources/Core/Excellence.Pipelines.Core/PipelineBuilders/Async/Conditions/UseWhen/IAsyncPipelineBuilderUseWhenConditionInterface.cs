using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.Pipelines;

namespace Excellence.Pipelines.Core.PipelineBuilders.Async
{
    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderCore<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult>
    {
        /// <summary>
        /// Adds the pipeline branch with own configuration that is executed when the condition is met.
        /// When the condition is met the branch is executed and then the main pipeline is executed.
        /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
        /// </summary>
        /// <param name="pipelineConditionFactory">The pipeline builder condition factory.</param>
        /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
        /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder UseWhen<TPipelineCondition>
        (
            Func<TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : IAsyncPipelineCondition<TParam>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult>
    {
        /// <summary>
        /// Adds the pipeline branch with own configuration that is executed when the condition is met.
        /// When the condition is met the branch is executed and then the main pipeline is executed.
        /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
        /// Requires the service provider to be set.
        /// </summary>
        /// <param name="pipelineConditionFactory">The pipeline builder condition factory.</param>
        /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
        /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder UseWhen<TPipelineCondition>
        (
            Func<IServiceProvider, TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : IAsyncPipelineCondition<TParam>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult>
    {
        /// <summary>
        /// Adds the pipeline branch with own configuration that is executed when the condition is met.
        /// When the condition is met the branch is executed and then the main pipeline is executed.
        /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
        /// Requires the service provider to be set.
        /// </summary>
        /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder UseWhen<TPipelineCondition>
        (
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration
        ) where TPipelineCondition : IAsyncPipelineCondition<TParam>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderUseWhenConditionInterface<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>,
        IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>,
        IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderUseWhenConditionInterface<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult> { }
}
