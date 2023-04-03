using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Core.PipelineConditions;

namespace Excellence.Pipelines.Core.PipelineBuilders.Default;

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam, TPipelineBuilder> :
    IPipelineBuilderCore<Action<TParam>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and the main pipeline is NOT executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="pipelineConditionFactory">The pipeline builder condition factory.</param>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder BranchWhen<TPipelineCondition>
    (
        Func<TPipelineCondition> pipelineConditionFactory,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<TPipelineBuilder> branchPipelineBuilderFactory
    ) where TPipelineCondition : class, IPipelineCondition<TParam>;
}

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam, TPipelineBuilder> :
    IPipelineBuilderCore<Action<TParam>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and the main pipeline is NOT executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="pipelineConditionFactory">The pipeline builder condition factory.</param>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder BranchWhen<TPipelineCondition>
    (
        Func<IServiceProvider, TPipelineCondition> pipelineConditionFactory,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
    ) where TPipelineCondition : class, IPipelineCondition<TParam>;
}

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam, out TPipelineBuilder> :
    IPipelineBuilderCore<Action<TParam>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and the main pipeline is NOT executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder BranchWhen<TPipelineCondition>
    (
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration
    ) where TPipelineCondition : class, IPipelineCondition<TParam>;
}

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderBranchWhenConditionInterface<TParam, TPipelineBuilder> :
    IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam, TPipelineBuilder>,
    IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam, TPipelineBuilder>,
    IPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderBranchWhenConditionInterface<TParam, TPipelineBuilder> { }
