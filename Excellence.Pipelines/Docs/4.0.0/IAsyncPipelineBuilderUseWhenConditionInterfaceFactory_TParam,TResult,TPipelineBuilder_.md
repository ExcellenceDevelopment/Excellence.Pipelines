#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Async](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Async 'Excellence.Pipelines.Core.PipelineBuilders.Async')

## IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder> Interface

The pipeline builder with the possibility to execute the pipeline steps conditionally.

```csharp
public interface IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<System.Func<TParam, System.Threading.CancellationToken, System.Threading.Tasks.Task<TResult>>, TPipelineBuilder>
    where TPipelineBuilder : class, Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IAsyncPipelineBuilderUseWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhenConditionInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TParam](IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_)'></a>

## IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.UseWhen<TPipelineCondition>(Func<TPipelineCondition>, Action<TPipelineBuilder>, Func<TPipelineBuilder>) Method

Adds the pipeline branch with own configuration that is executed when the condition is met.  
When the condition is met the branch is executed and then the main pipeline is executed.  
When the condition is NOT met the branch is skipped and the main pipeline is executed.

```csharp
TPipelineBuilder UseWhen<TPipelineCondition>(System.Func<TPipelineCondition> pipelineConditionFactory, System.Action<TPipelineBuilder> branchPipelineBuilderConfiguration, System.Func<TPipelineBuilder> branchPipelineBuilderFactory)
    where TPipelineCondition : class, Excellence.Pipelines.Core.PipelineConditions.IAsyncPipelineCondition<TParam>;
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).TPipelineCondition'></a>

`TPipelineCondition`
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).pipelineConditionFactory'></a>

`pipelineConditionFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TPipelineCondition](IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).TPipelineCondition 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.UseWhen<TPipelineCondition>(System.Func<TPipelineCondition>, System.Action<TPipelineBuilder>, System.Func<TPipelineBuilder>).TPipelineCondition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The pipeline builder condition factory.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).branchPipelineBuilderConfiguration'></a>

`branchPipelineBuilderConfiguration` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TPipelineBuilder](IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The branch pipeline builder configuration.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).branchPipelineBuilderFactory'></a>

`branchPipelineBuilderFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TPipelineBuilder](IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The pipeline builder factory.

#### Returns
[TPipelineBuilder](IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.