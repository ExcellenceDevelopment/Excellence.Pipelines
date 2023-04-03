using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Default;

public class PipelineBuilderUseWhenPredicateTests : PipelineBuilderConditionTestsBase
{
    #region Null checks

    #region Params

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen((Func<int, bool>)null!, ConfigurationWithoutTarget, PipelineBuilderFactory),
            (builder) => builder
                .UseWhen(PredicateTrue, null!, () => CreateSut()),
            (builder) => builder
                .UseWhen(PredicateTrue, ConfigurationWithoutTarget, (Func<PipelineBuilderCompleteTestSut>)null!),
            (builder) => builder
                .UseWhen(PredicateTrue, ConfigurationWithoutTarget, () => (IPipelineBuilderCompleteTestSut)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .UseWhen((Func<int, bool>)null!, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen(PredicateTrue, null!, (_) => CreateSut()),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen(PredicateTrue, ConfigurationWithoutTarget, (Func<IServiceProvider, PipelineBuilderCompleteTestSut>)null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen(PredicateTrue, ConfigurationWithoutTarget, (_) => (IPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .UseWhen((Func<int, bool>)null!, ConfigurationWithoutTarget),
            (builder) => builder
                .UseWhen(PredicateTrue, null!)
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
                .UseWhen(PredicateTrue, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
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
                .UseWhen(PredicateTrue, ConfigurationWithoutTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .UseWhen(PredicateTrue, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseWhen(PredicateTrue, ConfigurationWithoutTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionTrueChecksTestData))]
    public void UseWhen_ConditionTrue_AddsComponentToPipeline
    (
        Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var targetMainResult = TargetMainResult.Invoke(this.Arg);

        var expectedResult = (targetMainResult - 1) * (targetMainResult - 1);

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = pipeline.Invoke(this.Arg);

        Assert.Equal(expectedResult, actualResult);
    }

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ConditionFalseChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen(PredicateFalse, ConfigurationWithoutTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .UseWhen(PredicateFalse, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseWhen(PredicateFalse, ConfigurationWithoutTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionFalseChecksTestData))]
    public void UseWhen_ConditionFalse_AddsComponentToPipeline
    (
        Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var targetMainResult = TargetMainResult.Invoke(this.Arg);

        var expectedResult = targetMainResult;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = pipeline.Invoke(this.Arg);

        Assert.Equal(expectedResult, actualResult);
    }
}
