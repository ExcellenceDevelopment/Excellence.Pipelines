using Excellence.Pipelines.Core.PipelineBuilders;

namespace Excellence.Pipelines.Core.PipelineBuilderFactories;

/// <summary>
/// The pipeline builder factory.
/// </summary>
public interface IPipelineBuilderFactory
{
    /// <summary>
    /// Creates the new pipeline builder instance.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <returns>The pipeline builder.</returns>
    public IPipelineBuilder<TParam> CreatePipelineBuilder<TParam>();

    /// <summary>
    /// Creates the new pipeline builder instance.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <returns>The pipeline builder.</returns>
    public IPipelineBuilder<TParam, TResult> CreatePipelineBuilder<TParam, TResult>();
}
