using System.Diagnostics.CodeAnalysis;

using Excellence.Pipelines.Core.PipelineBuilders;
using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Core.PipelineSteps;
using Excellence.Pipelines.PipelineBuilderFactories;
using Excellence.Pipelines.PipelineBuilders;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

using Xunit;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Default;

public class PipelineBuilderTests
{
    #region Shared

    protected IPipelineBuilder<PipelineArg> CreateSut(IServiceProvider serviceProvider) =>
        new PipelineBuilder<PipelineArg>(serviceProvider);

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
    public void Usage()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<PipelineStep>()
            .AddTransient<PipelineConditionTrue>()
            .AddTransient<PipelineConditionFalse>()
            .AddTransient<IPipelineBuilder<PipelineArg>>(sp => new PipelineBuilder<PipelineArg>(sp))
            .BuildServiceProvider();

        var factory = new PipelineBuilderFactory(serviceProvider);

        var pipelineBuilder = factory.CreatePipelineBuilder<PipelineArg>();

        // Use

        Func<Action<PipelineArg>, Action<PipelineArg>> component =
            next => (param) =>
            {
                param.Value += 5;

                next.Invoke(param);
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
            (param) => param.Value == -1,
            builder => builder.Use(() => new PipelineStep()),
            () => new PipelineBuilder<PipelineArg>(serviceProvider)
        );

        // branch pipeline builder is provided by the factory accepting service provider
        pipelineBuilder.UseWhen
        (
            (param) => param.Value == -1,
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
            (sp) => sp.GetRequiredService<IPipelineBuilder<PipelineArg>>()
        );

        // branch pipeline builder is provided by the service provider
        pipelineBuilder.UseWhen
        (
            (param) => param.Value == -1,
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>())
        );

        // UseWhen - interface

        /* ... */

        // condition and branch pipeline builder are provided by the factory
        pipelineBuilder.UseWhen
        (
            () => new PipelineConditionTrue(),
            builder => builder.Use(() => new PipelineStep()),
            () => new PipelineBuilder<PipelineArg>(serviceProvider)
        );

        // condition and branch pipeline builder are provided by the factory accepting service provider
        pipelineBuilder.UseWhen
        (
            (sp) => sp.GetRequiredService<PipelineConditionTrue>(),
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
            (sp) => sp.GetRequiredService<IPipelineBuilder<PipelineArg>>()
        );

        // condition and branch pipeline builder are provided by the service provider
        pipelineBuilder.UseWhen<PipelineConditionTrue>(builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()));

        // BranchWhen - predicate

        // branch pipeline builder is provided by the factory
        pipelineBuilder.BranchWhen
        (
            (param) => param.Value == -1,
            builder => builder.Use(() => new PipelineStep()).UseTarget((param) => param.Value -= 2),
            () => new PipelineBuilder<PipelineArg>(serviceProvider)
        );

        // branch pipeline builder is provided by the factory accepting service provider
        pipelineBuilder.BranchWhen
        (
            (param) => param.Value == -1,
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param) => param.Value -= 2),
            (sp) => sp.GetRequiredService<IPipelineBuilder<PipelineArg>>()
        );

        // branch pipeline builder is provided by the service provider
        pipelineBuilder.BranchWhen
        (
            (param) => param.Value == -1,
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param) => param.Value -= 2)
        );

        // BranchWhen - interface

        // condition and branch pipeline builder are provided by the factory
        pipelineBuilder.BranchWhen
        (
            () => new PipelineConditionFalse(),
            builder => builder.Use(() => new PipelineStep()).UseTarget((param) => param.Value -= 2),
            () => new PipelineBuilder<PipelineArg>(serviceProvider)
        );

        // condition and branch pipeline builder are provided by the factory accepting service provider
        pipelineBuilder.BranchWhen
        (
            (sp) => sp.GetRequiredService<PipelineConditionFalse>(),
            builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param) => param.Value -= 2),
            (sp) => sp.GetRequiredService<IPipelineBuilder<PipelineArg>>()
        );

        // condition and branch pipeline builder are provided by the service provider
        pipelineBuilder.BranchWhen<PipelineConditionFalse>(builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param) => param.Value -= 2));

        // UseTarget

        pipelineBuilder.UseTarget((param) => param.Value += 1);

        var service = new TargetService();
        pipelineBuilder.UseTarget(service.Compute);

        // BuildPipeline

        var pipeline = pipelineBuilder.BuildPipeline();

        // execute the pipeline
        var arg = new PipelineArg() { Value = 2 };
        pipeline.Invoke(arg);
        var pipelineResult = arg.Value;

        // Copy

        // components and target are copied from the source pipeline builder
        var pipelineBuilderCopy = pipelineBuilder.Copy();
        var pipelineCopy = pipelineBuilderCopy.BuildPipeline();

        var argCopy = new PipelineArg() { Value = 2 };
        pipelineCopy.Invoke(argCopy);
        var pipelineCopyResult = argCopy.Value;

        var expectedResult = 1472;

        Assert.Equal(expectedResult, pipelineResult);
        Assert.Equal(pipelineResult, pipelineCopyResult);
    }

    [ExcludeFromCodeCoverage]
    protected class PipelineStep : IPipelineStep<PipelineArg>
    {
        public void Invoke(PipelineArg param, Action<PipelineArg> next)
        {
            next.Invoke(param);

            param.Value *= 2;
        }
    }

    [ExcludeFromCodeCoverage]
    protected class PipelineConditionTrue : IPipelineCondition<PipelineArg>
    {
        public bool Invoke(PipelineArg param) => true;
    }

    [ExcludeFromCodeCoverage]
    protected class PipelineConditionFalse : IPipelineCondition<PipelineArg>
    {
        public bool Invoke(PipelineArg param) => false;
    }

    [ExcludeFromCodeCoverage]
    protected class TargetService
    {
        public void Compute(PipelineArg param) => param.Value += 1;
    }

    #endregion
}
