using System.Diagnostics.CodeAnalysis;

using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilders;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Async;

public class AsyncPipelineBuilderTests
{
    #region Shared

    protected IAsyncPipelineBuilder<PipelineArg> CreateSut(IServiceProvider serviceProvider) =>
        new AsyncPipelineBuilder<PipelineArg>(serviceProvider);

    #endregion

    #region Constructors

    [Fact]
    public void Constructor_CreatesInstance()
    {
        var sut = this.CreateSut(new ServiceCollection().BuildServiceProvider());

        Assert.NotNull(sut);
    }

    #endregion

    #region Usage

    [Fact]
    [ExcludeFromCodeCoverage]
    public async Task Usage()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<PipelineStep>()
            .AddTransient<PipelineConditionTrue>()
            .AddTransient<PipelineConditionFalse>()
            .AddTransient<IAsyncPipelineBuilder<PipelineArg>>(sp => new AsyncPipelineBuilder<PipelineArg>(sp))
            .BuildServiceProvider();

        var factory = new AsyncPipelineBuilderFactory(serviceProvider);

        var pipelineBuilder = factory.CreateAsyncPipelineBuilder<PipelineArg>();

        // Use

        Func<Func<PipelineArg, CancellationToken, Task>, Func<PipelineArg, CancellationToken, Task>> component =
            next => (param, cancellationToken) =>
            {
                param.Value += 5;

                return next.Invoke(param, cancellationToken);
            };

        // one component
        pipelineBuilder.Use(component);

        // collection of components
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
            (param) => Task.FromResult(param.Value == -1),
            builder => builder.Use(() => new PipelineStep()),
            () => new AsyncPipelineBuilder<PipelineArg>(serviceProvider)
        );

        // branch pipeline builder is provided by the factory accepting service provider
        pipelineBuilder.UseWhen
        (
            (param) => Task.FromResult(param.Value == -1),
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
            (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<PipelineArg>>()
        );

        // branch pipeline builder is provided by the service provider
        pipelineBuilder.UseWhen
        (
            (param) => Task.FromResult(param.Value == -1),
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>())
        );

        // UseWhen - interface

        /* ... */

        // condition and branch pipeline builder are provided by the factory
        pipelineBuilder.UseWhen
        (
            () => new PipelineConditionTrue(),
            builder => builder.Use(() => new PipelineStep()),
            () => new AsyncPipelineBuilder<PipelineArg>(serviceProvider)
        );

        // condition and branch pipeline builder are provided by the factory accepting service provider
        pipelineBuilder.UseWhen
        (
            (sp) => sp.GetRequiredService<PipelineConditionTrue>(),
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
            (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<PipelineArg>>()
        );

        // condition and branch pipeline builder are provided by the service provider
        pipelineBuilder.UseWhen<PipelineConditionTrue>(builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()));

        // BranchWhen - predicate

        // branch pipeline builder is provided by the factory
        pipelineBuilder.BranchWhen
        (
            (param) => Task.FromResult(param.Value == -1),
            builder => builder.Use(() => new PipelineStep()).UseTarget
            (
                (param, _) =>
                {
                    param.Value -= 2;

                    return Task.CompletedTask;
                }
            ),
            () => new AsyncPipelineBuilder<PipelineArg>(serviceProvider)
        );

        // branch pipeline builder is provided by the factory accepting service provider
        pipelineBuilder.BranchWhen
        (
            (param) => Task.FromResult(param.Value == -1),
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget
            (
                (param, _) =>
                {
                    param.Value -= 2;

                    return Task.CompletedTask;
                }
            ),
            (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<PipelineArg>>()
        );

        // branch pipeline builder is provided by the service provider
        pipelineBuilder.BranchWhen
        (
            (param) => Task.FromResult(param.Value == -1),
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget
            (
                (param, _) =>
                {
                    param.Value -= 2;

                    return Task.CompletedTask;
                }
            )
        );

        // BranchWhen - interface

        // condition and branch pipeline builder are provided by the factory
        pipelineBuilder.BranchWhen
        (
            () => new PipelineConditionFalse(),
            builder => builder.Use(() => new PipelineStep()).UseTarget
            (
                (param, _) =>
                {
                    param.Value -= 2;

                    return Task.CompletedTask;
                }
            ),
            () => new AsyncPipelineBuilder<PipelineArg>(serviceProvider)
        );

        // condition and branch pipeline builder are provided by the factory accepting service provider
        pipelineBuilder.BranchWhen
        (
            (sp) => sp.GetRequiredService<PipelineConditionFalse>(),
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget
            (
                (param, _) =>
                {
                    param.Value -= 2;

                    return Task.CompletedTask;
                }
            ),
            (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<PipelineArg>>()
        );

        // condition and branch pipeline builder are provided by the service provider
        pipelineBuilder.BranchWhen<PipelineConditionFalse>
        (
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget
            (
                (param, _) =>
                {
                    param.Value -= 2;

                    return Task.CompletedTask;
                }
            )
        );

        // UseTarget

        pipelineBuilder.UseTarget
        (
            (param, _) =>
            {
                param.Value += 1;

                return Task.CompletedTask;
            }
        );

        var service = new TargetService();
        pipelineBuilder.UseTarget(service.Compute);

        // BuildPipeline

        var pipeline = pipelineBuilder.BuildPipeline();

        // execute the pipeline
        var arg = new PipelineArg() { Value = 2 };
        await pipeline.Invoke(arg, CancellationToken.None);
        var pipelineResult = arg.Value;

        // Copy

        // components and target are copied from the source pipeline builder
        var pipelineBuilderCopy = pipelineBuilder.Copy();
        var pipelineCopy = pipelineBuilderCopy.BuildPipeline();

        var argCopy = new PipelineArg() { Value = 2 };
        await pipelineCopy.Invoke(argCopy, CancellationToken.None);
        var pipelineCopyResult = argCopy.Value;

        var expectedResult = 1472;

        Assert.Equal(expectedResult, pipelineResult);
        Assert.Equal(pipelineResult, pipelineCopyResult);
    }

    [ExcludeFromCodeCoverage]
    protected class PipelineStep : IAsyncPipelineStep<PipelineArg>
    {
        public async Task Invoke(PipelineArg param, CancellationToken cancellationToken, Func<PipelineArg, CancellationToken, Task> next)
        {
            await next.Invoke(param, cancellationToken);

            param.Value *= 2;
        }
    }

    [ExcludeFromCodeCoverage]
    protected class PipelineConditionTrue : IAsyncPipelineCondition<PipelineArg>
    {
        public Task<bool> Invoke(PipelineArg param) => Task.FromResult(true);
    }

    [ExcludeFromCodeCoverage]
    protected class PipelineConditionFalse : IAsyncPipelineCondition<PipelineArg>
    {
        public Task<bool> Invoke(PipelineArg param) => Task.FromResult(false);
    }

    [ExcludeFromCodeCoverage]
    protected class TargetService
    {
        public Task Compute(PipelineArg param, CancellationToken cancellationToken)
        {
            param.Value += 1;

            return Task.CompletedTask;
        }
    }

    #endregion
}
