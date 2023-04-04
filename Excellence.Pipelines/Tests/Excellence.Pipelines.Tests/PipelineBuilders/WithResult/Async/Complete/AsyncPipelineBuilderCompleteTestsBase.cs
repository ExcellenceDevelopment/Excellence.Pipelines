using Excellence.Pipelines.Core.PipelineBuilders.Async;
using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.PipelineBuilders.Async;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Async;

public class AsyncPipelineBuilderCompleteTestsBase
{
    protected static Func<PipelineArg, CancellationToken, Task<PipelineArg>> TargetMainResult =>
        (param, _) =>
        {
            param.Value = param.Value * 3 + 1;

            return Task.FromResult(param);
        };

    protected static Task<PipelineArg> TargetMain(PipelineArg param, CancellationToken cancellationToken) =>
        TargetMainResult.Invoke(param, cancellationToken);

    protected static IAsyncPipelineBuilderCompleteTestSut CreateSut(IServiceProvider? serviceProvider = null) =>
        new AsyncPipelineBuilderCompleteTestSut(serviceProvider ?? new ServiceCollection().BuildServiceProvider());

    #region Types

    public interface IAsyncPipelineBuilderCompleteTestSut :
        IPipelineBuilderCore<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, IAsyncPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUtils<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, IAsyncPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUseUtils<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, IAsyncPipelineBuilderCompleteTestSut>,
        IAsyncPipelineBuilderStepInterface<PipelineArg, PipelineArg, IAsyncPipelineBuilderCompleteTestSut>,
        IAsyncPipelineBuilderUseWhen<PipelineArg, PipelineArg, IAsyncPipelineBuilderCompleteTestSut>,
        IAsyncPipelineBuilderBranchWhen<PipelineArg, PipelineArg, IAsyncPipelineBuilderCompleteTestSut>
    {
        public IAsyncPipelineBuilderCompleteTestSut UseServiceProvider(IServiceProvider serviceProvider);
    }

    protected class AsyncPipelineBuilderCompleteTestSut :
        AsyncPipelineBuilderComplete<PipelineArg, PipelineArg, IAsyncPipelineBuilderCompleteTestSut>,
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
