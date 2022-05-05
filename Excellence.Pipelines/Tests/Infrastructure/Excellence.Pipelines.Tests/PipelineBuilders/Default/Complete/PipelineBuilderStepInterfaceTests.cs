using System;

using Excellence.Pipelines.Core.PipelineSteps;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Default.Complete
{
    public class PipelineBuilderStepInterfaceTests : PipelineBuilderTestsBase
    {
        #region Shared

        #region Factories

        private static Func<IPipelineStep<int, int>> PipelineStepFactory => () => new PipelineStep();

        private static Func<IServiceProvider, IPipelineStep<int, int>> PipelineStepFactoryWithServiceProvider => (sp) =>
            sp.GetRequiredService<IPipelineStep<int, int>>();

        #endregion Factories

        #region Steps

        protected class PipelineStep : IPipelineStep<int, int>
        {
            public virtual int Invoke(int param, Func<int, int> next)
            {
                var nextResult = next.Invoke(param);

                return nextResult * nextResult;
            }
        }

        #endregion Steps

        #endregion Shared

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

        #endregion Params

        #region Service provider

        public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> ServiceProviderNullChecksTestData =>
            new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
            {
                (builder) => builder
                    .Use(PipelineStepFactoryWithServiceProvider),
                (builder) => builder
                    .Use<PipelineStep>()
            };

        [Theory]
        [MemberData(nameof(ServiceProviderNullChecksTestData))]
        public void Use_Step_ServiceProvider_IsNull_ThrowsException
            (Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut> pipelineBuilderConfiguration)
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

        #endregion Service provider

        #endregion Null checks

        public static TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>> PipelineStepTestData =>
            new TheoryData<Func<IPipelineBuilderCompleteTestSut, IPipelineBuilderCompleteTestSut>>()
            {
                (builder) => builder
                    .Use(PipelineStepFactory)
                    .UseTarget(TargetMain),

                (builder) => builder
                    .UseServiceProvider(new ServiceCollection().AddTransient<IPipelineStep<int, int>, PipelineStep>().BuildServiceProvider())
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
            var targetMainResult = TargetMainResult.Invoke(this.Arg);

            var expectedResult = targetMainResult * targetMainResult;

            var sut = CreateSut();

            var pipeline = pipelineBuilderConfiguration.Invoke(sut).BuildPipeline();

            var actualResult = pipeline.Invoke(this.Arg);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
