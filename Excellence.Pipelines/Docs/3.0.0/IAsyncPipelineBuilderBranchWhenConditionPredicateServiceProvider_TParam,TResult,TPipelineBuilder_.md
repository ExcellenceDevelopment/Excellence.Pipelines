#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Async](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Async 'Excellence.Pipelines.Core.PipelineBuilders.Async')

## IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder> Interface

The pipeline builder with the possibility to execute the pipeline steps conditionally.

```csharp
public interface IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,out TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<System.Func<TParam, System.Threading.CancellationToken, System.Threading.Tasks.Task<TResult>>, TPipelineBuilder>
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam, TResult, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IAsyncPipelineBuilderBranchWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhenConditionPredicate_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicate<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TParam](IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.BranchWhen(System.Func_TParam,System.Threading.Tasks.Task_bool__,System.Action_TPipelineBuilder_)'></a>

## IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.BranchWhen(Func<TParam,Task<bool>>, Action<TPipelineBuilder>) Method

Adds the pipeline branch with own configuration that is executed when the condition is met.  
When the condition is met the branch is executed and the main pipeline is NOT executed.  
When the condition is NOT met the branch is skipped and the main pipeline is executed.

```csharp
TPipelineBuilder BranchWhen(System.Func<TParam,System.Threading.Tasks.Task<bool>> predicate, System.Action<TPipelineBuilder> branchPipelineBuilderConfiguration);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.BranchWhen(System.Func_TParam,System.Threading.Tasks.Task_bool__,System.Action_TPipelineBuilder_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The predicate.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.BranchWhen(System.Func_TParam,System.Threading.Tasks.Task_bool__,System.Action_TPipelineBuilder_).branchPipelineBuilderConfiguration'></a>

`branchPipelineBuilderConfiguration` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TPipelineBuilder](IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The branch pipeline builder configuration.

#### Returns
[TPipelineBuilder](IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.