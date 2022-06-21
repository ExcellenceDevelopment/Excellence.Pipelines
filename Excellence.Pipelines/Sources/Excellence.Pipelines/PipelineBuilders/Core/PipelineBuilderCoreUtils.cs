using System;
using System.Collections.Generic;
using System.Linq;

using Excellence.Pipelines.Utils;

using Microsoft.Extensions.DependencyInjection;

namespace Excellence.Pipelines.PipelineBuilders.Core
{
    public partial class PipelineBuilderCoreComplete<TPipelineDelegate, TPipelineBuilder>
    {
        protected IServiceProvider ServiceProvider { get; set; }

        public PipelineBuilderCoreComplete(IServiceProvider serviceProvider)
        {
            ExceptionUtils.Process(serviceProvider, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(serviceProvider)));

            this.ServiceProvider = serviceProvider;
        }

        /// <inheritdoc />
        public virtual TPipelineBuilder Copy()
        {
            var newInstance = (PipelineBuilderCoreComplete<TPipelineDelegate, TPipelineBuilder>)this.MemberwiseClone();
            newInstance.Components = this.Components.Select(item => (Func<TPipelineDelegate, TPipelineDelegate>)item.Clone()).ToList();
            newInstance.Target = (TPipelineDelegate?)this.Target?.Clone();
            newInstance.ServiceProvider = this.ServiceProvider;

            return (TPipelineBuilder)(object)newInstance;
        }

        protected virtual TPipelineBuilder New()
        {
            var newInstance = (PipelineBuilderCoreComplete<TPipelineDelegate, TPipelineBuilder>)this.MemberwiseClone();
            newInstance.Components = new List<Func<TPipelineDelegate, TPipelineDelegate>>();
            newInstance.Target = null;

            return (TPipelineBuilder)(object)newInstance;
        }

        protected virtual TFactoryResult GetFromFactory<TFactoryResult>(Func<TFactoryResult> factory)
        {
            ExceptionUtils.Process(factory, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(factory)));

            return factory.Invoke();
        }

        protected virtual TFactoryResult GetFromFactory<TFactoryResult>(Func<IServiceProvider, TFactoryResult> factory)
        {
            ExceptionUtils.Process(factory, ExceptionUtils.IsNull, () => new ArgumentNullException(nameof(factory)));

            return factory.Invoke(this.ServiceProvider);
        }

        protected virtual TServiceProviderResult GetFromServiceProvider<TServiceProviderResult>() where TServiceProviderResult : notnull =>
            this.ServiceProvider.GetRequiredService<TServiceProviderResult>();
    }
}
