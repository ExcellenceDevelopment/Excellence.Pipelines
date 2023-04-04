using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Default;

public class PipelineBuilderStepInterfaceTests : PipelineBuilderCompleteTestsBase
{
    #region Shared

    #region Factories

    private static Func<IPipelineStep<PipelineArg, PipelineArg>> PipelineStepFactory => () => new PipelineStep();

    private static Func<IServiceProvider, IPipelineStep<PipelineArg, PipelineArg>> PipelineStepFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<IPipelineStep<PipelineArg, PipelineArg>>();

    #endregion

    #region Steps

    protected class PipelineStep : IPipelineStep<PipelineArg, PipelineArg>
    {
        public virtual PipelineArg Invoke(PipelineArg param, Func<PipelineArg, PipelineArg> next)
        {
            var nextResult = next.Invoke(param);

            nextResult.Value *= nextResult.Value;

            return nextResult;
        }
    }

    #endregion

    #endregion

    #region Null checks

    #region Params

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ParamNullChecksTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
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
    public void Use_Step_Param_IsNull_ThrowsException(Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration)
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
                .Use(PipelineStepFactoryWithServiceProvider),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().BuildServiceProvider())
                .Use<PipelineStep>()
        };

    [Theory]
    [MemberData(nameof(ServiceProviderResultNullChecksTestData))]
    public void Use_Step_ServiceProvider_ServiceProviderResult_IsNull_ThrowsException
    (
        Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var sut = CreateSut();

        Assert.Throws<InvalidOperationException>(() => pipelineBuilderConfiguration.Invoke(sut));
    }

    #endregion

    #endregion

    public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> PipelineStepTestData =>
        new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
        {
            (builder) => builder
                .Use(PipelineStepFactory)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<IPipelineStep<PipelineArg, PipelineArg>, PipelineStep>().BuildServiceProvider())
                .Use(PipelineStepFactoryWithServiceProvider)
                .UseTarget(TargetMain),

            (builder) => builder
                .UseServiceProvider(new ServiceCollection().AddTransient<PipelineStep>().BuildServiceProvider())
                .Use<PipelineStep>()
                .UseTarget(TargetMain)
        };

    [Theory]
    [MemberData(nameof(PipelineStepTestData))]
    public void Use_Step_AddsComponentToPipeline
    (
        Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration
    )
    {
        var targetMainResult = TargetMainResult.Invoke(new PipelineArg());

        var expectedResult = targetMainResult.Value * targetMainResult.Value;

        var sut = CreateSut();

        var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

        var actualResult = pipeline.Invoke(new PipelineArg());

        Assert.Equal(expectedResult, actualResult.Value);
    }
}
