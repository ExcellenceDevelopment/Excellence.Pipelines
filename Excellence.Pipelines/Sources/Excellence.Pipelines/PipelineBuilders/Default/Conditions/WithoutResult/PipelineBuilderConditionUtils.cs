using Excellence.Pipelines.Core.PipelineConditions;

namespace Excellence.Pipelines.PipelineBuilders.Default;

public partial class PipelineBuilderComplete<TParam, TPipelineBuilder>
{
    #region Interface

    protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
    (
        Func<TPipelineCondition> pipelineConditionFactory,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        Func<TPipelineBuilder> branchPipelineBuilderFactory,
        bool withRejoining
    ) where TPipelineCondition : class, IPipelineCondition<TParam>
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
    ) where TPipelineCondition : class, IPipelineCondition<TParam>
    {
        var pipelineCondition = this.GetFromFactory(pipelineConditionFactory);

        ArgumentNullException.ThrowIfNull(pipelineCondition);

        return this.UseConditionPredicate(pipelineCondition.Invoke, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, withRejoining);
    }

    protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
    (
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        bool withRejoining
    ) where TPipelineCondition : class, IPipelineCondition<TParam>
    {
        var pipelineCondition = this.GetFromServiceProvider<TPipelineCondition>();

        return this.UseConditionPredicate(pipelineCondition.Invoke, branchPipelineBuilderConfiguration, withRejoining);
    }

    #endregion

    #region Predicate

    protected virtual TPipelineBuilder UseConditionPredicate
    (
        Func<TParam, bool> predicate,
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
        Func<TParam, bool> predicate,
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
        Func<TParam, bool> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        bool withRejoining
    )
    {
        var branchPipelineBuilder = this.New();

        return this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, (TPipelineBuilder)branchPipelineBuilder, withRejoining);
    }

    protected virtual TPipelineBuilder UseConditionPredicate
    (
        Func<TParam, bool> predicate,
        Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
        TPipelineBuilder branchPipelineBuilder,
        bool withRejoining
    )
    {
        ArgumentNullException.ThrowIfNull(predicate);
        ArgumentNullException.ThrowIfNull(branchPipelineBuilderConfiguration);
        ArgumentNullException.ThrowIfNull(branchPipelineBuilder);

        branchPipelineBuilderConfiguration.Invoke(branchPipelineBuilder);

        Func<Action<TParam>, Action<TParam>> component;

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

    protected virtual Action<TParam> CreateConditionalPipelineDelegate(Func<TParam, bool> predicate, Action<TParam> ifTrue, Action<TParam> ifFalse) =>
        (param) =>
        {
            if (predicate.Invoke(param))
            {
                ifTrue.Invoke(param);
            }
            else
            {
                ifFalse.Invoke(param);
            }
        };

    #endregion
}
