using Excellence.Pipelines.Core.PipelineConditions;

namespace Excellence.Pipelines.PipelineBuilders.Async;

public partial class AsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
{
    #region Predicate

    /// <inheritdoc />
    public virtual TPipelineBuilder UseWhen
    (
        Func<TParam, Task<bool>> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<TPipelineBuilder> branchPipelineBuilderFactory
    ) =>
        this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, true);

    /// <inheritdoc />
    public virtual TPipelineBuilder UseWhen
    (
        Func<TParam, Task<bool>> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
    ) => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, true);

    /// <inheritdoc />
    public virtual TPipelineBuilder UseWhen
    (
        Func<TParam, Task<bool>> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration
    ) => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, true);

    #endregion

    #region Interface

    /// <inheritdoc />
    public virtual TPipelineBuilder UseWhen<TPipelineCondition>
    (
        Func<TPipelineCondition> pipelineConditionFactory,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<TPipelineBuilder> branchPipelineBuilderFactory
    ) where TPipelineCondition : class, IAsyncPipelineCondition<TParam>
        => this.UseConditionInterface(pipelineConditionFactory, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, true);

    /// <inheritdoc />
    public virtual TPipelineBuilder UseWhen<TPipelineCondition>
    (
        Func<IServiceProvider, TPipelineCondition> pipelineConditionFactory,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
    ) where TPipelineCondition : class, IAsyncPipelineCondition<TParam>
        => this.UseConditionInterface(pipelineConditionFactory, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, true);

    /// <inheritdoc />
    public virtual TPipelineBuilder UseWhen<TPipelineCondition>(Action<TPipelineBuilder> branchPipelineBuilderConfiguration)
        where TPipelineCondition : class, IAsyncPipelineCondition<TParam>
        => this.UseConditionInterface<TPipelineCondition>(branchPipelineBuilderConfiguration, true);

    #endregion
}
