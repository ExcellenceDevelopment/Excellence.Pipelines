using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Core.PipelineBuilders.Default;
using Excellence.Pipelines.PipelineBuilders.Default;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Default.Complete;

public class PipelineBuilderCompleteTestsBase
{
    protected static Action<PipelineArg> TargetMainResult =>
        (param) => param.Value = param.Value * 3 + 1;

    protected static void TargetMain(PipelineArg param) =>
        TargetMainResult.Invoke(param);

    protected static IPipelineBuilderCompleteTestSut CreateSut(IServiceProvider? serviceProvider = null) =>
        new PipelineBuilderCompleteTestSut(serviceProvider ?? new ServiceCollection().BuildServiceProvider());

    #region Types

    public interface IPipelineBuilderCompleteTestSut :
        IPipelineBuilderCore<Action<PipelineArg>, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUtils<Action<PipelineArg>, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUseUtils<Action<PipelineArg>, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderStepInterface<PipelineArg, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderUseWhen<PipelineArg, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderBranchWhen<PipelineArg, IPipelineBuilderCompleteTestSut>
    {
        public IPipelineBuilderCompleteTestSut UseServiceProvider(IServiceProvider serviceProvider);
    }

    protected class PipelineBuilderCompleteTestSut :
        PipelineBuilderComplete<PipelineArg, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCompleteTestSut
    {
        public PipelineBuilderCompleteTestSut(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public IPipelineBuilderCompleteTestSut UseServiceProvider(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;

            return this;
        }
    }

    #endregion
}
