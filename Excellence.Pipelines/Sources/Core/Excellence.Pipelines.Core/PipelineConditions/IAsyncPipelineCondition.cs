using System.Threading.Tasks;

namespace Excellence.Pipelines.Core.PipelineConditions
{
    /// <summary>
    /// The pipeline builder condition.
    /// </summary>
    /// <typeparam name="TParam">The parameter type.</typeparam>
    public interface IAsyncPipelineCondition<in TParam>
    {
        /// <summary>
        /// Checks if the parameter meets the condition.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns><see langword="true"/> when the parameter meets the condition or <see langword="false"/> when it doesn't.</returns>
        public Task<bool> InvokeAsync(TParam param);
    }
}
