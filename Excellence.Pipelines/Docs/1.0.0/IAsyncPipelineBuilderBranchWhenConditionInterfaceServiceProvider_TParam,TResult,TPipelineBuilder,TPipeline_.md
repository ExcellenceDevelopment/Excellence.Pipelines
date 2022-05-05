#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Async](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Async 'Excellence.Pipelines.Core.PipelineBuilders.Async')

## IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline> Interface

The pipeline builder with the possibility to execute the pipeline steps conditionally.

```csharp
public interface IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,out TPipelineBuilder,out TPipeline> :
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<System.Func<TParam, System.Threading.CancellationToken, System.Threading.Tasks.Task<TResult>>, TPipelineBuilder, TPipeline>,
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<System.Func<TParam, System.Threading.CancellationToken, System.Threading.Tasks.Task<TResult>>, TPipelineBuilder, TPipeline>
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
    where TPipeline : Excellence.Pipelines.Core.Pipelines.IAsyncPipeline<TParam, TResult>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipeline'></a>

`TPipeline`

The pipeline type.

Derived  
&#8627; [IAsyncPipelineBuilderBranchWhen&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderBranchWhen_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhen<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderBranchWhenConditionInterface_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterface<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderComplete&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderComplete_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderComplete<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider&lt;](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TParam](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[,](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineBuilder](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')[,](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipeline](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipeline 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipeline')[&gt;](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>'), [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TParam](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineBuilder](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipeline](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipeline 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipeline')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.BranchWhen_TPipelineCondition_(System.Action_TPipelineBuilder_)'></a>

## IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.BranchWhen<TPipelineCondition>(Action<TPipelineBuilder>) Method

Adds the pipeline branch with own configuration that is executed when the condition is met.  
When the condition is met the branch is executed and the main pipeline is NOT executed.  
When the condition is NOT met the branch is skipped and the main pipeline is executed.  
Requires the service provider to be set.

```csharp
TPipelineBuilder BranchWhen<TPipelineCondition>(System.Action<TPipelineBuilder> branchPipelineBuilderConfiguration)
    where TPipelineCondition : Excellence.Pipelines.Core.PipelineConditions.IAsyncPipelineCondition<TParam>;
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.BranchWhen_TPipelineCondition_(System.Action_TPipelineBuilder_).TPipelineCondition'></a>

`TPipelineCondition`
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.BranchWhen_TPipelineCondition_(System.Action_TPipelineBuilder_).branchPipelineBuilderConfiguration'></a>

`branchPipelineBuilderConfiguration` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TPipelineBuilder](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The branch pipeline builder configuration.

#### Returns
[TPipelineBuilder](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')  
The current pipeline builder instance.