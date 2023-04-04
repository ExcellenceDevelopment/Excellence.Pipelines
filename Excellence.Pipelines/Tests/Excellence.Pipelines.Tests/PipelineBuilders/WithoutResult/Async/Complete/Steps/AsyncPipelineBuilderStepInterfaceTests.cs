using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Async.Complete.Steps;

public class AsyncPipelineBuilderStepInterfaceTests : AsyncPipelineBuilderCompleteTestsBase
{
    #region Shared

    #region Factories

    private static Func<IAsyncPipelineStep<PipelineArg>> PipelineStepFactory => () => new PipelineStep();

    private static Func<IServiceProvider, IAsyncPipelineStep<PipelineArg>> PipelineStepFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<IAsyncPipelineStep<PipelineArg>>();

    #endregion

    #region Steps

    protected class PipelineStep : IAsyncPipelineStep<PipelineArg>
    {
        public virtual async Task Invoke(PipelineArg param, CancellationToken cancellationToken, Func<PipelineArg, CancellationToken, Task> next)
        {
            await next.Invoke(param, cancellationToken);

            param.Value *= param.Value;
        }
    }

    #endregion

    #endregion

    #region Null checks

    #region Params

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .Use((Func<PipelineStep>?)null!),
            (builder) => builder
                .Use(() => (PipelineStep)null!),

            (builder) => builder
                .Use((Func<IServiceProvider, PipelineStep>?)null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .Use((_) => (PipelineStep)null!)
        };

    [Theory]
    [MemberData(nameof(ParamNullChecksTestData))]
    public void Use_Step_Param_IsNull_ThrowsException(Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration)
    {
        var sut = CreateSut();

        Assert.Throws<ArgumentNullException>(() => pipelineBuilderConfiguration.Invoke(sut));
    }

    #endregion

    #region Service provider

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ServiceProviderResultNullChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .Use(PipelineStepFactoryWithServiceProvider),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .Use<PipelineStep>()
        };

    [Theory]
    [MemberData(nameof(ServiceProviderResultNullChecksTestData))]
    public void Use_Step_ServiceProvider_ServiceProviderResult_IsNull_ThrowsException
    (
        Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var sut = CreateSut();

        Assert.Throws<InvalidOperationException>(() => pipelineBuilderConfiguration.Invoke(sut));
    }

    #endregion

    #endregion

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> PipelineStepTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .Use(PipelineStepFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IAsyncPipelineStep<PipelineArg>, PipelineStep>().BuildServiceProvider())
                .Use(PipelineStepFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineStep>().BuildServiceProvider())
                .Use<PipelineStep>()
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(PipelineStepTestData))]
    public async Task Use_Step_AddsComponentToPipeline
    (
        Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var tempArg = new PipelineArg();
        await TargetMainResult.Invoke(tempArg, CancellationToken.None);

        var expectedResult = tempArg.Value * tempArg.Value;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var arg = new PipelineArg();
        await pipeline.Invoke(arg, CancellationToken.None);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
    }
}
