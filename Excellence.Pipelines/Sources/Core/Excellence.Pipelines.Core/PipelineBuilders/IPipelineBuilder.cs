using Excellence.Pipelines.Core.PipelineBuilders.Default;
using Excellence.Pipelines.Core.Pipelines;

namespace Excellence.Pipelines.Core.PipelineBuilders
{
    /// <summary>
    /// The pipeline builder.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    public interface IPipelineBuilder<TParam, TResult> :
        IPipelineBuilderComplete<TParam, TResult, IPipelineBuilder<TParam, TResult>, IPipeline<TParam, TResult>> { }
}
