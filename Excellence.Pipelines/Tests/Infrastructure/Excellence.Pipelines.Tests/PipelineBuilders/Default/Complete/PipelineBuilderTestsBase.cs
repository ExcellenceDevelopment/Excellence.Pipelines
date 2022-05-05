using System;

using Excellence.Pipelines.Core.PipelineBuilders.Default;
using Excellence.Pipelines.Core.Pipelines;
using Excellence.Pipelines.PipelineBuilders.Default;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Default.Complete
{
    public class PipelineBuilderTestsBase
    {
        protected int Arg => 37;

        protected static Func<int, int> TargetMainResult =>
            (param) => param;

        protected static int TargetMain(int param) =>
            TargetMainResult.Invoke(param);

        protected static IPipelineBuilderCompleteTestSut CreateSut(IServiceProvider? serviceProvider = null) =>
            new PipelineBuilderCompleteTestSut(serviceProvider);

        #region Types

        public interface IPipelineBuilderCompleteTestSut : IPipelineBuilderComplete<int, int, IPipelineBuilderCompleteTestSut, IPipeline<int, int>> { }

        protected class PipelineBuilderCompleteTestSut :
            PipelineBuilderComplete<int, int, IPipelineBuilderCompleteTestSut, IPipeline<int, int>>,
            IPipelineBuilderCompleteTestSut
        {
            public PipelineBuilderCompleteTestSut(IServiceProvider? serviceProvider = null) : base(serviceProvider) { }
        }

        #endregion Types
    }
}
