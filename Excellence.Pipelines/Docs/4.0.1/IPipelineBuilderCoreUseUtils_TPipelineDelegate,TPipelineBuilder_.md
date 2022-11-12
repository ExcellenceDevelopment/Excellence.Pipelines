#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Core](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Core 'Excellence.Pipelines.Core.PipelineBuilders.Core')

## IPipelineBuilderCoreUseUtils<TPipelineDelegate,TPipelineBuilder> Interface

The core pipeline builder Use utils.

```csharp
public interface IPipelineBuilderCoreUseUtils<TPipelineDelegate,out TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>
    where TPipelineDelegate : System.Delegate
    where TPipelineBuilder : class, Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils<TPipelineDelegate, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate'></a>

`TPipelineDelegate`

The pipeline builder delegate type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineDelegate](IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils<TPipelineDelegate,TPipelineBuilder>.TPipelineDelegate')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils<TPipelineDelegate,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.Use(System.Collections.Generic.IEnumerable_System.Func_TPipelineDelegate,TPipelineDelegate__)'></a>

## IPipelineBuilderCoreUseUtils<TPipelineDelegate,TPipelineBuilder>.Use(IEnumerable<Func<TPipelineDelegate,TPipelineDelegate>>) Method

Adds the components to the pipeline builder.

```csharp
TPipelineBuilder Use(System.Collections.Generic.IEnumerable<System.Func<TPipelineDelegate,TPipelineDelegate>> components);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.Use(System.Collections.Generic.IEnumerable_System.Func_TPipelineDelegate,TPipelineDelegate__).components'></a>

`components` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TPipelineDelegate](IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils<TPipelineDelegate,TPipelineBuilder>.TPipelineDelegate')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TPipelineDelegate](IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils<TPipelineDelegate,TPipelineBuilder>.TPipelineDelegate')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The components.

#### Returns
[TPipelineBuilder](IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUseUtils<TPipelineDelegate,TPipelineBuilder>.TPipelineBuilder')  
The current pipeline builder instance.