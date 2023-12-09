using Excellence.Pipelines.Core.PipelineConditions;

namespace Excellence.Pipelines.PipelineBuilders.Async;

public partial class AsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
{
    #region Interface

    protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
    (
        Func<TPipelineCondition> pipelineConditionFactory,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<TPipelineBuilder> branchPipelineBuilderFactory,
        bool withRejoining
    ) where TPipelineCondition : class, IAsyncPipelineCondition<TParam>
    {
        var pipelineCondition = this.GetFromFactory(pipelineConditionFactory);

        ArgumentNullException.ThrowIfNull(pipelineCondition);

        return this.UseConditionPredicate(pipelineCondition.Invoke, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, withRejoining);
    }

    protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
    (
        Func<IServiceProvider, TPipelineCondition> pipelineConditionFactory,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory,
        bool withRejoining
    ) where TPipelineCondition : class, IAsyncPipelineCondition<TParam>
    {
        var pipelineCondition = this.GetFromFactory(pipelineConditionFactory);

        ArgumentNullException.ThrowIfNull(pipelineCondition);

        return this.UseConditionPredicate(pipelineCondition.Invoke, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, withRejoining);
    }

    protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
    (
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        bool withRejoining
    ) where TPipelineCondition : class, IAsyncPipelineCondition<TParam>
    {
        var pipelineCondition = this.GetFromServiceProvider<TPipelineCondition>();

        return this.UseConditionPredicate(pipelineCondition.Invoke, branchPipelineBuilderConfiguration, withRejoining);
    }

    #endregion Interface

    #region Predicate

    protected virtual TPipelineBuilder UseConditionPredicate
    (
        Func<TParam, Task<bool>> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<TPipelineBuilder> branchPipelineBuilderFactory,
        bool withRejoining
    )
    {
        var branchPipelineBuilder = this.GetFromFactory(branchPipelineBuilderFactory);

        return this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, (TPipelineBuilder)branchPipelineBuilder, withRejoining);
    }

    protected virtual TPipelineBuilder UseConditionPredicate
    (
        Func<TParam, Task<bool>> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory,
        bool withRejoining
    )
    {
        var branchPipelineBuilder = this.GetFromFactory(branchPipelineBuilderFactory);

        return this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, (TPipelineBuilder)branchPipelineBuilder, withRejoining);
    }

    protected virtual TPipelineBuilder UseConditionPredicate
    (
        Func<TParam, Task<bool>> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        bool withRejoining
    )
    {
        var branchPipelineBuilder = this.New();

        return this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, (TPipelineBuilder)branchPipelineBuilder, withRejoining);
    }

    protected virtual TPipelineBuilder UseConditionPredicate
    (
        Func<TParam, Task<bool>> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        TPipelineBuilder branchPipelineBuilder,
        bool withRejoining
    )
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(branchPipelineBuilderConfiguration);
        ArgumentNullException.ThrowIfNull(branchPipelineBuilder);

        branchPipelineBuilderConfiguration.Invoke(branchPipelineBuilder);

        Func<Func<TParam, CancellationToken, Task<TResult>>, Func<TParam, CancellationToken, Task<TResult>>> component;

        if (withRejoining)
        {
            component = next =>
            {
                var branchPipeline = branchPipelineBuilder.UseTarget(next).BuildPipeline();

                return this.CreateConditionalPipelineDelegate(predicate, branchPipeline.Invoke, next);
            };
        }
        else
        {
            var branchPipeline = branchPipelineBuilder.BuildPipeline();

            component = next => this.CreateConditionalPipelineDelegate(predicate, branchPipeline.Invoke, next);
        }

        return this.Use(component);
    }

    protected virtual Func<TParam, CancellationToken, Task<TResult>> CreateConditionalPipelineDelegate
    (
        Func<TParam, Task<bool>> predicate,
        Func<TParam, CancellationToken, Task<TResult>> ifTrue,
        Func<TParam, CancellationToken, Task<TResult>> ifFalse
    ) => async (param, cancellationToken) =>
        await predicate.Invoke(param)
            ? await ifTrue.Invoke(param, cancellationToken)
            : await ifFalse.Invoke(param, cancellationToken);

    #endregion Predicate
}