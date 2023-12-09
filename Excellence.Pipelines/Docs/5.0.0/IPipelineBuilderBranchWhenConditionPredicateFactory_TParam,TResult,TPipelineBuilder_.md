#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Default](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Default 'Excellence.Pipelines.Core.PipelineBuilders.Default')

## IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder> Interface

The pipeline builder with the possibility to execute the pipeline steps conditionally.

```csharp
public interface IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<System.Func<TParam, TResult>, TPipelineBuilder>
    where TPipelineBuilder : class, Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory<TParam, TResult, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IPipelineBuilderBranchWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionPredicate_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicate<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TResult](IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.BranchWhen(System.Func_TParam,bool_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_)'></a>

## IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>.BranchWhen(Func<TParam,bool>, Action<TPipelineBuilder>, Func<TPipelineBuilder>) Method

Adds the pipeline branch with own configuration that is executed when the condition is met.  
When the condition is met the branch is executed and the main pipeline is NOT executed.  
When the condition is NOT met the branch is skipped and the main pipeline is executed.

```csharp
TPipelineBuilder BranchWhen(System.Func<TParam,bool> predicate, System.Action<TPipelineBuilder> branchPipelineBuilderConfiguration, System.Func<TPipelineBuilder> branchPipelineBuilderFactory);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.BranchWhen(System.Func_TParam,bool_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The predicate.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.BranchWhen(System.Func_TParam,bool_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).branchPipelineBuilderConfiguration'></a>

`branchPipelineBuilderConfiguration` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TPipelineBuilder](IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The branch pipeline builder configuration.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.BranchWhen(System.Func_TParam,bool_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).branchPipelineBuilderFactory'></a>

`branchPipelineBuilderFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TPipelineBuilder](IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The pipeline builder factory.

#### Returns
[TPipelineBuilder](IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.