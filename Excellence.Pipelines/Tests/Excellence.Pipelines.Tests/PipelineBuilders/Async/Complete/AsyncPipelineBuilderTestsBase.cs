using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Async;
using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.PipelineBuilders.Async;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async
{
    public class AsyncPipelineBuilderTestsBase
    {
        protected int Arg => 37;

        protected static Func<int, CancellationToken, Task<int>> TargetMainResult =>
            (param, _) => Task.FromResult(param);

        protected static Task<int> TargetMain(int param, CancellationToken cancellationToken) =>
            TargetMainResult.Invoke(param, cancellationToken);

        protected static IAsyncPipelineBuilderCompleteTestSut CreateSut(IServiceProvider? serviceProvider = null) =>
            new AsyncPipelineBuilderCompleteTestSut(serviceProvider ?? new ServiceCollection().BuildServiceProvider());

        #region Types

        public interface IAsyncPipelineBuilderCompleteTestSut :
            IPipelineBuilderCore<Func<int, CancellationToken, Task<int>>, IAsyncPipelineBuilderCompleteTestSut>,
            IPipelineBuilderCoreUtils<Func<int, CancellationToken, Task<int>>, IAsyncPipelineBuilderCompleteTestSut>,
            IPipelineBuilderCoreUseUtils<Func<int, CancellationToken, Task<int>>, IAsyncPipelineBuilderCompleteTestSut>,
            IAsyncPipelineBuilderStepInterface<int, int, IAsyncPipelineBuilderCompleteTestSut>,
            IAsyncPipelineBuilderUseWhen<int, int, IAsyncPipelineBuilderCompleteTestSut>,
            IAsyncPipelineBuilderBranchWhen<int, int, IAsyncPipelineBuilderCompleteTestSut>
        {
            public IAsyncPipelineBuilderCompleteTestSut UseServiceProvider(IServiceProvider serviceProvider);
        }

        protected class AsyncPipelineBuilderCompleteTestSut :
            AsyncPipelineBuilderComplete<int, int, IAsyncPipelineBuilderCompleteTestSut>,
            IAsyncPipelineBuilderCompleteTestSut
        {
            public AsyncPipelineBuilderCompleteTestSut(IServiceProvider serviceProvider) : base(serviceProvider) { }

            public IAsyncPipelineBuilderCompleteTestSut UseServiceProvider(IServiceProvider serviceProvider)
            {
                this.ServiceProvider = serviceProvider;

                return this;
            }
        }

        #endregion Types
    }
}
