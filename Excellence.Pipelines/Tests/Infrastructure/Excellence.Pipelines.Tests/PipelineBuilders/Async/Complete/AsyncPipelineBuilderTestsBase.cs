using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Async;
using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.PipelineBuilders.Async;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async.Complete
{
    public class AsyncPipelineBuilderTestsBase
    {
        protected int Arg => 37;

        protected static Func<int, CancellationToken, Task<int>> TargetMainResult =>
            (param, _) => Task.FromResult(param);

        protected static Task<int> TargetMain(int param, CancellationToken cancellationToken) =>
            TargetMainResult.Invoke(param, cancellationToken);

        protected static IAsyncPipelineBuilderCompleteTestSut CreateSut(IServiceProvider? serviceProvider = null) =>
            new AsyncPipelineBuilderCompleteTestSut(serviceProvider);

        #region Types

        public interface IAsyncPipelineBuilderCompleteTestSut :
            IAsyncPipelineBuilderComplete<int, int, IAsyncPipelineBuilderCompleteTestSut, IAsyncPipeline<int, int>> { }

        protected class AsyncPipelineBuilderCompleteTestSut :
            AsyncPipelineBuilderComplete<int, int, IAsyncPipelineBuilderCompleteTestSut, IAsyncPipeline<int, int>>,
            IAsyncPipelineBuilderCompleteTestSut
        {
            public AsyncPipelineBuilderCompleteTestSut(IServiceProvider? serviceProvider = null) : base(serviceProvider) { }
        }

        #endregion Types
    }
}
