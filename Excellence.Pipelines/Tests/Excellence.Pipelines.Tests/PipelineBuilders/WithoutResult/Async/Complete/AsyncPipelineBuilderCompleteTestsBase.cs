using Excellence.Pipelines.Core.PipelineBuilders.Async;
using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.PipelineBuilders.Async;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Async.Complete;

public class AsyncPipelineBuilderCompleteTestsBase
{
    protected static Func<PipelineArg, CancellationToken, Task> TargetMainResult =>
        (param, _) =>
        {
            param.Value = param.Value * 3 + 1;

            return Task.FromResult(param);
        };

    protected static Task TargetMain(PipelineArg param, CancellationToken cancellationToken) =>
        TargetMainResult.Invoke(param, cancellationToken);

    protected static IAsyncPipelineBuilderCompleteTestSut CreateSut(IServiceProvider? serviceProvider = null) =>
        new AsyncPipelineBuilderCompleteTestSut(serviceProvider ?? new ServiceCollection().BuildServiceProvider());

    #region Types

    public interface IAsyncPipelineBuilderCompleteTestSut :
        IPipelineBuilderCore<Func<PipelineArg, CancellationToken, Task>, IAsyncPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUtils<Func<PipelineArg, CancellationToken, Task>, IAsyncPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUseUtils<Func<PipelineArg, CancellationToken, Task>, IAsyncPipelineBuilderCompleteTestSut>,
        IAsyncPipelineBuilderStepInterface<PipelineArg, IAsyncPipelineBuilderCompleteTestSut>,
        IAsyncPipelineBuilderUseWhen<PipelineArg, IAsyncPipelineBuilderCompleteTestSut>,
        IAsyncPipelineBuilderBranchWhen<PipelineArg, IAsyncPipelineBuilderCompleteTestSut>
    {
        public IAsyncPipelineBuilderCompleteTestSut UseServiceProvider(IServiceProvider serviceProvider);
    }

    protected class AsyncPipelineBuilderCompleteTestSut :
        AsyncPipelineBuilderComplete<PipelineArg, IAsyncPipelineBuilderCompleteTestSut>,
        IAsyncPipelineBuilderCompleteTestSut
    {
        public AsyncPipelineBuilderCompleteTestSut(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public IAsyncPipelineBuilderCompleteTestSut UseServiceProvider(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;

            return this;
        }
    }

    #endregion
}
