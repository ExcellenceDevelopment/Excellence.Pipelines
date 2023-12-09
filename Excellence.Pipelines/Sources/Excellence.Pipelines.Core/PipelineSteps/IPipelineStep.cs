namespace Excellence.Pipelines.Core.PipelineSteps;

/// <summary>
/// The pipeline step.
/// </summary>
/// <typeparam name="TParam">The parameter type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
public interface IPipelineStep<TParam, TResult>
{
    /// <summary>
    /// Executes the pipeline step logic.
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <param name="next">The pipeline next step delegate.</param>
    /// <returns>The result.</returns>
    public TResult Invoke(TParam param, Func<TParam, TResult> next);
}