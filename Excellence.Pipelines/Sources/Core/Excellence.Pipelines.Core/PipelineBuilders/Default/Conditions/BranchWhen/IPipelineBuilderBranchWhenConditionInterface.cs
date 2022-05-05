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
    public interface IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderCore<Func<TParam, TResult>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        /// <summary>
        /// Adds the pipeline branch with own configuration that is executed when the condition is met.
        /// When the condition is met the branch is executed and the main pipeline is NOT executed.
        /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
        /// </summary>
        /// <param name="pipelineConditionFactory">The pipeline builder condition factory.</param>
        /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
        /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder BranchWhen<TPipelineCondition>
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
    public interface IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, TResult>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        /// <summary>
        /// Adds the pipeline branch with own configuration that is executed when the condition is met.
        /// When the condition is met the branch is executed and the main pipeline is NOT executed.
        /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
        /// Requires the service provider to be set.
        /// </summary>
        /// <param name="pipelineConditionFactory">The pipeline builder condition factory.</param>
        /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
        /// <param name="branchPipelineBuilderFactory">The pipeline builder factory.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder BranchWhen<TPipelineCondition>
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
    public interface IPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam, TResult, out TPipelineBuilder, out TPipeline> :
        IPipelineBuilderServiceProvider<Func<TParam, TResult>, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult>
    {
        /// <summary>
        /// Adds the pipeline branch with own configuration that is executed when the condition is met.
        /// When the condition is met the branch is executed and the main pipeline is NOT executed.
        /// When the condition is NOT met the branch is skipped and the main pipeline is executed.
        /// Requires the service provider to be set.
        /// </summary>
        /// <param name="branchPipelineBuilderConfiguration">The branch pipeline builder configuration.</param>
        /// <returns>The current pipeline builder instance.</returns>
        public TPipelineBuilder BranchWhen<TPipelineCondition>
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
    public interface IPipelineBuilderBranchWhenConditionInterface<TParam, TResult, TPipelineBuilder, out TPipeline> :
        IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder, TPipeline>,
        IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>,
        IPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipelineBuilder : IPipelineBuilderBranchWhenConditionInterface<TParam, TResult, TPipelineBuilder, TPipeline>
        where TPipeline : IPipeline<TParam, TResult> { }
}
