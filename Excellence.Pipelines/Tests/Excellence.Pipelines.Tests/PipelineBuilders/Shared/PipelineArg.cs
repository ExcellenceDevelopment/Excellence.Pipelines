namespace Excellence.Pipelines.Tests.PipelineBuilders.Shared;

public class PipelineArg
{
    public int Value { get; set; }

    public PipelineArg(int value = 1024) => this.Value = value;
}
