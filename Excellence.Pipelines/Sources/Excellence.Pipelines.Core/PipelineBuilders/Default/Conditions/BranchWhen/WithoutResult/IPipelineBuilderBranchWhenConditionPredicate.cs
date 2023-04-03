using Excellence.Pipelines.Core.PipelineBuilders.Core;

namespace Excellence.Pipelines.Core.PipelineBuilders.Default;

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderBranchWhenConditionPredicateFactory<TParam, TPipelineBuilder> :
    IPipelineBuilderCore<Action<TParam>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderBranchWhenConditionPredicateFactory<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and the main pipeline is NOT executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder BranchWhen
    (
        Func<TParam, bool> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<TPipelineBuilder> branchPipelineBuilderFactory
    );
}

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider<TParam, TPipelineBuilder> :
    IPipelineBuilderCore<Action<TParam>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and the main pipeline is NOT executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder BranchWhen
    (
        Func<TParam, bool> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
    );
}

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam, out TPipelineBuilder> :
    IPipelineBuilderCore<Action<TParam>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and the main pipeline is NOT executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder BranchWhen
    (
        Func<TParam, bool> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration
    );
}

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderBranchWhenConditionPredicate<TParam, TPipelineBuilder> :
    IPipelineBuilderBranchWhenConditionPredicateFactory<TParam, TPipelineBuilder>,
    IPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider<TParam, TPipelineBuilder>,
    IPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderBranchWhenConditionPredicate<TParam, TPipelineBuilder> { }
