using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Default;

public class PipelineBuilderBranchWhenPredicateTests : PipelineBuilderBranchWhenTestsBase
{
    #region Null checks

    #region Params

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .BranchWhen((Func<PipelineArg, bool>)null!, ConfigurationWithBranchTarget, PipelineBuilderFactory),
            (builder) => builder
                .BranchWhen(PredicateTrue, null!, () => CreateSut()),
            (builder) => builder
                .BranchWhen(PredicateTrue, ConfigurationWithBranchTarget, (Func<PipelineBuilderCompleteTestSut>)null!),
            (builder) => builder
                .BranchWhen(PredicateTrue, ConfigurationWithBranchTarget, () => (IPipelineBuilderCompleteTestSut)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .BranchWhen((Func<PipelineArg, bool>)null!, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen(PredicateTrue, null!, (_) => CreateSut()),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen(PredicateTrue, ConfigurationWithBranchTarget, (Func<IServiceProvider, PipelineBuilderCompleteTestSut>)null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen(PredicateTrue, ConfigurationWithBranchTarget, (_) => (IPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .BranchWhen((Func<PipelineArg, bool>)null!, ConfigurationWithBranchTarget),
            (builder) => builder
                .BranchWhen(PredicateTrue, null!)
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
                .BranchWhen(PredicateTrue, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider)
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
                .BranchWhen(PredicateTrue, ConfigurationWithBranchTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .BranchWhen(PredicateTrue, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .BranchWhen(PredicateTrue, ConfigurationWithBranchTarget)
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
                .BranchWhen(PredicateFalse, ConfigurationWithBranchTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IPipelineBuilderCompleteTestSut, PipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .BranchWhen(PredicateFalse, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .BranchWhen(PredicateFalse, ConfigurationWithBranchTarget)
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
