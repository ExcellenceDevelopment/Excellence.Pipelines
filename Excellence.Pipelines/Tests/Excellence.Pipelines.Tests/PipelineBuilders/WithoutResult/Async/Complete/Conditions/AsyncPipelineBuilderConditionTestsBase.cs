using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithoutResult.Async.Complete.Conditions;

public abstract class AsyncPipelineBuilderConditionTestsBase : AsyncPipelineBuilderCompleteTestsBase
{
    protected static Func<Func<PipelineArg, CancellationToken, Task>, Func<PipelineArg, CancellationToken, Task>> ComponentForConfiguration =>
        next => async (param, cancellationToken) =>
        {
            await next.Invoke(param, cancellationToken);

            var temp = param.Value - 1;

            param.Value = temp * temp;
        };

    protected static Action<IAsyncPipelineBuilderCompleteTestSut> ConfigurationWithoutTarget =>
        builder => builder.Use(ComponentForConfiguration);

    #region Factories

    #region Pipeline builders

    protected static Func<IAsyncPipelineBuilderCompleteTestSut> PipelineBuilderFactory => () => CreateSut();

    protected static Func<IServiceProvider, IAsyncPipelineBuilderCompleteTestSut> PipelineBuilderFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<IAsyncPipelineBuilderCompleteTestSut>();

    #endregion

    #region Pipeline conditions

    protected static Func<IAsyncPipelineCondition<PipelineArg>> PipelineConditionTrueFactory => () => new AsyncPipelineConditionTrue();

    protected static Func<IServiceProvider, IAsyncPipelineCondition<PipelineArg>> PipelineConditionTrueFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<AsyncPipelineConditionTrue>();


    protected static Func<IAsyncPipelineCondition<PipelineArg>> PipelineConditionFalseFactory => () => new AsyncPipelineConditionFalse();

    protected static Func<IServiceProvider, IAsyncPipelineCondition<PipelineArg>> PipelineConditionFalseFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<AsyncPipelineConditionFalse>();

    #endregion

    #endregion

    #region Conditions

    #region Predicates

    protected static Func<PipelineArg, Task<bool>> PredicateAsyncTrue => (_) => Task.FromResult(true);
    protected static Func<PipelineArg, Task<bool>> PredicateAsyncFalse => (_) => Task.FromResult(false);

    #endregion

    #region Instances

    protected class AsyncPipelineConditionTrue : IAsyncPipelineCondition<PipelineArg>
    {
        public virtual Task<bool> Invoke(PipelineArg param) => Task.FromResult(true);
    }

    protected class AsyncPipelineConditionFalse : IAsyncPipelineCondition<PipelineArg>
    {
        public virtual Task<bool> Invoke(PipelineArg param) => Task.FromResult(false);
    }

    #endregion

    #endregion
}
