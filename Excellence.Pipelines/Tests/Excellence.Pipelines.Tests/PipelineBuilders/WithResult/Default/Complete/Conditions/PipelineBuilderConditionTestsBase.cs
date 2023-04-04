using Excellence.Pipelines.Core.PipelineConditions;
using Excellence.Pipelines.Tests.PipelineBuilders.Shared;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.Tests.PipelineBuilders.WithResult.Default;

public abstract class PipelineBuilderConditionTestsBase : PipelineBuilderCompleteTestsBase
{
    protected static Func<Func<PipelineArg, PipelineArg>, Func<PipelineArg, PipelineArg>> ComponentForConfiguration =>
        next => (param) =>
        {
            var result = next.Invoke(param);

            var temp = result.Value - 1;

            result.Value = temp * temp;

            return result;
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

    protected static Func<IPipelineCondition<PipelineArg>> PipelineConditionTrueFactory => () => new PipelineConditionTrue();

    protected static Func<IServiceProvider, IPipelineCondition<PipelineArg>> PipelineConditionTrueFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<PipelineConditionTrue>();


    protected static Func<IPipelineCondition<PipelineArg>> PipelineConditionFalseFactory => () => new PipelineConditionFalse();

    protected static Func<IServiceProvider, IPipelineCondition<PipelineArg>> PipelineConditionFalseFactoryWithServiceProvider => (sp) =>
        sp.GetRequiredService<PipelineConditionFalse>();

    #endregion

    #endregion

    #region Conditions

    #region Predicates

    protected static Func<PipelineArg, bool> PredicateTrue => (_) => true;
    protected static Func<PipelineArg, bool> PredicateFalse => (_) => false;

    #endregion

    #region Instances

    protected class PipelineConditionTrue : IPipelineCondition<PipelineArg>
    {
        public virtual bool Invoke(PipelineArg param) => true;
    }

    protected class PipelineConditionFalse : IPipelineCondition<PipelineArg>
    {
        public virtual bool Invoke(PipelineArg param) => false;
    }

    #endregion

    #endregion
}
