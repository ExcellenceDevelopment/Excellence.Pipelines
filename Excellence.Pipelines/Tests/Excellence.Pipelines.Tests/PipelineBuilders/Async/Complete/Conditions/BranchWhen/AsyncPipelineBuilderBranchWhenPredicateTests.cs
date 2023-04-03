using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async;

public class AsyncPipelineBuilderBranchWhenPredicateTests : AsyncPipelineBuilderBranchWhenTestsBase
{
    #region Null checks

    #region Params

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .BranchWhen((Func<int, Task<bool>>)null!, ConfigurationWithBranchTarget, PipelineBuilderFactory),
            (builder) => builder
                .BranchWhen(PredicateAsyncTrue, null!, () => CreateSut()),
            (builder) => builder
                .BranchWhen(PredicateAsyncTrue, ConfigurationWithBranchTarget, (Func<AsyncPipelineBuilderCompleteTestSut>)null!),
            (builder) => builder
                .BranchWhen(PredicateAsyncTrue, ConfigurationWithBranchTarget, () => (IAsyncPipelineBuilderCompleteTestSut)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .BranchWhen((Func<int, Task<bool>>)null!, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen(PredicateAsyncTrue, null!, (_) => CreateSut()),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen(PredicateAsyncTrue, ConfigurationWithBranchTarget, (Func<IServiceProvider, AsyncPipelineBuilderCompleteTestSut>)null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen(PredicateAsyncTrue, ConfigurationWithBranchTarget, (_) => (IAsyncPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .BranchWhen((Func<int, Task<bool>>)null!, ConfigurationWithBranchTarget),
            (builder) => builder
                .BranchWhen(PredicateAsyncTrue, null!)
        };

    [Theory]
    [MemberData(nameof(ParamNullChecksTestData))]
    public void BranchWhen_Param_IsNull_ThrowsException(Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration)
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
                .BranchWhen(PredicateAsyncTrue, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider),
        };

    [Theory]
    [MemberData(nameof(ServiceProviderResultNullChecksTestData))]
    public void BranchWhen_ServiceProvider_ServiceProviderResult_IsNull_ThrowsException
    (
        Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var sut = CreateSut();

        Assert.Throws<InvalidOperationException>(() => pipelineBuilderConfiguration.Invoke(sut));
    }

    #endregion

    #endregion

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ConditionTrueChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .BranchWhen(PredicateAsyncTrue, ConfigurationWithBranchTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .BranchWhen(PredicateAsyncTrue, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .BranchWhen(PredicateAsyncTrue, ConfigurationWithBranchTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionTrueChecksTestData))]
    public async Task BranchWhen_ConditionTrue_AddsComponentToPipeline
    (
        Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var targetBranchResult = await TargetBranchResult.Invoke(this.Arg, CancellationToken.None);

        var expectedResult = (targetBranchResult - 1) * (targetBranchResult - 1);

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = await pipeline.Invoke(this.Arg, CancellationToken.None);

        Assert.Equal(expectedResult, actualResult);
    }

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ConditionFalseChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .BranchWhen(PredicateAsyncFalse, ConfigurationWithBranchTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .BranchWhen(PredicateAsyncFalse, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .BranchWhen(PredicateAsyncFalse, ConfigurationWithBranchTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionFalseChecksTestData))]
    public async Task BranchWhen_ConditionFalse_AddsComponentToPipeline
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
