#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Default](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Default 'Excellence.Pipelines.Core.PipelineBuilders.Default')

## IPipelineBuilderStepInterfaceFactory<TParam,TResult,TPipelineBuilder> Interface

The pipeline builder with the possibility to add a pipeline steps.

```csharp
public interface IPipelineBuilderStepInterfaceFactory<TParam,TResult,out TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<System.Func<TParam, TResult>, TPipelineBuilder>
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory<TParam, TResult, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IPipelineBuilderComplete&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderComplete_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderComplete<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderStepInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderStepInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TResult](IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory<TParam,TResult,TPipelineBuilder>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.Use_TPipelineStep_(System.Func_TPipelineStep_)'></a>

## IPipelineBuilderStepInterfaceFactory<TParam,TResult,TPipelineBuilder>.Use<TPipelineStep>(Func<TPipelineStep>) Method

Add the pipeline step.

```csharp
TPipelineBuilder Use<TPipelineStep>(System.Func<TPipelineStep> factory)
    where TPipelineStep : Excellence.Pipelines.Core.PipelineSteps.IPipelineStep<TParam, TResult>;
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.Use_TPipelineStep_(System.Func_TPipelineStep_).TPipelineStep'></a>

`TPipelineStep`

The pipeline step type.
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.Use_TPipelineStep_(System.Func_TPipelineStep_).factory'></a>

`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TPipelineStep](IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.Use_TPipelineStep_(System.Func_TPipelineStep_).TPipelineStep 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory<TParam,TResult,TPipelineBuilder>.Use<TPipelineStep>(System.Func<TPipelineStep>).TPipelineStep')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The pipeline step factory.

#### Returns
[TPipelineBuilder](IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.