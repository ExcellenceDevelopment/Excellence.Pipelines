using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Async;

public class AsyncPipelineBuilderStepInterfaceTests : AsyncPipelineBuilderCompleteTestsBase
{
    #region Shared

    #region Factories

    private static Func<IAsyncPipelineStep<PipelineArg, PipelineArg>> PipelineStepFactory => () => new PipelineStep();

    private static Func<IServiceProvider, IAsyncPipelineStep<PipelineArg, PipelineArg>> PipelineStepFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<IAsyncPipelineStep<PipelineArg, PipelineArg>>();

    #endregion

    #region Steps

    protected class PipelineStep : IAsyncPipelineStep<PipelineArg, PipelineArg>
    {
        public virtual async Task<PipelineArg> Invoke(PipelineArg param, CancellationToken cancellationToken, Func<PipelineArg, CancellationToken, Task<PipelineArg>> next)
        {
            var nextResult = await next.Invoke(param, cancellationToken);

            nextResult.Value *= nextResult.Value;

            return nextResult;
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
                .UseServiceProvider(new ServiceCollection().AddTransient<IAsyncPipelineStep<PipelineArg, PipelineArg>, PipelineStep>().BuildServiceProvider())
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
        var targetMainResult = await TargetMainResult.Invoke(new PipelineArg(), CancellationToken.None);

        var expectedResult = targetMainResult.Value * targetMainResult.Value;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = await pipeline.Invoke(new PipelineArg(), CancellationToken.None);

        Assert.Equal(expectedResult, actualResult.Value);
    }
}
