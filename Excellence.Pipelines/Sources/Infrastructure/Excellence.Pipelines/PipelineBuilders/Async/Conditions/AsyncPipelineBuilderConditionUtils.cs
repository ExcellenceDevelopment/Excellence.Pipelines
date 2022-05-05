using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.PipelineBuilders.Async
{
    public partial class AsyncPipelineBuilderComplete<TParam, TResult, TPipelineBuilder, TPipeline>
    {
        #region Interface

        protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
        (
            Func<TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory,
            bool withRejoining
        ) where TPipelineCondition : IAsyncPipelineCondition<TParam>
        {
            var pipelineCondition = this.GetFromFactory(pipelineConditionFactory);

            ExceptionUtils.Process((object?)pipelineCondition, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(pipelineCondition)));

            return this.UseConditionPredicate(pipelineCondition.InvokeAsync, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, withRejoining);
        }

        protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
        (
            Func<IServiceProvider, TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory,
            bool withRejoining
        ) where TPipelineCondition : IAsyncPipelineCondition<TParam>
        {
            var pipelineCondition = this.GetFromFactory(pipelineConditionFactory);

            ExceptionUtils.Process((object?)pipelineCondition, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(pipelineCondition)));

            return this.UseConditionPredicate(pipelineCondition.InvokeAsync, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, withRejoining);
        }

        protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
        (
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            bool withRejoining
        ) where TPipelineCondition : IAsyncPipelineCondition<TParam>
        {
            var pipelineCondition = this.GetFromServiceProvider<TPipelineCondition>();

            return this.UseConditionPredicate(pipelineCondition.InvokeAsync, branchPipelineBuilderConfiguration, withRejoining);
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
            ExceptionUtils.Process(predicate, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(predicate)));
            ExceptionUtils.Process(branchPipelineBuilderConfiguration, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(branchPipelineBuilderConfiguration)));
            ExceptionUtils.Process((object)branchPipelineBuilder, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(branchPipelineBuilder)));

            branchPipelineBuilderConfiguration.Invoke(branchPipelineBuilder);

            Func<Func<TParam, CancellationToken, Task<TResult>>, Func<TParam, CancellationToken, Task<TResult>>> component;

            if (withRejoining)
            {
                component = next =>
                {
                    var branchPipeline = branchPipelineBuilder.UseTarget(next).BuildPipeline();

                    return this.CreateConditionalPipelineDelegate(predicate, branchPipeline.InvokeAsync, next);
                };
            }
            else
            {
                var branchPipeline = branchPipelineBuilder.BuildPipeline();

                component = next => this.CreateConditionalPipelineDelegate(predicate, branchPipeline.InvokeAsync, next);
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
}
