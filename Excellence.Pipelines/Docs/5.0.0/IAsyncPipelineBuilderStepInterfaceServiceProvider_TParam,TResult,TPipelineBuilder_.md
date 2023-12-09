#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Async](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Async 'Excellence.Pipelines.Core.PipelineBuilders.Async')

## IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder> Interface

The pipeline builder with the possibility to add a pipeline steps.

```csharp
public interface IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,out TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<System.Func<TParam, System.Threading.CancellationToken, System.Threading.Tasks.Task<TResult>>, TPipelineBuilder>
    where TPipelineBuilder : class, Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam, TResult, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IAsyncPipelineBuilderStepInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderStepInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TParam](IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.Use_TPipelineStep_()'></a>

## IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>.Use<TPipelineStep>() Method

Add the pipeline step.

```csharp
TPipelineBuilder Use<TPipelineStep>()
    where TPipelineStep : class, Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep<TParam, TResult>;
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.Use_TPipelineStep_().TPipelineStep'></a>

`TPipelineStep`

The pipeline step type.

#### Returns
[TPipelineBuilder](IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.