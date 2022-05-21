using System;

using Excellence.Pipelines.Core.PipelineConditions;

namespace Excellence.Pipelines.PipelineBuilders.Default
{
    public partial class PipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
    {
        #region Predicate

        /// <inheritdoc />
        public virtual TPipelineBuilder UseWhen
        (
            Func<TParam, bool> predicate,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory
        )
            => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, true);

        /// <inheritdoc />
        public virtual TPipelineBuilder UseWhen
        (
            Func<TParam, bool> predicate,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
        )
            => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, true);

        /// <inheritdoc />
        public virtual TPipelineBuilder UseWhen
        (
            Func<TParam, bool> predicate,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration
        )
            => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, true);

        #endregion Predicate

        #region Interface

        /// <inheritdoc />
        public virtual TPipelineBuilder UseWhen<TPipelineCondition>
        (
            Func<TPipelineCondition> conditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : IPipelineCondition<TParam>
            => this.UseConditionInterface(conditionFactory, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, true);

        /// <inheritdoc />
        public virtual TPipelineBuilder UseWhen<TPipelineCondition>
        (
            Func<IServiceProvider, TPipelineCondition> conditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : IPipelineCondition<TParam>
            => this.UseConditionInterface(conditionFactory, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, true);

        /// <inheritdoc />
        public virtual TPipelineBuilder UseWhen<TPipelineCondition>(Action<TPipelineBuilder> branchPipelineBuilderConfiguration)
            where TPipelineCondition : IPipelineCondition<TParam> =>
            this.UseConditionInterface<TPipelineCondition>(branchPipelineBuilderConfiguration, true);

        #endregion Interface
    }
}
