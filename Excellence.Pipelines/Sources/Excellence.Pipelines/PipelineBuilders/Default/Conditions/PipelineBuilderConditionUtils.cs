using System;

using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Utils;

namespace Excellence.Pipelines.PipelineBuilders.Default
{
    public partial class PipelineBuilderComplete<TParam, TResult, TPipelineBuilder>
    {
        #region Interface

        protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
        (
            Func<TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory,
            bool withRejoining
        ) where TPipelineCondition : IPipelineCondition<TParam>
        {
            var pipelineCondition = this.GetFromFactory(pipelineConditionFactory);

            ExceptionUtils.Process((object?)pipelineCondition, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(pipelineCondition)));

            return this.UseConditionPredicate(pipelineCondition.Invoke, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, withRejoining);
        }

        protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
        (
            Func<IServiceProvider, TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory,
            bool withRejoining
        ) where TPipelineCondition : IPipelineCondition<TParam>
        {
            var pipelineCondition = this.GetFromFactory(pipelineConditionFactory);

            ExceptionUtils.Process((object?)pipelineCondition, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(pipelineCondition)));

            return this.UseConditionPredicate(pipelineCondition.Invoke, branchPipelineBuilderConfiguration, branchPipelineBuilderFactory, withRejoining);
        }

        protected virtual TPipelineBuilder UseConditionInterface<TPipelineCondition>
        (
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            bool withRejoining
        ) where TPipelineCondition : IPipelineCondition<TParam>
        {
            var pipelineCondition = this.GetFromServiceProvider<TPipelineCondition>();

            return this.UseConditionPredicate(pipelineCondition.Invoke, branchPipelineBuilderConfiguration, withRejoining);
        }

        #endregion Interface

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
            ExceptionUtils.Process(predicate, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(predicate)));
            ExceptionUtils.Process(branchPipelineBuilderConfiguration, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(branchPipelineBuilderConfiguration)));
            ExceptionUtils.Process((object)branchPipelineBuilder, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(branchPipelineBuilder)));

            branchPipelineBuilderConfiguration.Invoke(branchPipelineBuilder);

            Func<Func<TParam, TResult>, Func<TParam, TResult>> component;

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

        protected virtual Func<TParam, TResult> CreateConditionalPipelineDelegate(Func<TParam, bool> predicate, Func<TParam, TResult> ifTrue, Func<TParam, TResult> ifFalse) =>
            (param) => predicate.Invoke(param) ? ifTrue.Invoke(param) : ifFalse.Invoke(param);

        #endregion Predicate
    }
}
