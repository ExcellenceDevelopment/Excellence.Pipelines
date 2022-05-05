using System;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders.Shared;
using Excellence.Pipelines.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Shared
{
    public abstract class PipelineBuilderTestsBase
    {
        protected int Arg => 37;

        protected static Func<int, CancellationToken, Task<int>> TargetMainResult =>
            (param, _) => Task.FromResult(param);

        protected static Task<int> TargetMain(int param, CancellationToken cancellationToken) =>
            TargetMainResult.Invoke(param, cancellationToken);

        protected static IPipelineBuilderFromDelegateTestSut CreateSut(IServiceProvider? serviceProvider = null) =>
            new PipelineBuilderFromDelegateTestSut(serviceProvider);

        #region Types

        protected interface IPipeline
        {
            public Task<int> InvokeAsync(int param, CancellationToken cancellationToken);
        }

        protected class Pipeline : IPipeline
        {
            private readonly Func<int, CancellationToken, Task<int>> _pipelineDelegate;

            public Pipeline(Func<int, CancellationToken, Task<int>> pipelineDelegate) => this._pipelineDelegate = pipelineDelegate;

            public Task<int> InvokeAsync(int param, CancellationToken cancellationToken) => this._pipelineDelegate.Invoke(param, cancellationToken);
        }

        protected interface IPipelineBuilderFromDelegateTestSut :
            IPipelineBuilderFromDelegate<Func<int, CancellationToken, Task<int>>, IPipelineBuilderFromDelegateTestSut, IPipeline> { }


        protected class PipelineBuilderFromDelegateTestSut :
            PipelineBuilderFromDelegate<Func<int, CancellationToken, Task<int>>, IPipelineBuilderFromDelegateTestSut, IPipeline>,
            IPipelineBuilderFromDelegateTestSut
        {
            public PipelineBuilderFromDelegateTestSut(IServiceProvider? serviceProvider = null) : base(serviceProvider) { }

            protected override IPipeline CreatePipeline(Func<int, CancellationToken, Task<int>> pipelineStartDelegate) =>
                new Pipeline(pipelineStartDelegate);
        }

        #endregion Types
    }
}
