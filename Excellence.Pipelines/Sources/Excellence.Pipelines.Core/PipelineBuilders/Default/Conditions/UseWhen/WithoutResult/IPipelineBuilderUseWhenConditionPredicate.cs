using Excellence.Pipelines.Core.PipelineBuilders.Core;

namespace Excellence.Pipelines.Core.PipelineBuilders.Default;

/// <summary>
/// The pipeline builder with the possibility to execute the pipeline steps conditionally.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
public interface IPipelineBuilderUseWhenConditionPredicateFactory<TParam, TPipelineBuilder> :
    IPipelineBuilderCore<Action<TParam>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderUseWhenConditionPredicateFactory<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and then the main pipeline is executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder UseWhen
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
public interface IPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider<TParam, TPipelineBuilder> :
    IPipelineBuilderCore<Action<TParam>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and then the main pipeline is executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder UseWhen
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
public interface IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam, out TPipelineBuilder> :
    IPipelineBuilderCore<Action<TParam>, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam, TPipelineBuilder>
{
    /// <summary>
    /// Adds the pipeline branch with own configuration that is executed when the condition is met.
    /// When the condition is met the branch is executed and then the main pipeline is executed.
    /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
    /// <returns>The current pipeline builder instance.</returns>
    public TPipelineBuilder UseWhen
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
public interface IPipelineBuilderUseWhenConditionPredicate<TParam, TPipelineBuilder> :
    IPipelineBuilderUseWhenConditionPredicateFactory<TParam, TPipelineBuilder>,
    IPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider<TParam, TPipelineBuilder>,
    IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam, TPipelineBuilder>
    where TPipelineBuilder : class, IPipelineBuilderUseWhenConditionPredicate<TParam, TPipelineBuilder> { }
