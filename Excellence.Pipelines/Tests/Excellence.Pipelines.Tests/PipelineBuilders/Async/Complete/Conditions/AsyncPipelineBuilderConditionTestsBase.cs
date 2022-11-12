using Excellence.Pipelines.Core.PipelineConditions;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Async
{
    public abstract class AsyncPipelineBuilderConditionTestsBase : AsyncPipelineBuilderCompleteTestsBase
    {
        protected static Func<Func<int, CancellationToken, Task<int>>, Func<int, CancellationToken, Task<int>>> ComponentForConfiguration =>
            next => async (param, cancellationToken) =>
            {
                var result = await next.Invoke(param, cancellationToken);

                var temp = result - 1;

                return temp * temp;
            };

        protected static Action<IAsyncPipelineBuilderCompleteTestSut> ConfigurationWithoutTarget =>
            builder => builder.Use(ComponentForConfiguration);

        #region Factories

        #region Pipeline builders

        protected static Func<IAsyncPipelineBuilderCompleteTestSut> PipelineBuilderFactory => () => CreateSut();

        protected static Func<IServiceProvider, IAsyncPipelineBuilderCompleteTestSut> PipelineBuilderFactoryWithServiceProvider => (sp) =>
            sp.GetRequiredService<IAsyncPipelineBuilderCompleteTestSut>();

        #endregion Pipeline builders

        #region Pipeline conditions

        protected static Func<IAsyncPipelineCondition<int>> PipelineConditionTrueFactory => () => new AsyncPipelineConditionTrue();

        protected static Func<IServiceProvider, IAsyncPipelineCondition<int>> PipelineConditionTrueFactoryWithServiceProvider => (sp) =>
            sp.GetRequiredService<AsyncPipelineConditionTrue>();


        protected static Func<IAsyncPipelineCondition<int>> PipelineConditionFalseFactory => () => new AsyncPipelineConditionFalse();

        protected static Func<IServiceProvider, IAsyncPipelineCondition<int>> PipelineConditionFalseFactoryWithServiceProvider => (sp) =>
            sp.GetRequiredService<AsyncPipelineConditionFalse>();

        #endregion Pipeline conditions

        #endregion Factories

        #region Conditions

        #region Predicates

        protected static Func<int, Task<bool>> PredicateAsyncTrue => (_) => Task.FromResult(true);
        protected static Func<int, Task<bool>> PredicateAsyncFalse => (_) => Task.FromResult(false);

        #endregion Predicates

        #region Instances

        protected class AsyncPipelineConditionTrue : IAsyncPipelineCondition<int>
        {
            public virtual Task<bool> Invoke(int param) => Task.FromResult(true);
        }

        protected class AsyncPipelineConditionFalse : IAsyncPipelineCondition<int>
        {
            public virtual Task<bool> Invoke(int param) => Task.FromResult(false);
        }

        #endregion Instances

        #endregion Conditions
    }
}
