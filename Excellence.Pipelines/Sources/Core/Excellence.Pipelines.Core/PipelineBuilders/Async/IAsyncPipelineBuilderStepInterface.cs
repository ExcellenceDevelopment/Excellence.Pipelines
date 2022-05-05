using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.Core.PipelineSteps;

namespace Excellence.Pipelines.Core.PipelineBuilders.Async
{
    /// <summary>
    /// The pipeline builder with the possibility to add a pipeline steps.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderStepInterfaceFactory<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderCore<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderStepInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult>
    {
        /// <summary>
        /// Add the pipeline step.
        /// </summary>
        /// <param name="factory">The pipeline step factory.</param>
        /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder Use<TPipelineStep>(Func<TPipelineStep> factory) where TPipelineStep : IAsyncPipelineStep<TParam, TResult>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to add a pipeline steps.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult>
    {
        /// <summary>
        /// Add the pipeline step.
        /// Requires the service provider to be set.
        /// </summary>
        /// <param name="factory">The pipeline step factory.</param>
        /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder Use<TPipelineStep>(Func<IServiceProvider, TPipelineStep> factory) where TPipelineStep : IAsyncPipelineStep<TParam, TResult>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to add a pipeline steps.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult>
    {
        /// <summary>
        /// Add the pipeline step.
        /// Requires the service provider to be set.
        /// </summary>
        /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder Use<TPipelineStep>() where TPipelineStep : IAsyncPipelineStep<TParam, TResult>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to add a pipeline steps.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IAsyncPipelineBuilderStepInterface<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IAsyncPipelineBuilderStepInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>,
        IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>,
        IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IAsyncPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IAsyncPipeline<TParam, TResult> { }
}
