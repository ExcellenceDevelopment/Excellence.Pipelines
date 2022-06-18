#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Default](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Default 'Excellence.Pipelines.Core.PipelineBuilders.Default')

## IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder> Interface

The pipeline builder with the possibility to execute the pipeline steps conditionally.

```csharp
public interface IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<System.Func<TParam, TResult>, TPipelineBuilder>
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam, TResult, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IPipelineBuilderBranchWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TResult](IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.BranchWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_)'></a>

## IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.BranchWhen<TPipelineCondition>(Func<TPipelineCondition>, Action<TPipelineBuilder>, Func<TPipelineBuilder>) Method

Adds the pipeline branch with own configuration that is executed when the condition is met.  
When the condition is met the branch is executed and the main pipeline is NOT executed.  
When the condition is NOT met the branch is skipped and the main pipeline is executed.

```csharp
TPipelineBuilder BranchWhen<TPipelineCondition>(System.Func<TPipelineCondition> pipelineConditionFactory, System.Action<TPipelineBuilder> branchPipelineBuilderConfiguration, System.Func<TPipelineBuilder> branchPipelineBuilderFactory)
    where TPipelineCondition : Excellence.Pipelines.Core.PipelineConditions.IPipelineCondition<TParam>;
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.BranchWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).TPipelineCondition'></a>

`TPipelineCondition`
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.BranchWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).pipelineConditionFactory'></a>

`pipelineConditionFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TPipelineCondition](IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.BranchWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).TPipelineCondition 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.BranchWhen<TPipelineCondition>(System.Func<TPipelineCondition>, System.Action<TPipelineBuilder>, System.Func<TPipelineBuilder>).TPipelineCondition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The pipeline builder condition factory.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.BranchWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).branchPipelineBuilderConfiguration'></a>

`branchPipelineBuilderConfiguration` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TPipelineBuilder](IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The branch pipeline builder configuration.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.BranchWhen_TPipelineCondition_(System.Func_TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_TPipelineBuilder_).branchPipelineBuilderFactory'></a>

`branchPipelineBuilderFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')[TPipelineBuilder](IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-1 'System.Func`1')

The pipeline builder factory.

#### Returns
[TPipelineBuilder](IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.