using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Core.Core;

public abstract class PipelineBuilderCoreTestsBase
{
    protected static Func<PipelineArg, CancellationToken, Task> TargetMainResult =>
        (param, _) =>
        {
            param.Value = param.Value * 3 + 1;

            return Task.CompletedTask;
        };

    protected static Task TargetMain(PipelineArg param, CancellationToken cancellationToken) =>
        TargetMainResult.Invoke(param, cancellationToken);
}
