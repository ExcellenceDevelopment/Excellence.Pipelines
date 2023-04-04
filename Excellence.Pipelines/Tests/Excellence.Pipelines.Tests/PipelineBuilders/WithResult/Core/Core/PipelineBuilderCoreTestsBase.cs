using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Core;

public abstract class PipelineBuilderCoreTestsBase
{
    protected static Func<PipelineArg, CancellationToken, Task<PipelineArg>> TargetMainResult =>
        (param, _) =>
        {
            param.Value = param.Value * 3 + 1;

            return Task.FromResult(param);
        };

    protected static Task<PipelineArg> TargetMain(PipelineArg param, CancellationToken cancellationToken) =>
        TargetMainResult.Invoke(param, cancellationToken);
}
