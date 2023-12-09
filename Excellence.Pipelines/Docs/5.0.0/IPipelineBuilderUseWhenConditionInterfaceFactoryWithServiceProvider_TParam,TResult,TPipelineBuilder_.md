#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Default](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Default 'Excellence.Pipelines.Core.PipelineBuilders.Default')

## IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder> Interface

The pipeline builder with the possibility to execute the pipeline steps conditionally.

```csharp
public interface IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<System.Func<TParam, TResult>, TPipelineBuilder>
    where TPipelineBuilder : class, Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam, TResult, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.TResult'></a>

`TResult`

The result type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IPipelineBuilderUseWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.TParam 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TResult](IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.TResult 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_System.IServiceProvider,TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_System.IServiceProvider,TPipelineBuilder_)'></a>

## IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>.UseWhen<TPipelineCondition>(Func<IServiceProvider,TPipelineCondition>, Action<TPipelineBuilder>, Func<IServiceProvider,TPipelineBuilder>) Method

Adds the pipeline branch with own configuration that is executed when the condition is met.  
When the condition is met the branch is executed and then the main pipeline is executed.  
When the condition is NOT met the branch is skipped and the main pipeline is executed.

```csharp
TPipelineBuilder UseWhen<TPipelineCondition>(System.Func<System.IServiceProvider,TPipelineCondition> pipelineConditionFactory, System.Action<TPipelineBuilder> branchPipelineBuilderConfiguration, System.Func<System.IServiceProvider,TPipelineBuilder> branchPipelineBuilderFactory)
    where TPipelineCondition : class, Excellence.Pipelines.Core.PipelineConditions.IPipelineCondition<TParam>;
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_System.IServiceProvider,TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_System.IServiceProvider,TPipelineBuilder_).TPipelineCondition'></a>

`TPipelineCondition`
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_System.IServiceProvider,TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_System.IServiceProvider,TPipelineBuilder_).pipelineConditionFactory'></a>

`pipelineConditionFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TPipelineCondition](IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_System.IServiceProvider,TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_System.IServiceProvider,TPipelineBuilder_).TPipelineCondition 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>.UseWhen<TPipelineCondition>(System.Func<System.IServiceProvider,TPipelineCondition>, System.Action<TPipelineBuilder>, System.Func<System.IServiceProvider,TPipelineBuilder>).TPipelineCondition')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The pipeline builder condition factory.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_System.IServiceProvider,TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_System.IServiceProvider,TPipelineBuilder_).branchPipelineBuilderConfiguration'></a>

`branchPipelineBuilderConfiguration` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[TPipelineBuilder](IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The branch pipeline builder configuration.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.UseWhen_TPipelineCondition_(System.Func_System.IServiceProvider,TPipelineCondition_,System.Action_TPipelineBuilder_,System.Func_System.IServiceProvider,TPipelineBuilder_).branchPipelineBuilderFactory'></a>

`branchPipelineBuilderFactory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TPipelineBuilder](IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The pipeline builder factory.

#### Returns
[TPipelineBuilder](IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.