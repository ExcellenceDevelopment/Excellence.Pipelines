using Excellence.Pipelines.Core.PipelineBuilders.Core;
using Excellence.Pipelines.Core.PipelineBuilders.Default;
using Excellence.Pipelines.PipelineBuilders.Default;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Default;

public class PipelineBuilderCompleteTestsBase
{
    protected int Arg => 37;

    protected static Func<int, int> TargetMainResult =>
        (param) => param;

    protected static int TargetMain(int param) =>
        TargetMainResult.Invoke(param);

    protected static IPipelineBuilderCompleteTestSut CreateSut(IServiceProvider? serviceProvider = null) =>
        new PipelineBuilderCompleteTestSut(serviceProvider ?? new ServiceCollection().BuildServiceProvider());

    #region Types

    public interface IPipelineBuilderCompleteTestSut :
        IPipelineBuilderCore<Func<int, int>, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUtils<Func<int, int>, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderCoreUseUtils<Func<int, int>, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderStepInterface<int, int, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderUseWhen<int, int, IPipelineBuilderCompleteTestSut>,
        IPipelineBuilderBranchWhen<int, int, IPipelineBuilderCompleteTestSut>
    {
        public IPipelineBuilderCompleteTestSut UseServiceProvider(IServiceProvider serviceProvider);
    }

    protected class PipelineBuilderCompleteTestSut :
        PipelineBuilderComplete<int, int, IPipelineBuilderCompleteTestSut>,
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
