using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async;

public class AsyncPipelineBuilderUseWhenInterfaceTests : AsyncPipelineBuilderConditionTestsBase
{
    #region Null checks

    #region Params

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen((Func<AsyncPipelineConditionTrue>)null!, ConfigurationWithoutTarget, PipelineBuilderFactory),
            (builder) => builder
                .UseWhen(() => (AsyncPipelineConditionTrue?)null!, ConfigurationWithoutTarget, PipelineBuilderFactory),
            (builder) => builder
                .UseWhen(PipelineConditionTrueFactory, null!, PipelineBuilderFactory),
            (builder) => builder
                .UseWhen(PipelineConditionTrueFactory, ConfigurationWithoutTarget, null!),
            (builder) => builder
                .UseWhen(PipelineConditionTrueFactory, ConfigurationWithoutTarget, () => (IAsyncPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen((Func<IServiceProvider, AsyncPipelineConditionTrue>)null!, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen((_) => (AsyncPipelineConditionTrue?)null!, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<AsyncPipelineConditionTrue>()
                        .AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, null!, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithoutTarget, null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithoutTarget, (_) => (IAsyncPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .UseWhen<AsyncPipelineConditionTrue>(null!)
        };

    [Theory]
    [MemberData(nameof(ParamNullChecksTestData))]
    public void UseWhen_Param_IsNull_ThrowsException(Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration)
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
                .UseWhen((sp) => sp.GetRequiredService<AsyncPipelineConditionTrue>(), ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithoutTarget, (sp) => sp.GetRequiredService<AsyncPipelineBuilderCompleteTestSut>()),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen<AsyncPipelineConditionTrue>(ConfigurationWithoutTarget)
        };

    [Theory]
    [MemberData(nameof(ServiceProviderResultNullChecksTestData))]
    public void UseWhen_ServiceProvider_ServiceProviderResult_IsNull_ThrowsException
    (
        Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var sut = CreateSut();

        Assert.Throws<InvalidOperationException>(() => pipelineBuilderConfiguration.Invoke(sut));
    }

    #endregion Service provider

    #endregion Null checks

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ConditionTrueChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen(PipelineConditionTrueFactory, ConfigurationWithoutTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<AsyncPipelineConditionTrue>()
                        .AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .UseWhen<AsyncPipelineConditionTrue>(ConfigurationWithoutTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionTrueChecksTestData))]
    public async Task UseWhen_ConditionTrue_AddsComponentToPipeline
    (
        Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

        var expectedResult = (targetMainResult - 1) * (targetMainResult - 1);

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = await pipeline.Invoke(this.Arg, CancellationToken.None);

        Assert.Equal(expectedResult, actualResult);
    }

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ConditionFalseChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen(PipelineConditionFalseFactory, ConfigurationWithoutTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<AsyncPipelineConditionFalse>()
                        .AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .UseWhen(PipelineConditionFalseFactoryWithServiceProvider, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionFalse>().BuildServiceProvider())
                .UseWhen<AsyncPipelineConditionFalse>(ConfigurationWithoutTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionFalseChecksTestData))]
    public async Task UseWhen_ConditionFalse_AddsComponentToPipeline
    (
        Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

        var expectedResult = targetMainResult;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = await pipeline.Invoke(this.Arg, CancellationToken.None);

        Assert.Equal(expectedResult, actualResult);
    }
}