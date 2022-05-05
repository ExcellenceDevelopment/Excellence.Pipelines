#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Default](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Default 'Excellence.Pipelines.Core.PipelineBuilders.Default')

## IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline> Interface

The pipeline builder with the possibility to add a pipeline steps.

```csharp
public interface IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,out TPipelineBuilder,out TPipeline> :
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<System.Func<TParam, TResult>, TPipelineBuilder, TPipeline>,
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<System.Func<TParam, TResult>, TPipelineBuilder, TPipeline>
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
    where TPipeline : Excellence.Pipelines.Core.Pipelines.IPipeline<TParam, TResult>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipeline'></a>

`TPipeline`

The pipeline type.

Derived  
&#8627; [IPipelineBuilderComplete&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderComplete_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderComplete<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderStepInterface&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderStepInterface_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterface<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider&lt;](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TResult](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[,](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineBuilder](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')[,](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipeline](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipeline 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipeline')[&gt;](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>'), [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TResult](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineBuilder](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipeline](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipeline 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipeline')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.Use_TPipelineStep_(System.Func_System.IServiceProvider,TPipelineStep_)'></a>

## IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.Use<TPipelineStep>(Func<IServiceProvider,TPipelineStep>) Method

Add the pipeline step.  
Requires the service provider to be set.

```csharp
TPipelineBuilder Use<TPipelineStep>(System.Func<System.IServiceProvider,TPipelineStep> factory)
    where TPipelineStep : Excellence.Pipelines.Core.PipelineSteps.IPipelineStep<TParam, TResult>;
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.Use_TPipelineStep_(System.Func_System.IServiceProvider,TPipelineStep_).TPipelineStep'></a>

`TPipelineStep`

The pipeline step type.
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.Use_TPipelineStep_(System.Func_System.IServiceProvider,TPipelineStep_).factory'></a>

`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TPipelineStep](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.Use_TPipelineStep_(System.Func_System.IServiceProvider,TPipelineStep_).TPipelineStep 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.Use<TPipelineStep>(System.Func<System.IServiceProvider,TPipelineStep>).TPipelineStep')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The pipeline step factory.

#### Returns
[TPipelineBuilder](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')  
The current pipeline builder instance.