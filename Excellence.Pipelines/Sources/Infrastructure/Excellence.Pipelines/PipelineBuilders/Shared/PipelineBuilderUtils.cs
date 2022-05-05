using System;

using Excellence.Pipelines.Utils;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.PipelineBuilders.Shared
{
    public partial class PipelineBuilderFromDelegate<TPipelineDelegate, TPipelineBuilder, TPipeline>
    {
        protected virtual TFactoryResult GetFromFactory<TFactoryResult>(Func<TFactoryResult> factory)
        {
            ExceptionUtils.Process(factory, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(factory)));

            return factory.Invoke();
        }

        protected virtual TFactoryResult GetFromFactory<TFactoryResult>(Func<IServiceProvider, TFactoryResult> factory)
        {
            ExceptionUtils.Process(factory, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(factory)));

            ExceptionUtils.Process
            (
                this.ServiceProvider,
                ExceptionUtils.IsNull,
                () => new InvalidOperationException(ErrorMessageUtils.CreateNoServiceProviderErrorMessage(this.GetType()))
            );

            return factory.Invoke(this.ServiceProvider!);
        }

        protected virtual TServiceProviderResult GetFromServiceProvider<TServiceProviderResult>() where TServiceProviderResult : notnull
        {
            ExceptionUtils.Process
            (
                this.ServiceProvider,
                ExceptionUtils.IsNull,
                () => new InvalidOperationException(ErrorMessageUtils.CreateNoServiceProviderErrorMessage(this.GetType()))
            );

            return this.ServiceProvider!.GetRequiredService<TServiceProviderResult>();
        }
    }
}
