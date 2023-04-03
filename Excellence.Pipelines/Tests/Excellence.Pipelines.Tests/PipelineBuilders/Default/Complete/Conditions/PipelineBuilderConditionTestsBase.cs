using Excellence.Pipelines.Core.PipelineConditions;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Default;

public abstract class PipelineBuilderConditionTestsBase : PipelineBuilderCompleteTestsBase
{
    protected static Func<Func<int, int>, Func<int, int>> ComponentForConfiguration =>
        next => (param) =>
        {
            var result = next.Invoke(param);

            var temp = result - 1;

            return temp * temp;
        };

    protected static Action<IPipelineBuilderCompleteTestSut> ConfigurationWithoutTarget =>
        builder => builder.Use(ComponentForConfiguration);

    #region Factories

    #region Pipeline builders

    protected static Func<IPipelineBuilderCompleteTestSut> PipelineBuilderFactory => () => CreateSut();

    protected static Func<IServiceProvider, IPipelineBuilderCompleteTestSut> PipelineBuilderFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<IPipelineBuilderCompleteTestSut>();

    #endregion

    #region Pipeline conditions

    protected static Func<IPipelineCondition<int>> PipelineConditionTrueFactory => () => new PipelineConditionTrue();

    protected static Func<IServiceProvider, IPipelineCondition<int>> PipelineConditionTrueFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<PipelineConditionTrue>();


    protected static Func<IPipelineCondition<int>> PipelineConditionFalseFactory => () => new PipelineConditionFalse();

    protected static Func<IServiceProvider, IPipelineCondition<int>> PipelineConditionFalseFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<PipelineConditionFalse>();

    #endregion

    #endregion

    #region Conditions

    #region Predicates

    protected static Func<int, bool> PredicateTrue => (_) => true;
    protected static Func<int, bool> PredicateFalse => (_) => false;

    #endregion

    #region Instances

    protected class PipelineConditionTrue : IPipelineCondition<int>
    {
        public virtual bool Invoke(int param) => true;
    }

    protected class PipelineConditionFalse : IPipelineCondition<int>
    {
        public virtual bool Invoke(int param) => false;
    }

    #endregion

    #endregion
}
