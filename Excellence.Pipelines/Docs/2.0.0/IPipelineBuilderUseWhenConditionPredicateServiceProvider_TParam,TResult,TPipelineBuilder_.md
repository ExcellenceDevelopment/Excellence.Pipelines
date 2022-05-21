#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Default](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Default 'Excellence.Pipelines.Core.PipelineBuilders.Default')

## IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder> Interface

The pipeline builder with the possibility to execute the pipeline steps conditionally.

```csharp
public interface IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,out TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<System.Func<TParam, TResult>, TPipelineBuilder>
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam, TResult, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IPipelineBuilderComplete&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderComplete_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderComplete<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionPredicate_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicate<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TResult](IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.UseWhen(System.Func_TParam,bool_,System.Action_TPipelineBuilder_)'></a>

## IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.UseWhen(Func<TParam,bool>, Action<TPipelineBuilder>) Method

Adds the pipeline branch with own configuration that is executed when the condition is met.  
When the condition is met the branch is executed and then the main pipeline is executed.  
When the condition is NOT met the branch is skipped and the main pipeline is executed.

```csharp
TPipelineBuilder UseWhen(System.Func<TParam,bool> predicate, System.Action<TPipelineBuilder> branchPipelineBuilderConfiguration);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.UseWhen(System.Func_TParam,bool_,System.Action_TPipelineBuilder_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The predicate.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.UseWhen(System.Func_TParam,bool_,System.Action_TPipelineBuilder_).branchPipelineBuilderConfiguration'></a>

`branchPipelineBuilderConfiguration` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TPipelineBuilder](IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The branch pipeline builder configuration.

#### Returns
[TPipelineBuilder](IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.