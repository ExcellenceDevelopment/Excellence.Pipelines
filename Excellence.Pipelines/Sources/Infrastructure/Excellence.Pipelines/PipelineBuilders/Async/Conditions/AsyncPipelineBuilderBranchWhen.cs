using System;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineConditions;

namespace Excellence.Pipelines.PipelineBuilders.Async
{
    public partial class AsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline>
    {
        #region Predicate

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen
        (
            Func<TParam, Task<bool>> predicate,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory
        ) => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, false);

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen
        (
            Func<TParam, Task<bool>> predicate,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
        ) => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, false);

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen
        (
            Func<TParam, Task<bool>> predicate,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration
        ) => this.UseConditionPredicate(predicate, branchPipelineBuilderConfiguration, false);

        #endregion Predicate

        #region Interface

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen<TPipelineCondition>
        (
            Func<TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : IAsyncPipelineCondition<TParam> =>
            this.UseConditionInterface(pipelineConditionFactory, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, false);

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen<TPipelineCondition>
        (
            Func<IServiceProvider, TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : IAsyncPipelineCondition<TParam> =>
            this.UseConditionInterface(pipelineConditionFactory, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, false);

        /// <inheritdoc />
        public virtual TPipelineBuilder BranchWhen<TPipelineCondition>(Action<TPipelineBuilder> branchPipelineBuilderConfiguration)
            where TPipelineCondition : IAsyncPipelineCondition<TParam> =>
            this.UseConditionInterface<TPipelineCondition>(branchPipelineBuilderConfiguration, false);

        #endregion Interface
    }
}
