using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilders;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async
{
    public class AsyncPipelineBuilderTests
    {
        #region Shared

        protected IAsyncPipelineBuilder<int, int> CreateSut(IServiceProvider serviceProvider) =>
            new AsyncPipelineBuilder<int, int>(serviceProvider);

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
        public async Task Usage()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<PipelineStep>()
                .AddTransient<PipelineConditionTrue>()
                .AddTransient<PipelineConditionFalse>()
                .AddTransient<IAsyncPipelineBuilder<int, int>>(sp => new AsyncPipelineBuilder<int, int>(sp))
                .BuildServiceProvider();

            var factory = new AsyncPipelineBuilderFactory(serviceProvider);

            var pipelineBuilder = factory.CreateAsyncPipelineBuilder<int, int>();

            // Use component

            pipelineBuilder.Use
            (
                next => (param, cancellationToken) =>
                {
                    var modifiedParam = param + 5;

                    return next.Invoke(modifiedParam, cancellationToken);
                }
            );

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
                (param) => Task.FromResult(param == -1),
                builder => builder.Use(() => new PipelineStep()),
                () => new AsyncPipelineBuilder<int, int>(serviceProvider)
            );

            // branch pipeline builder is provided by the factory accepting service provider
            pipelineBuilder.UseWhen
            (
                (param) => Task.FromResult(param == -1),
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
                (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<int, int>>()
            );

            // branch pipeline builder is provided by the service provider
            pipelineBuilder.UseWhen
            (
                (param) => Task.FromResult(param == -1),
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>())
            );

            // UseWhen - interface

            /* ... */

            // condition and branch pipeline builder are provided by the factory
            pipelineBuilder.UseWhen
            (
                () => new PipelineConditionTrue(),
                builder => builder.Use(() => new PipelineStep()),
                () => new AsyncPipelineBuilder<int, int>(serviceProvider)
            );

            // condition and branch pipeline builder are provided by the factory accepting service provider
            pipelineBuilder.UseWhen
            (
                (sp) => sp.GetRequiredService<PipelineConditionTrue>(),
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
                (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<int, int>>()
            );

            // condition and branch pipeline builder are provided by the service provider
            pipelineBuilder.UseWhen<PipelineConditionTrue>(builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()));

            // BranchWhen - predicate

            // branch pipeline builder is provided by the factory
            pipelineBuilder.BranchWhen
            (
                (param) => Task.FromResult(param == -1),
                builder => builder.Use(() => new PipelineStep()).UseTarget((param, _) => Task.FromResult(param - 2)),
                () => new AsyncPipelineBuilder<int, int>(serviceProvider)
            );

            // branch pipeline builder is provided by the factory accepting service provider
            pipelineBuilder.BranchWhen
            (
                (param) => Task.FromResult(param == -1),
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param, _) => Task.FromResult(param - 2)),
                (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<int, int>>()
            );

            // branch pipeline builder is provided by the service provider
            pipelineBuilder.BranchWhen
            (
                (param) => Task.FromResult(param == -1),
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param, _) => Task.FromResult(param - 2))
            );

            // BranchWhen - interface

            // condition and branch pipeline builder are provided by the factory
            pipelineBuilder.BranchWhen
            (
                () => new PipelineConditionFalse(),
                builder => builder.Use(() => new PipelineStep()).UseTarget((param, _) => Task.FromResult(param - 2)),
                () => new AsyncPipelineBuilder<int, int>(serviceProvider)
            );

            // condition and branch pipeline builder are provided by the factory accepting service provider
            pipelineBuilder.BranchWhen
            (
                (sp) => sp.GetRequiredService<PipelineConditionFalse>(),
                builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param, _) => Task.FromResult(param - 2)),
                (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<int, int>>()
            );

            // condition and branch pipeline builder are provided by the service provider
            pipelineBuilder.BranchWhen<PipelineConditionFalse>
                (builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param, _) => Task.FromResult(param - 2)));

            // UseTarget

            pipelineBuilder.UseTarget((param, _) => Task.FromResult(param + 1));

            var service = new TargetService();
            pipelineBuilder.UseTarget(service.Compute);

            // BuildPipeline

            var pipeline = pipelineBuilder.BuildPipeline();

            // execute the pipeline
            var pipelineResult = await pipeline.Invoke(2, CancellationToken.None);

            // Copy

            // components and target are copied from the source pipeline builder
            var pipelineBuilderCopy = pipelineBuilder.Copy();
            var pipelineCopy = pipelineBuilderCopy.BuildPipeline();

            var pipelineCopyResult = await pipelineCopy.Invoke(2, CancellationToken.None);

            var expectedResult = 512;

            Assert.Equal(expectedResult, pipelineResult);
            Assert.Equal(pipelineResult, pipelineCopyResult);
        }

        [ExcludeFromCodeCoverage]
        protected class PipelineStep : IAsyncPipelineStep<int, int>
        {
            public async Task<int> Invoke(int param, CancellationToken cancellationToken, Func<int, CancellationToken, Task<int>> next)
            {
                var nextResult = await next.Invoke(param, cancellationToken);

                var result = nextResult * 2;

                return result;
            }
        }

        [ExcludeFromCodeCoverage]
        protected class PipelineConditionTrue : IAsyncPipelineCondition<int>
        {
            public Task<bool> Invoke(int param) => Task.FromResult(true);
        }

        [ExcludeFromCodeCoverage]
        protected class PipelineConditionFalse : IAsyncPipelineCondition<int>
        {
            public Task<bool> Invoke(int param) => Task.FromResult(false);
        }

        [ExcludeFromCodeCoverage]
        protected class TargetService
        {
            public Task<int> Compute(int param, CancellationToken cancellationToken) => Task.FromResult(param + 1);
        }

        #endregion Usage
    }
}
