using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Default.Complete.Conditions.UseWhen;

public class PipelineBuilderUseWhenInterfaceTests : PipelineBuilderConditionTestsBase
{
    #region Null checks

    #region Params

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen((Func<PipelineConditionTrue>)null!, ConfigurationWithoutTarget, PipelineBuilderFactory),
            (builder) => builder
                .UseWhen(() => (PipelineConditionTrue?)null!, ConfigurationWithoutTarget, PipelineBuilderFactory),
            (builder) => builder
                .UseWhen(PipelineConditionTrueFactory, null!, PipelineBuilderFactory),
            (builder) => builder
                .UseWhen(PipelineConditionTrueFactory, ConfigurationWithoutTarget, null!),
            (builder) => builder
                .UseWhen(PipelineConditionTrueFactory, ConfigurationWithoutTarget, () => (IPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen((Func<IServiceProvider, PipelineConditionTrue>)null!, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen((_) => (PipelineConditionTrue?)null!, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<PipelineConditionTrue>()
                        .AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, null!, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithoutTarget, null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithoutTarget, (_) => (IPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .UseWhen<PipelineConditionTrue>(null!)
        };

    [Theory]
    [MemberData(nameof(ParamNullChecksTestData))]
    public void UseWhen_Param_IsNull_ThrowsException(Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration)
    {
        var sut = CreateSut();

        Assert.Throws<ArgumentNullException>(() => pipelineBuilderConfiguration.Invoke(sut));
    }

    #endregion

    #region Service provider

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ServiceProviderResultNullChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen((sp) => sp.GetRequiredService<PipelineConditionTrue>(), ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithoutTarget, (sp) => sp.GetRequiredService<PipelineBuilderCompleteTestSut>()),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen<PipelineConditionTrue>(ConfigurationWithoutTarget)
        };

    [Theory]
    [MemberData(nameof(ServiceProviderResultNullChecksTestData))]
    public void UseWhen_ServiceProvider_ServiceProviderResult_IsNull_ThrowsException
    (
        Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var sut = CreateSut();

        Assert.Throws<InvalidOperationException>(() => pipelineBuilderConfiguration.Invoke(sut));
    }

    #endregion

    #endregion

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ConditionTrueChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen(PipelineConditionTrueFactory, ConfigurationWithoutTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<PipelineConditionTrue>()
                        .AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .UseWhen<PipelineConditionTrue>(ConfigurationWithoutTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionTrueChecksTestData))]
    public void UseWhen_ConditionTrue_AddsComponentToPipeline
    (
        Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var tempArg = new PipelineArg();
        TargetMainResult.Invoke(tempArg);

        var expectedResult = (tempArg.Value - 1) * (tempArg.Value - 1);

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var arg = new PipelineArg();
        pipeline.Invoke(arg);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
    }

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ConditionFalseChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen(PipelineConditionFalseFactory, ConfigurationWithoutTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<PipelineConditionFalse>()
                        .AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .UseWhen(PipelineConditionFalseFactoryWithServiceProvider, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionFalse>().BuildServiceProvider())
                .UseWhen<PipelineConditionFalse>(ConfigurationWithoutTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionFalseChecksTestData))]
    public void UseWhen_ConditionFalse_AddsComponentToPipeline
    (
        Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var tempArg = new PipelineArg();
        TargetMainResult.Invoke(tempArg);

        var expectedResult = tempArg.Value;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var arg = new PipelineArg();
        pipeline.Invoke(arg);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
    }
}
