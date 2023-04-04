using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Default.Complete.Conditions.BranchWhen;

public abstract class PipelineBuilderBranchWhenTestsBase : PipelineBuilderConditionTestsBase
{
    protected static Action<IPipelineBuilderCompleteTestSut> ConfigurationWithBranchTarget => builder =>
        builder.Use(ComponentForConfiguration)
            .UseTarget(TargetBranch);

    protected static Action<PipelineArg> TargetBranchResult =>
        (param) => param.Value *= 2;

    protected static void TargetBranch(PipelineArg param) =>
        TargetBranchResult.Invoke(param);
}
