using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Core.PipelineBuilders.Default;
using Excellence.Pipelines.PipelineBuilders.Default;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Default;

public class PipelineBuilderCompleteTestsBase
{
    protected static Func<PipelineArg, PipelineArg> TargetMainResult =>
        (param) =>
        {
            param.Value = param.Value * 3 + 1;

            return param;
        };

    protected static PipelineArg TargetMain(PipelineArg param) =>
        TargetMainResult.Invoke(param);

    protected static IPipelineBuilderCompleteTestSut CreateSut(IServiceProvider? serviceProvider = null) =>
        new PipelineBuilderCompleteTestSut(serviceProvider ?? new ServiceCollection().BuildServiceProvider());

    #region Types

    public interface IPipelineBuilderCompleteTestSut :
        IPipelineBuilderCore<Func<PipelineArg, PipelineArg>, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUtils<Func<PipelineArg, PipelineArg>, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUseUtils<Func<PipelineArg, PipelineArg>, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderStepInterface<PipelineArg, PipelineArg, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderUseWhen<PipelineArg, PipelineArg, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderBranchWhen<PipelineArg, PipelineArg, IPipelineBuilderCompleteTestSut>
    {
        public IPipelineBuilderCompleteTestSut UseServiceProvider(IServiceProvider serviceProvider);
    }

    protected class PipelineBuilderCompleteTestSut :
        PipelineBuilderComplete<PipelineArg, PipelineArg, IPipelineBuilderCompleteTestSut>,
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
