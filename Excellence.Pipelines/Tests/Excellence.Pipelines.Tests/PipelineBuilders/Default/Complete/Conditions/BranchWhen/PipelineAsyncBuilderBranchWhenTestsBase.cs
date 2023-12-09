namespace Excellence.Pipelines.Tests.PipelineBuilders.Default;

public abstract class PipelineBuilderBranchWhenTestsBase : PipelineBuilderConditionTestsBase
{
    protected static Action<IPipelineBuilderCompleteTestSut> ConfigurationWithBranchTarget => builder =>
        builder.Use(ComponentForConfiguration)
            .UseTarget(TargetBranch);

    protected static Func<int, int> TargetBranchResult =>
        (param) => param * 2;

    protected static int TargetBranch(int param) =>
        TargetBranchResult.Invoke(param);
}