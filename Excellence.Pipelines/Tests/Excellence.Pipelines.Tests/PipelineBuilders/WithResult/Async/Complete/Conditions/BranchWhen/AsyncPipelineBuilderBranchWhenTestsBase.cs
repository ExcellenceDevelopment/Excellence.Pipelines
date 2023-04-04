using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Async;

public abstract class AsyncPipelineBuilderBranchWhenTestsBase : AsyncPipelineBuilderConditionTestsBase
{
    protected static Action<IAsyncPipelineBuilderCompleteTestSut> ConfigurationWithBranchTarget => builder =>
        builder.Use(ComponentForConfiguration)
            .UseTarget(TargetBranch);

    protected static Func<PipelineArg, CancellationToken, Task<PipelineArg>> TargetBranchResult =>
        (param, _) =>
        {
            param.Value *= 2;

            return Task.FromResult(param);
        };

    protected static Task<PipelineArg> TargetBranch(PipelineArg param, CancellationToken cancellationToken) =>
        TargetBranchResult.Invoke(param, cancellationToken);
}
