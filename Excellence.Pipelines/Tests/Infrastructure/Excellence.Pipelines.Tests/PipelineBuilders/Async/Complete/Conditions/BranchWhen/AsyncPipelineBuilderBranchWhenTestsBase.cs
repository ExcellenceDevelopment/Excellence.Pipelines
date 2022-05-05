using System;
using System.Threading;
using System.Threading.Tasks;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async.Complete
{
    public abstract class AsyncPipelineBuilderBranchWhenTestsBase : AsyncPipelineBuilderConditionTestsBase
    {
        protected static Action<IAsyncPipelineBuilderCompleteTestSut> ConfigurationWithBranchTarget => builder =>
            builder.Use(ComponentForConfiguration)
                .UseTarget(TargetBranch);

        protected static Func<int, CancellationToken, Task<int>> TargetBranchResult =>
            (param, _) => Task.FromResult(param * 2);

        protected static Task<int> TargetBranch(int param, CancellationToken cancellationToken) =>
            TargetBranchResult.Invoke(param, cancellationToken);
    }
}
