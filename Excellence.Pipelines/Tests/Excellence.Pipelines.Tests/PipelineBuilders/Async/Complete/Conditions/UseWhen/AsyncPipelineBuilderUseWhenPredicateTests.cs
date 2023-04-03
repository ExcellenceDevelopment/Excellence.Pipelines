using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async;

public class AsyncPipelineBuilderUseWhenPredicateTests : AsyncPipelineBuilderConditionTestsBase
{
    #region Null checks

    #region Params

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen((Func<int, Task<bool>>)null!, ConfigurationWithoutTarget, PipelineBuilderFactory),
            (builder) => builder
                .UseWhen(PredicateAsyncTrue, null!, () => CreateSut()),
            (builder) => builder
                .UseWhen(PredicateAsyncTrue, ConfigurationWithoutTarget, (Func<AsyncPipelineBuilderCompleteTestSut>)null!),
            (builder) => builder
                .UseWhen(PredicateAsyncTrue, ConfigurationWithoutTarget, () => (IAsyncPipelineBuilderCompleteTestSut)null!),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .UseWhen((Func<int, Task<bool>>)null!, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen(PredicateAsyncTrue, null!, (_) => CreateSut()),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen(PredicateAsyncTrue, ConfigurationWithoutTarget, (Func<IServiceProvider, AsyncPipelineBuilderCompleteTestSut>)null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .UseWhen(PredicateAsyncTrue, ConfigurationWithoutTarget, (_) => (IAsyncPipelineBuilderCompleteTestSut?)null!),

            (builder) => builder
                .UseWhen((Func<int, Task<bool>>)null!, ConfigurationWithoutTarget),
            (builder) => builder
                .UseWhen(PredicateAsyncTrue, null!)
        };

    [Theory]
    [MemberData(nameof(ParamNullChecksTestData))]
    public void UseWhen_Param_IsNull_ThrowsException(Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration)
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
                .UseWhen(PredicateAsyncTrue, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),
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

    #endregion

    #endregion

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ConditionTrueChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .UseWhen(PredicateAsyncTrue, ConfigurationWithoutTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .UseWhen(PredicateAsyncTrue, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseWhen(PredicateAsyncTrue, ConfigurationWithoutTarget)
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
                .UseWhen(PredicateAsyncFalse, ConfigurationWithoutTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>().BuildServiceProvider())
                .UseWhen(PredicateAsyncFalse, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseWhen(PredicateAsyncFalse, ConfigurationWithoutTarget)
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
