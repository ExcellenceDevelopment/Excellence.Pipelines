using System;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.Core.PipelineSteps;

namespace Excellence.Pipelines.Core.PipelineBuilders.Default
{
    /// <summary>
    /// The pipeline builder with the possibility to add a pipeline steps.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderStepInterfaceFactory<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderCore<Func<TParam, TResult>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderStepInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        /// <summary>
        /// Add the pipeline step.
        /// </summary>
        /// <param name="factory">The pipeline step factory.</param>
        /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder Use<TPipelineStep>(Func<TPipelineStep> factory) where TPipelineStep : IPipelineStep<TParam, TResult>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to add a pipeline steps.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, TResult>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        /// <summary>
        /// Add the pipeline step.
        /// Requires the service provider to be set.
        /// </summary>
        /// <param name="factory">The pipeline step factory.</param>
        /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder Use<TPipelineStep>(Func<IServiceProvider, TPipelineStep> factory) where TPipelineStep : IPipelineStep<TParam, TResult>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to add a pipeline steps.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, TResult>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        /// <summary>
        /// Add the pipeline step.
        /// Requires the service provider to be set.
        /// </summary>
        /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder Use<TPipelineStep>() where TPipelineStep : IPipelineStep<TParam, TResult>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to add a pipeline steps.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderStepInterface<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderStepInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>,
        IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>,
        IPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult> { }
}
