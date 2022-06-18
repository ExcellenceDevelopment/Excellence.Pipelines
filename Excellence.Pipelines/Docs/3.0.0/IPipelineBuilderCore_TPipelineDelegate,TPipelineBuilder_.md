#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Shared](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Shared 'Excellence.Pipelines.Core.PipelineBuilders.Shared')

## IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder> Interface

The core pipeline builder.

```csharp
public interface IPipelineBuilderCore<TPipelineDelegate,out TPipelineBuilder>
    where TPipelineDelegate : System.Delegate
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate'></a>

`TPipelineDelegate`

The pipeline builder delegate type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IAsyncPipelineBuilderBranchWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhenConditionInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionInterfaceFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhenConditionPredicate_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicate<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionPredicateFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderStepInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderStepInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderStepInterfaceFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderStepInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhenConditionInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionInterfaceFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhenConditionPredicate_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicate<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionPredicateFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionInterfaceFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionPredicate_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicate<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionPredicateFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderBranchWhenConditionPredicateServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderStepInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderStepInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderStepInterfaceFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderStepInterfaceFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderStepInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderStepInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhen&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhen_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhen<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionInterface_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterface<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionInterfaceFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionInterfaceFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionPredicate_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicate<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionPredicateFactory&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionPredicateFactory_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateFactory<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IPipelineBuilderUseWhenConditionPredicateServiceProvider&lt;TParam,TResult,TPipelineBuilder&gt;](IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder>')  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')  
&#8627; [IPipelineBuilderCoreUseUtils&lt;TPipelineDelegate,TPipelineBuilder&gt;](IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCoreUseUtils<TPipelineDelegate,TPipelineBuilder>')  
&#8627; [IPipelineBuilderCoreUtils&lt;TPipelineDelegate,TPipelineBuilder&gt;](IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCoreUtils<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.BuildPipeline()'></a>

## IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>.BuildPipeline() Method

Builds the pipeline.

```csharp
TPipelineDelegate BuildPipeline();
```

#### Returns
[TPipelineDelegate](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>.TPipelineDelegate')  
The pipeline.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.Use(System.Func_TPipelineDelegate,TPipelineDelegate_)'></a>

## IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>.Use(Func<TPipelineDelegate,TPipelineDelegate>) Method

Adds the component to the pipeline builder.

```csharp
TPipelineBuilder Use(System.Func<TPipelineDelegate,TPipelineDelegate> component);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.Use(System.Func_TPipelineDelegate,TPipelineDelegate_).component'></a>

`component` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TPipelineDelegate](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>.TPipelineDelegate')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TPipelineDelegate](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>.TPipelineDelegate')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The component.

#### Returns
[TPipelineBuilder](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.UseTarget(TPipelineDelegate)'></a>

## IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>.UseTarget(TPipelineDelegate) Method

Sets the target.

```csharp
TPipelineBuilder UseTarget(TPipelineDelegate target);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.UseTarget(TPipelineDelegate).target'></a>

`target` [TPipelineDelegate](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>.TPipelineDelegate')

The target.

#### Returns
[TPipelineBuilder](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.