#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Shared](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Shared 'Excellence.Pipelines.Core.PipelineBuilders.Shared')

## IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline> Interface

The core pipeline builder with the service provider.

```csharp
public interface IPipelineBuilderServiceProvider<TPipelineDelegate,out TPipelineBuilder,out TPipeline> :
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder, TPipeline>
    where TPipelineDelegate : System.Delegate
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate, TPipelineBuilder, TPipeline>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineDelegate'></a>

`TPipelineDelegate`

The pipeline builder delegate type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipeline'></a>

`TPipeline`

The pipeline type.

Derived  
&#8627; [IAsyncPipelineBuilderBranchWhen&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderBranchWhen_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhen<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderBranchWhenConditionInterface_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterface<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderBranchWhenConditionPredicate_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicate<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderComplete&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderComplete_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderComplete<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderStepInterface&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderStepInterface_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterface<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderStepInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderUseWhen&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderUseWhen_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhen<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderUseWhenConditionInterface_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterface<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderUseWhenConditionPredicate_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicate<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderBranchWhen&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderBranchWhen_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhen<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderBranchWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderBranchWhenConditionInterface_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterface<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderBranchWhenConditionInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderBranchWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderBranchWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderBranchWhenConditionPredicate_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicate<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderBranchWhenConditionPredicateServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderBranchWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderBranchWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderComplete&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderComplete_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderComplete<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderStepInterface&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderStepInterface_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterface<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderStepInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderStepInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderStepInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderStepInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderStepInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderUseWhen&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderUseWhen_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhen<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderUseWhenConditionInterface&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderUseWhenConditionInterface_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterface<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderUseWhenConditionInterfaceServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderUseWhenConditionInterfaceServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionInterfaceServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderUseWhenConditionPredicate&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderUseWhenConditionPredicate_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicate<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateFactoryWithServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderUseWhenConditionPredicateServiceProvider&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderUseWhenConditionPredicateServiceProvider_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderUseWhenConditionPredicateServiceProvider<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')  
&#8627; [IPipelineBuilderFromDelegate&lt;TPipelineDelegate,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderFromDelegate_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderFromDelegate<TPipelineDelegate,TPipelineBuilder,TPipeline>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineDelegate](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>.TPipelineDelegate')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineBuilder](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>.TPipelineBuilder')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipeline](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipeline 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>.TPipeline')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')
### Properties

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.ServiceProvider'></a>

## IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>.ServiceProvider Property

The service provider.

```csharp
System.IServiceProvider? ServiceProvider { get; }
```

#### Property Value
[System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.UseServiceProvider(System.IServiceProvider)'></a>

## IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>.UseServiceProvider(IServiceProvider) Method

Sets the service provider.

```csharp
TPipelineBuilder UseServiceProvider(System.IServiceProvider? serviceProvider);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.UseServiceProvider(System.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')

#### Returns
[TPipelineBuilder](IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderServiceProvider<TPipelineDelegate,TPipelineBuilder,TPipeline>.TPipelineBuilder')  
The current pipeline builder instance.