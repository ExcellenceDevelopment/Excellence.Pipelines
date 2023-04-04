using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.PipelineBuilders.Core;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;
using Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Core.Core;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Core.Complete;

public abstract class PipelineBuilderCoreCompleteTestsBase : PipelineBuilderCoreTestsBase
{
    protected Func<Func<PipelineArg, CancellationToken, Task>, Func<PipelineArg, CancellationToken, Task>> Component =>
        next => async (param, cancellationToken) =>
        {
            await next.Invoke(param, cancellationToken);

            param.Value *= param.Value;
        };

    protected interface IPipelineBuilderCoreCompleteTestSut :
        IPipelineBuilderCore<Func<PipelineArg, CancellationToken, Task>, IPipelineBuilderCoreCompleteTestSut>,
        IPipelineBuilderCoreUtils<Func<PipelineArg, CancellationToken, Task>, IPipelineBuilderCoreCompleteTestSut>,
        IPipelineBuilderCoreUseUtils<Func<PipelineArg, CancellationToken, Task>, IPipelineBuilderCoreCompleteTestSut>
    {
        public IServiceProvider ServiceProviderPublic { get; }
    }

    protected class PipelineBuilderCoreCompleteTestSut :
        PipelineBuilderCoreComplete<Func<PipelineArg, CancellationToken, Task>, IPipelineBuilderCoreCompleteTestSut>,
        IPipelineBuilderCoreCompleteTestSut
    {
        public IServiceProvider ServiceProviderPublic => this.ServiceProvider;

        public PipelineBuilderCoreCompleteTestSut(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }

    protected static IPipelineBuilderCoreCompleteTestSut CreateSut(IServiceProvider serviceProvider) =>
        new PipelineBuilderCoreCompleteTestSut(serviceProvider);
}
