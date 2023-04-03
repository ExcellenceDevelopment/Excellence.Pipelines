using Excellence.Pipelines.Core.PipelineBuilderFactories;
using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.PipelineBuilders;

namespace Excellence.Pipelines.PipelineBuilderFactories;

/// <inheritdoc />
public class PipelineBuilderFactory : IPipelineBuilderFactory
{
    protected IServiceProvider ServiceProvider { get; }

    public PipelineBuilderFactory(IServiceProvider serviceProvider)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);

        this.ServiceProvider = serviceProvider;
    }

    /// <inheritdoc />
    public virtual IPipelineBuilder<TParam> CreatePipelineBuilder<TParam>() =>
        new PipelineBuilder<TParam>(this.ServiceProvider);

    /// <inheritdoc />
    public virtual IPipelineBuilder<TParam, TResult> CreatePipelineBuilder<TParam, TResult>() =>
        new PipelineBuilder<TParam, TResult>(this.ServiceProvider);
}
