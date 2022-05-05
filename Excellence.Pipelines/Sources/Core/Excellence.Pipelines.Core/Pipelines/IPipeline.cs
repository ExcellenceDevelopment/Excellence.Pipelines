namespace Excellence.Pipelines.Core.Pipelines
{
    /// <summary>
    /// The pipeline.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    public interface IPipeline<in TParam, out TResult>
    {
        /// <summary>
        /// Invokes the pipeline.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns>The pipeline result.</returns>
        public TResult Invoke(TParam param);
    }
}
