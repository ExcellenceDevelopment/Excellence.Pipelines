#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Async](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Async 'Excellence.Pipelines.Core.PipelineBuilders.Async')

## IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline> Interface

The pipeline builder with the possibility to execute the pipeline steps conditionally.

```csharp
public interface IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,out TPipelineBuilder,out TPipeline> :
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<System.Func<TParam, System.Threading.CancellationToken, System.Threading.Tasks.Task<TResult>>, TPipelineBuilder, TPipeline>,
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<System.Func<TParam, System.Threading.CancellationToken, System.Threading.Tasks.Task<TResult>>, TPipelineBuilder, TPipeline>
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam, TResult, TPipelineBuilder, TPipeline>
    where TPipeline : Excellence.Pipelines.Core.Pipelines.IAsyncPipeline<TParam, TResult>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipeline'></a>

`TPipeline`

The pipeline type.

Derived  
&#8627; [IAsyncPipelineBuilderComplete&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderComplete_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderComplete<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderUseWhen&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderUseWhen_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhen<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderUseWhenConditionPredicate_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicate<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider&lt;](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TParam](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[,](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineBuilder](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')[,](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipeline](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipeline 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipeline')[&gt;](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>'), [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TParam](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineBuilder](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipeline](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipeline 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipeline')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.UseWhen(System.Func_TParam,System.Threading.Tasks.Task_bool__,System.Action_TPipelineBuilder_)'></a>

## IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.UseWhen(Func<TParam,Task<bool>>, Action<TPipelineBuilder>) Method

Adds the pipeline branch with own configuration that is executed when the condition is met.  
When the condition is met the branch is executed and then the main pipeline is executed.  
When the condition is NOT met the branch is skipped and the main pipeline is executed.  
Requires the service provider to be set.

```csharp
TPipelineBuilder UseWhen(System.Func<TParam,System.Threading.Tasks.Task<bool>> predicate, System.Action<TPipelineBuilder> branchPipelineBuilderConfiguration);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.UseWhen(System.Func_TParam,System.Threading.Tasks.Task_bool__,System.Action_TPipelineBuilder_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The predicate.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.UseWhen(System.Func_TParam,System.Threading.Tasks.Task_bool__,System.Action_TPipelineBuilder_).branchPipelineBuilderConfiguration'></a>

`branchPipelineBuilderConfiguration` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TPipelineBuilder](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The branch pipeline builder configuration.

#### Returns
[TPipelineBuilder](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>.TPipelineBuilder')  
The current pipeline builder instance.