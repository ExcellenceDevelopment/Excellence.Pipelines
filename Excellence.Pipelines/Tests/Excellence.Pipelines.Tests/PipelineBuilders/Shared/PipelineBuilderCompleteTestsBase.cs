using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Shared
{
    public abstract class PipelineBuilderCompleteTestsBase : PipelineBuilderTestsBase
    {
        protected Func<Func<int, CancellationToken, Task<int>>, Func<int, CancellationToken, Task<int>>> Component =>
            next => async (param, cancellationToken) =>
            {
                var nextResult = await next.Invoke(param, cancellationToken);

                return nextResult * nextResult;
            };

        protected interface IPipelineBuilderCoreCompleteTestSut :
            IPipelineBuilderCore<Func<int, CancellationToken, Task<int>>, IPipelineBuilderCoreCompleteTestSut>,
            IPipelineBuilderCoreUtils<Func<int, CancellationToken, Task<int>>, IPipelineBuilderCoreCompleteTestSut>,
            IPipelineBuilderCoreUseUtils<Func<int, CancellationToken, Task<int>>, IPipelineBuilderCoreCompleteTestSut>
        {
            public IServiceProvider ServiceProviderPublic { get; }
        }


        protected class PipelineBuilderCoreCompleteTestSut :
            PipelineBuilderCoreComplete<Func<int, CancellationToken, Task<int>>, IPipelineBuilderCoreCompleteTestSut>,
            IPipelineBuilderCoreCompleteTestSut
        {
            public IServiceProvider ServiceProviderPublic => this.ServiceProvider;

            public PipelineBuilderCoreCompleteTestSut(IServiceProvider serviceProvider) : base(serviceProvider) { }
        }

        protected static IPipelineBuilderCoreCompleteTestSut CreateSut(IServiceProvider serviceProvider) =>
            new PipelineBuilderCoreCompleteTestSut(serviceProvider);
    }
}
