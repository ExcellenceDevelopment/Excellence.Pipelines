﻿using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async;

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

    #endregion Params

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

    #endregion Service provider

    #endregion Null checks

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
        var targetMainResult = await TargetMainResult.Invoke(this.Arg, CancellationToken.None);

        var expectedResult = targetMainResult;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = await pipeline.Invoke(this.Arg, CancellationToken.None);

        Assert.Equal(expectedResult, actualResult);
    }
}
