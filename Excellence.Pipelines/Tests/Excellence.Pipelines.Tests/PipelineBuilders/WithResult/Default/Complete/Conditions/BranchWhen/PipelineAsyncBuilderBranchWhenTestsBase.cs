using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Default;

public abstract class PipelineBuilderBranchWhenTestsBase : PipelineBuilderConditionTestsBase
{
    protected static Action<IPipelineBuilderCompleteTestSut> ConfigurationWithBranchTarget => builder =>
        builder.Use(ComponentForConfiguration)
            .UseTarget(TargetBranch);

    protected static Func<PipelineArg, PipelineArg> TargetBranchResult =>
        (param) =>
        {
            param.Value *= 2;

            return param;
        };

    protected static PipelineArg TargetBranch(PipelineArg param) =>
        TargetBranchResult.Invoke(param);
}
