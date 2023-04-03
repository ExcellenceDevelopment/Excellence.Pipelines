using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Core.PipelineSteps;

namespace Excellence.Pipelines.Core.PipelineBuilders.Default;

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderStepInterfaceFactory<TParam, TResult, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, TResult>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderStepInterfaceFactory<TParam, TResult, TPipelineBuilder>
{
    /// <summary>
    /// Add the pipeline step.
    /// </summary>
    /// <param name="factory">The pipeline step factory.</param>
    /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder Use<TPipelineStep>(Func<TPipelineStep> factory) where TPipelineStep : class, IPipelineStep<TParam, TResult>;
}

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, TResult>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder>
{
    /// <summary>
    /// Add the pipeline step.
    /// </summary>
    /// <param name="factory">The pipeline step factory.</param>
    /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder Use<TPipelineStep>(Func<IServiceProvider, TPipelineStep> factory) where TPipelineStep : class, IPipelineStep<TParam, TResult>;
}

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, TResult>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, TPipelineBuilder>
{
    /// <summary>
    /// Add the pipeline step.
    /// </summary>
    /// <typeparam name="TPipelineStep">The pipeline step type.</typeparam>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder Use<TPipelineStep>() where TPipelineStep : class, IPipelineStep<TParam, TResult>;
}

/// <summary>
/// The pipeline builder with the possibility to add a pipeline steps.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderStepInterface<TParam, TResult, out TPipelineBuilder> :
    IPipelineBuilderStepInterfaceFactory<TParam, TResult, TPipelineBuilder>,
    IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder>,
    IPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderStepInterface<TParam, TResult, TPipelineBuilder> { }
