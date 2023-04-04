using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Default;

public class PipelineBuilderBranchWhenInterfaceTests : PipelineBuilderBranchWhenTestsBase
{
    #region Null checks

    #region Params

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .BranchWhen((Func<PipelineConditionTrue>)null!, ConfigurationWithBranchTarget, PipelineBuilderFactory),
            (builder) => builder
                .BranchWhen(() => (PipelineConditionTrue?)null!, ConfigurationWithBranchTarget, PipelineBuilderFactory),
            (builder) => builder
                .BranchWhen(PipelineConditionTrueFactory, null!, PipelineBuilderFactory),
            (builder) => builder
                .BranchWhen(PipelineConditionTrueFactory, ConfigurationWithBranchTarget, null!),
            (builder) => builder
                .BranchWhen(PipelineConditionTrueFactory, ConfigurationWithBranchTarget, () => (IPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen((Func<IServiceProvider, PipelineConditionTrue>)null!, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen((_) => (PipelineConditionTrue?)null!, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<PipelineConditionTrue>()
                        .AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .BranchWhen(PipelineConditionTrueFactoryWithServiceProvider, null!, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithBranchTarget, null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithBranchTarget, (_) => (IPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen<PipelineConditionTrue>(null!)
        };

    [Theory]
    [MemberData(nameof(ParamNullChecksTestData))]
    public void BranchWhen_Param_IsNull_ThrowsException(Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration)
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
                .BranchWhen((sp) => sp.GetRequiredService<PipelineConditionTrue>(), ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithBranchTarget, (sp) => sp.GetRequiredService<PipelineBuilderCompleteTestSut>()),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen<PipelineConditionTrue>(ConfigurationWithBranchTarget)
        };

    [Theory]
    [MemberData(nameof(ServiceProviderResultNullChecksTestData))]
    public void BranchWhen_ServiceProvider_ServiceProviderResult_IsNull_ThrowsException
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
                .BranchWhen(PipelineConditionTrueFactory, ConfigurationWithBranchTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<PipelineConditionTrue>()
                        .AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .BranchWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen<PipelineConditionTrue>(ConfigurationWithBranchTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionTrueChecksTestData))]
    public void BranchWhen_ConditionTrue_AddsComponentToPipeline
    (
        Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var targetBranchResult = TargetBranchResult.Invoke(new PipelineArg());

        var expectedResult = (targetBranchResult.Value - 1) * (targetBranchResult.Value - 1);

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = pipeline.Invoke(new PipelineArg());

        Assert.Equal(expectedResult, actualResult.Value);
    }

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ConditionFalseChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .BranchWhen(PipelineConditionFalseFactory, ConfigurationWithBranchTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<PipelineConditionFalse>()
                        .AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .BranchWhen(PipelineConditionFalseFactoryWithServiceProvider, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineConditionFalse>().BuildServiceProvider())
                .BranchWhen<PipelineConditionFalse>(ConfigurationWithBranchTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionFalseChecksTestData))]
    public void BranchWhen_ConditionFalse_AddsComponentToPipeline
    (
        Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var targetMainResult = TargetMainResult.Invoke(new PipelineArg());

        var expectedResult = targetMainResult.Value;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = pipeline.Invoke(new PipelineArg());

        Assert.Equal(expectedResult, actualResult.Value);
    }
}
