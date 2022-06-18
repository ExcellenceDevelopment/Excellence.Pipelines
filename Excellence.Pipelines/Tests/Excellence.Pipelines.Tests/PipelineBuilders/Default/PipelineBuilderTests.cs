using System;
using System.Diagnostics.CodeAnalysis;

using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilders;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Default
{
    public class PipelineBuilderTests
    {
        #region Shared

        protected IPipelineBuilder<int, int> CreateSut(IServiceProvider serviceProvider) =>
            new PipelineBuilder<int, int>(serviceProvider);

        #endregion Shared

        #region Constructors

        [Fact]
        public void Constructor_CreatesInstance()
        {
            var sut = this.CreateSut(new ServiceCollection().BuildServiceProvider());

            Assert.NotNull(sut);
        }

        #endregion Constructors

        #region Usage

        [Fact]
        [ExcludeFromCodeCoverage]
        public void Usage()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<PipelineStep>()
                .AddTransient<PipelineConditionTrue>()
                .AddTransient<PipelineConditionFalse>()
                .AddTransient<IPipelineBuilder<int, int>>(sp => new PipelineBuilder<int, int>(sp))
                .BuildServiceProvider();

            var factory = new PipelineBuilderFactory(serviceProvider);

            var pipelineBuilder = factory.CreatePipelineBuilder<int, int>();

            Func<Func<int, int>, Func<int, int>> component =
                next => (param) =>
                {
                    var modifiedParam = param + 5;

                    return next.Invoke(modifiedParam);
                };

            // Use component

            pipelineBuilder.Use(component);

            // Use components

            pipelineBuilder.Use(new[] { component, component, component });

            // Use interface

            // pipeline step is provided by the factory
            pipelineBuilder.Use(() => new PipelineStep());

            // pipeline step is provided by the factory accepting service provider
            pipelineBuilder.Use((sp) => sp.GetRequiredService<PipelineStep>());

            // pipeline step is provided by the service provider
            pipelineBuilder.Use<PipelineStep>();


            // UseWhen - predicate

            // branch pipeline builder is provided by the factory
            pipelineBuilder.UseWhen
            (
                (param) => param == -1,
                builder => builder.Use(() => new PipelineStep()),
                () => new PipelineBuilder<int, int>(serviceProvider)
            );

            // branch pipeline builder is provided by the factory accepting service provider
            pipelineBuilder.UseWhen
            (
                (param) => param == -1,
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
                (sp) => sp.GetRequiredService<IPipelineBuilder<int, int>>()
            );

            // branch pipeline builder is provided by the service provider
            pipelineBuilder.UseWhen
            (
                (param) => param == -1,
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>())
            );

            // UseWhen - interface

            /* ... */

            // condition and branch pipeline builder are provided by the factory
            pipelineBuilder.UseWhen
            (
                () => new PipelineConditionTrue(),
                builder => builder.Use(() => new PipelineStep()),
                () => new PipelineBuilder<int, int>(serviceProvider)
            );

            // condition and branch pipeline builder are provided by the factory accepting service provider
            pipelineBuilder.UseWhen
            (
                (sp) => sp.GetRequiredService<PipelineConditionTrue>(),
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
                (sp) => sp.GetRequiredService<IPipelineBuilder<int, int>>()
            );

            // condition and branch pipeline builder are provided by the service provider
            pipelineBuilder.UseWhen<PipelineConditionTrue>(builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()));

            // BranchWhen - predicate

            // branch pipeline builder is provided by the factory
            pipelineBuilder.BranchWhen
            (
                (param) => param == -1,
                builder => builder.Use(() => new PipelineStep()).UseTarget((param) => param - 2),
                () => new PipelineBuilder<int, int>(serviceProvider)
            );

            // branch pipeline builder is provided by the factory accepting service provider
            pipelineBuilder.BranchWhen
            (
                (param) => param == -1,
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param) => param - 2),
                (sp) => sp.GetRequiredService<IPipelineBuilder<int, int>>()
            );

            // branch pipeline builder is provided by the service provider
            pipelineBuilder.BranchWhen
            (
                (param) => param == -1,
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param) => param - 2)
            );

            // BranchWhen - interface

            // condition and branch pipeline builder are provided by the factory
            pipelineBuilder.BranchWhen
            (
                () => new PipelineConditionFalse(),
                builder => builder.Use(() => new PipelineStep()).UseTarget((param) => param - 2),
                () => new PipelineBuilder<int, int>(serviceProvider)
            );

            // condition and branch pipeline builder are provided by the factory accepting service provider
            pipelineBuilder.BranchWhen
            (
                (sp) => sp.GetRequiredService<PipelineConditionFalse>(),
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param) => param - 2),
                (sp) => sp.GetRequiredService<IPipelineBuilder<int, int>>()
            );

            // condition and branch pipeline builder are provided by the service provider
            pipelineBuilder.BranchWhen<PipelineConditionFalse>(builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param) => param - 2));

            // UseTarget

            pipelineBuilder.UseTarget((param) => param + 1);

            var service = new TargetService();
            pipelineBuilder.UseTarget(service.Compute);

            // BuildPipeline

            var pipeline = pipelineBuilder.BuildPipeline();

            // execute the pipeline
            var pipelineResult = pipeline.Invoke(2);

            // Copy

            // components and target are copied from the source pipeline builder
            var pipelineBuilderCopy = pipelineBuilder.Copy();
            var pipelineCopy = pipelineBuilderCopy.BuildPipeline();

            var pipelineCopyResult = pipelineCopy.Invoke(2);

            var expectedResult = 1472;

            Assert.Equal(expectedResult, pipelineResult);
            Assert.Equal(pipelineResult, pipelineCopyResult);
        }

        [ExcludeFromCodeCoverage]
        protected class PipelineStep : IPipelineStep<int, int>
        {
            public int Invoke(int param, Func<int, int> next)
            {
                var nextResult = next.Invoke(param);

                var result = nextResult * 2;

                return result;
            }
        }

        [ExcludeFromCodeCoverage]
        protected class PipelineConditionTrue : IPipelineCondition<int>
        {
            public bool Invoke(int param) => true;
        }

        [ExcludeFromCodeCoverage]
        protected class PipelineConditionFalse : IPipelineCondition<int>
        {
            public bool Invoke(int param) => false;
        }

        [ExcludeFromCodeCoverage]
        protected class TargetService
        {
            public int Compute(int param) => param + 1;
        }

        #endregion Usage
    }
}
