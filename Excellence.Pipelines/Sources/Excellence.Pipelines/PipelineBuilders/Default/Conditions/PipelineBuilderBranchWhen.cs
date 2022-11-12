using System;

using Excellence.Pipelines.Core.PipelineConditions;

namespace Excellence.Pipelines.PipelineBuilders.Default
{
    public partial class PipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
    {
        #region Predicate

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen
        (
            Func<TParam, bool> predicate,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory
        )
            => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, false);

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen
        (
            Func<TParam, bool> predicate,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
        )
            => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, false);

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen
        (
            Func<TParam, bool> predicate,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration
        )
            => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, false);

        #endregion Predicate

        #region Interface

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen<TPipelineCondition>
        (
            Func<TPipelineCondition> conditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : class, IPipelineCondition<TParam>
            => this.UseConditionInterface(conditionFactory, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, false);

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen<TPipelineCondition>
        (
            Func<IServiceProvider, TPipelineCondition> conditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : class, IPipelineCondition<TParam>
            => this.UseConditionInterface(conditionFactory, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, false);

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen<TPipelineCondition>(Action<TPipelineBuilder> branchPipelineBuilderConfiguration)
            where TPipelineCondition : class, IPipelineCondition<TParam> =>
            this.UseConditionInterface<TPipelineCondition>(branchPipelineBuilderConfiguration, false);

        #endregion Interface
    }
}
