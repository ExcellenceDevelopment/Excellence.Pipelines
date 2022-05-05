using System;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Default.Complete
{
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

        #endregion Params

        #region Service provider

        public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ServiceProviderNullChecksTestData =>
            new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
            {
                (builder) => builder
                    .UseWhen(PipelineConditionTrueFactoryWithServiceProvider, ConfigurationWithoutTarget, PipelineBuilderFactoryWithServiceProvider),

                (builder) => builder
                    .UseWhen<PipelineConditionTrue>(ConfigurationWithoutTarget)
            };

        [Theory]
        [MemberData(nameof(ServiceProviderNullChecksTestData))]
        public void UseWhen_ServiceProvider_IsNull_ThrowsException(Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration)
        {
            var sut = CreateSut();

            var expectedResultMessage = $"The service provider is not set for the {sut.GetType()}.";

            var actualResult = Assert.Throws<InvalidOperationException>(() => pipelineBuilderConfiguration.Invoke(sut));

            Assert.Equal(expectedResultMessage, actualResult.Message);
        }

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

        #endregion Service provider

        #endregion Null checks

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
                    .UseTarget(TargetMain),
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
                    .UseTarget(TargetMain),
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
}
