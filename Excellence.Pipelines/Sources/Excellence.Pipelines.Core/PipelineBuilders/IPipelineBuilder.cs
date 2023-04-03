using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Core.PipelineBuilders.Default;

namespace Excellence.Pipelines.Core.PipelineBuilders;

/// <summary>
/// The pipeline builder.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
public interface IPipelineBuilder<TParam> :
    IPipelineBuilderCore<Action<TParam>, IPipelineBuilder<TParam>>,
    IPipelineBuilderCoreUtils<Action<TParam>, IPipelineBuilder<TParam>>,
    IPipelineBuilderCoreUseUtils<Action<TParam>, IPipelineBuilder<TParam>>,
    IPipelineBuilderStepInterface<TParam, IPipelineBuilder<TParam>>,
    IPipelineBuilderUseWhen<TParam, IPipelineBuilder<TParam>>,
    IPipelineBuilderBranchWhen<TParam, IPipelineBuilder<TParam>> { }

/// <summary>
/// The pipeline builder.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
public interface IPipelineBuilder<TParam, TResult> :
    IPipelineBuilderCore<Func<TParam, TResult>, IPipelineBuilder<TParam, TResult>>,
    IPipelineBuilderCoreUtils<Func<TParam, TResult>, IPipelineBuilder<TParam, TResult>>,
    IPipelineBuilderCoreUseUtils<Func<TParam, TResult>, IPipelineBuilder<TParam, TResult>>,
    IPipelineBuilderStepInterface<TParam, TResult, IPipelineBuilder<TParam, TResult>>,
    IPipelineBuilderUseWhen<TParam, TResult, IPipelineBuilder<TParam, TResult>>,
    IPipelineBuilderBranchWhen<TParam, TResult, IPipelineBuilder<TParam, TResult>> { }
