using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Async.Complete.Conditions.BranchWhen;

public class AsyncPipelineBuilderBranchWhenInterfaceTests : AsyncPipelineBuilderBranchWhenTestsBase
{
    #region Null checks

    #region Params

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .BranchWhen((Func<AsyncPipelineConditionTrue>)null!, ConfigurationWithBranchTarget, PipelineBuilderFactory),
            (builder) => builder
                .BranchWhen(() => (AsyncPipelineConditionTrue?)null!, ConfigurationWithBranchTarget, PipelineBuilderFactory),
            (builder) => builder
                .BranchWhen(PipelineConditionTrueFactory, null!, PipelineBuilderFactory),
            (builder) => builder
                .BranchWhen(PipelineConditionTrueFactory, ConfigurationWithBranchTarget, null!),
            (builder) => builder
                .BranchWhen(PipelineConditionTrueFactory, ConfigurationWithBranchTarget, () => (IAsyncPipelineBuilderCompleteTestSut?)null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen((Func<IServiceProvider, AsyncPipelineConditionTrue>)null!, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen((_) => (AsyncPipelineConditionTrue?)null!, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<AsyncPipelineConditionTrue>()
                        .AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .BranchWhen(PipelineConditionTrueFactoryWithServiceProvider, null!, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithBranchTarget, null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithBranchTarget, (_) => (IAsyncPipelineBuilderCompleteTestSut?)null!),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen<AsyncPipelineConditionTrue>(null!)
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
                .BranchWhen((sp) => sp.GetRequiredService<AsyncPipelineConditionTrue>(), ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen
                    (PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithBranchTarget, (sp) => sp.GetRequiredService<AsyncPipelineBuilderCompleteTestSut>()),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .BranchWhen<AsyncPipelineConditionTrue>(ConfigurationWithBranchTarget)
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
                .BranchWhen(PipelineConditionTrueFactory, ConfigurationWithBranchTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),
            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<AsyncPipelineConditionTrue>()
                        .AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .BranchWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionTrue>().BuildServiceProvider())
                .BranchWhen<AsyncPipelineConditionTrue>(ConfigurationWithBranchTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionTrueChecksTestData))]
    public async Task BranchWhen_ConditionTrue_AddsComponentToPipeline
    (
        Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var tempArg = new PipelineArg();
        await TargetBranchResult.Invoke(tempArg, CancellationToken.None);

        var expectedResult = (tempArg.Value - 1) * (tempArg.Value - 1);

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var arg = new PipelineArg();
        await pipeline.Invoke(arg, CancellationToken.None);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
    }

    public static TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>> ConditionFalseChecksTestData =>
        new TheoryData<Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .BranchWhen(PipelineConditionFalseFactory, ConfigurationWithBranchTarget, PipelineBuilderFactory)
                .UseTarget(TargetMain),
            (builder) => builder
                .UseServiceProvider
                (
                    new ServiceCollection()
                        .AddTransient<AsyncPipelineConditionFalse>()
                        .AddTransient<IAsyncPipelineBuilderCompleteTestSut, AsyncPipelineBuilderCompleteTestSut>()
                        .BuildServiceProvider()
                )
                .BranchWhen(PipelineConditionFalseFactoryWithServiceProvider, ConfigurationWithBranchTarget, PipelineBuilderFactoryWithServiceProvider)
                .UseTarget(TargetMain),
            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<AsyncPipelineConditionFalse>().BuildServiceProvider())
                .BranchWhen<AsyncPipelineConditionFalse>(ConfigurationWithBranchTarget)
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(ConditionFalseChecksTestData))]
    public async Task BranchWhen_ConditionFalse_AddsComponentToPipeline
    (
        Func<IAsyncPipelineBuilderCompleteTestSut, IAsyncPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var tempArg = new PipelineArg();
        await TargetMainResult.Invoke(tempArg, CancellationToken.None);

        var expectedResult = tempArg.Value;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var arg = new PipelineArg();
        await pipeline.Invoke(arg, CancellationToken.None);

        var actualResult = arg.Value;

        Assert.Equal(expectedResult, actualResult);
    }
}
