using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Core.PipelineConditions;

namespace Excellence.Pipelines.Core.PipelineBuilders.Async;

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task>, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TPipelineBuilder>
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
    ) where TPipelineCondition : class, IAsyncPipelineCondition<TParam>;
}

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task>, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TPipelineBuilder>
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
        Func<IServiceProvider, TPipelineCondition> pipelineConditionFactory,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
    ) where TPipelineCondition : class, IAsyncPipelineCondition<TParam>;
}

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam, out TPipelineBuilder> :
    IPipelineBuilderCore<Func<TParam, CancellationToken, Task>, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and then the main pipeline is executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder UseWhen<TPipelineCondition>
    (
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration
    ) where TPipelineCondition : class, IAsyncPipelineCondition<TParam>;
}

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IAsyncPipelineBuilderUseWhenConditionInterface<TParam, TPipelineBuilder> :
    IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TPipelineBuilder>,
    IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TPipelineBuilder>,
    IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam, TPipelineBuilder>
    where TPipelineBuilder : class, IAsyncPipelineBuilderUseWhenConditionInterface<TParam, TPipelineBuilder> { }
