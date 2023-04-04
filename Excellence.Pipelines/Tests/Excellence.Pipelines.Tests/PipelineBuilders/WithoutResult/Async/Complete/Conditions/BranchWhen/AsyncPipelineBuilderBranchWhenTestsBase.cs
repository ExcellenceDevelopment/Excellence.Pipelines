using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Async.Complete.Conditions.BranchWhen;

public abstract class AsyncPipelineBuilderBranchWhenTestsBase : AsyncPipelineBuilderConditionTestsBase
{
    protected static Action<IAsyncPipelineBuilderCompleteTestSut> ConfigurationWithBranchTarget => builder =>
        builder.Use(ComponentForConfiguration)
            .UseTarget(TargetBranch);

    protected static Func<PipelineArg, CancellationToken, Task> TargetBranchResult =>
        (param, _) =>
        {
            param.Value *= 2;

            return Task.CompletedTask;
        };

    protected static Task TargetBranch(PipelineArg param, CancellationToken cancellationToken) =>
        TargetBranchResult.Invoke(param, cancellationToken);
}
