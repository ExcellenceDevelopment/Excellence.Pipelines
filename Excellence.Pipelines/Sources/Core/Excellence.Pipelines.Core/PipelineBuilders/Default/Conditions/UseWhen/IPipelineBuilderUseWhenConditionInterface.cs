using System;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.Pipelines;

namespace Excellence.Pipelines.Core.PipelineBuilders.Default
{
    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderCore<Func<TParam, TResult>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        /// <summary>
        /// Adds the pipeline branch with own configuration that is executed when the condition is met.
        /// When the condition is met the branch is executed and then the main pipeline is executed.
        /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
        /// </summary>
        /// <param name="pipelineConditionFactory">The pipeline builder condition factory.</param>
        /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
        /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder UseWhen<TPipelineCondition>
        (
            Func<TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : IPipelineCondition<TParam>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, TResult>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        /// <summary>
        /// Adds the pipeline branch with own configuration that is executed when the condition is met.
        /// When the condition is met the branch is executed and then the main pipeline is executed.
        /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
        /// Requires the service provider to be set.
        /// </summary>
        /// <param name="pipelineConditionFactory">The pipeline builder condition factory.</param>
        /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
        /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder UseWhen<TPipelineCondition>
        (
            Func<IServiceProvider, TPipelineCondition> pipelineConditionFactory,
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration,
            Func<IServiceProvider, TPipelineBuilder> branchPipelineBuilderFactory
        ) where TPipelineCondition : IPipelineCondition<TParam>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, TResult>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        /// <summary>
        /// Adds the pipeline branch with own configuration that is executed when the condition is met.
        /// When the condition is met the branch is executed and then the main pipeline is executed.
        /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
        /// Requires the service provider to be set.
        /// </summary>
        /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder UseWhen<TPipelineCondition>
        (
            Action<TPipelineBuilder> branchPipelineBuilderConfiguration
        ) where TPipelineCondition : IPipelineCondition<TParam>;
    }

    /// <summary>
    /// The pipeline builder with the possibility to execute the pipeline steps conditionally.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TPipelineBuilder">The pipeline builder type.</typeparam>
    /// <typeparam name="TPipeline">The pipeline type.</typeparam>
    public interface IPipelineBuilderUseWhenConditionInterface<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>,
        IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>,
        IPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderUseWhenConditionInterface<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult> { }
}
