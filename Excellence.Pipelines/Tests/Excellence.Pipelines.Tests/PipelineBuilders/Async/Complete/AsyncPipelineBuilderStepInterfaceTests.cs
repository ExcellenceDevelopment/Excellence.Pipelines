using Excellence.Pipelines.Core.PipelineSteps;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async;

public class AsyncPipelineBuilderStepInterfaceTests : AsyncPipelineBuilderCompleteTestsBase
{
    #region Shared

    #region Factories

    private static Func<IAsyncPipelineStep<int, int>> PipelineStepFactory => () => new PipelineStep();

    private static Func<IServiceProvider, IAsyncPipelineStep<int, int>> PipelineStepFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<IAsyncPipelineStep<int, int>>();

    #endregion Factories

    #region Steps

    protected class PipelineStep : IAsyncPipelineStep<int, int>
    {
        public virtual async Task<int> Invoke(int param, CancellationToken cancellationToken, Func<int, CancellationToken, Task<int>> next)
        {
            var nextResult = await next.Invoke(param, cancellationToken);

            return nextResult * nextResult;
        }
    }

    #endregion Steps

    #endregion Shared

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

    #endregion Params

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

    #endregion Service provider

    #endregion Null checks

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> PipelineStepTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .Use(PipelineStepFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IAsyncPipelineStep<int, int>, PipelineStep>().BuildServiceProvider())
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
        var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

        var expectedResult = targetMainResult * targetMainResult;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = await pipeline.Invoke(this.Arg, CancellationToken.None);

        Assert.Equal(expectedResult, actualResult);
    }
}