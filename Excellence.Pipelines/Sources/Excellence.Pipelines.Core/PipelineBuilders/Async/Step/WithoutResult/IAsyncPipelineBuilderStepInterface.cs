using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Core.PipelineSteps;

namespace Excellence.Pipelines.Core.PipelineBuilders.Async;

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderStepInterfaceFactory<TParam, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task>, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderStepInterfaceFactory<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Add the pipeline step.
    /// </summary>
    /// <param name="factory">The pipeline step factory.</param>
    /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder Use<TPipelineStep>(Func<TPipelineStep> factory) where TPipelineStep : class, IAsyncPipelineStep<TParam>;
}

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task>, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Add the pipeline step.
    /// </summary>
    /// <param name="factory">The pipeline step factory.</param>
    /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder Use<TPipelineStep>(Func<IServiceProvider, TPipelineStep> factory) where TPipelineStep : class, IAsyncPipelineStep<TParam>;
}

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task>, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Add the pipeline step.
    /// </summary>
    /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder Use<TPipelineStep>() where TPipelineStep : class, IAsyncPipelineStep<TParam>;
}

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderStepInterface<TParam, out TPipelineBuilder> :
    IAsyncPipelineBuilderStepInterfaceFactory<TParam, TPipelineBuilder>,
    IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TPipelineBuilder>,
    IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderStepInterface<TParam, TPipelineBuilder> { }
