﻿using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Core.PipelineSteps;

namespace Excellence.Pipelines.Core.PipelineBuilders.Async;

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderStepInterfaceFactory<TParam, TResult, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderStepInterfaceFactory<TParam, TResult, TPipelineBuilder>
{
    /// <summary>
    /// Add the pipeline step.
    /// </summary>
    /// <param name="factory">The pipeline step factory.</param>
    /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder Use<TPipelineStep>(Func<TPipelineStep> factory) where TPipelineStep : class, IAsyncPipelineStep<TParam, TResult>;
}

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder>
{
    /// <summary>
    /// Add the pipeline step.
    /// </summary>
    /// <param name="factory">The pipeline step factory.</param>
    /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder Use<TPipelineStep>(Func<IServiceProvider, TPipelineStep> factory) where TPipelineStep : class, IAsyncPipelineStep<TParam, TResult>;
}

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task<TResult>>, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, TPipelineBuilder>
{
    /// <summary>
    /// Add the pipeline step.
    /// </summary>
    /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder Use<TPipelineStep>() where TPipelineStep : class, IAsyncPipelineStep<TParam, TResult>;
}

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderStepInterface<TParam, TResult, out TPipelineBuilder> :
    IAsyncPipelineBuilderStepInterfaceFactory<TParam, TResult, TPipelineBuilder>,
    IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder>,
    IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder> { }