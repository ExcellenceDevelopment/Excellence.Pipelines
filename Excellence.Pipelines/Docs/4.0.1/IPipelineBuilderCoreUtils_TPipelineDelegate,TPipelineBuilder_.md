#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Core](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Core 'Excellence.Pipelines.Core.PipelineBuilders.Core')

## IPipelineBuilderCoreUtils<TPipelineDelegate,TPipelineBuilder> Interface

The core pipeline builder utils.

```csharp
public interface IPipelineBuilderCoreUtils<TPipelineDelegate,out TPipelineBuilder> :
Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder>
    where TPipelineDelegate : System.Delegate
    where TPipelineBuilder : class, Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils<TPipelineDelegate, TPipelineBuilder>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate'></a>

`TPipelineDelegate`

The pipeline builder delegate type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

Derived  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineDelegate](IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils<TPipelineDelegate,TPipelineBuilder>.TPipelineDelegate')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')[TPipelineBuilder](IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils<TPipelineDelegate,TPipelineBuilder>.TPipelineBuilder')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder_.md 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.Copy()'></a>

## IPipelineBuilderCoreUtils<TPipelineDelegate,TPipelineBuilder>.Copy() Method

Copies the pipeline builder.

```csharp
TPipelineBuilder Copy();
```

#### Returns
[TPipelineBuilder](IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.md#Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils_TPipelineDelegate,TPipelineBuilder_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Core.IPipelineBuilderCoreUtils<TPipelineDelegate,TPipelineBuilder>.TPipelineBuilder')  
The new pipeline builder instance that has the same configuration as the current one.