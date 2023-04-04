using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.PipelineBuilders.Core;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Core;

public abstract class PipelineBuilderCoreCompleteTestsBase : PipelineBuilderCoreTestsBase
{
    protected Func<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, Func<PipelineArg, CancellationToken, Task<PipelineArg>>> Component =>
        next => async (param, cancellationToken) =>
        {
            var nextResult = await next.Invoke(param, cancellationToken);

            nextResult.Value *= nextResult.Value;

            return nextResult;
        };

    protected interface IPipelineBuilderCoreCompleteTestSut :
        IPipelineBuilderCore<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, IPipelineBuilderCoreCompleteTestSut>,
        IPipelineBuilderCoreUtils<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, IPipelineBuilderCoreCompleteTestSut>,
        IPipelineBuilderCoreUseUtils<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, IPipelineBuilderCoreCompleteTestSut>
    {
        public IServiceProvider ServiceProviderPublic { get; }
    }

    protected class PipelineBuilderCoreCompleteTestSut :
        PipelineBuilderCoreComplete<Func<PipelineArg, CancellationToken, Task<PipelineArg>>, IPipelineBuilderCoreCompleteTestSut>,
        IPipelineBuilderCoreCompleteTestSut
    {
        public IServiceProvider ServiceProviderPublic => this.ServiceProvider;

        public PipelineBuilderCoreCompleteTestSut(IServiceProvider serviceProvider) : base(serviceProvider) { }
    }

    protected static IPipelineBuilderCoreCompleteTestSut CreateSut(IServiceProvider serviceProvider) =>
        new PipelineBuilderCoreCompleteTestSut(serviceProvider);
}
