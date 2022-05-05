#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilders.Shared](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilders.Shared 'Excellence.Pipelines.Core.PipelineBuilders.Shared')

## IPipelineBuilderCreate<TPipelineDelegate,TPipelineBuilder,TPipeline> Interface

The core pipeline builder with the creation functionality.

```csharp
public interface IPipelineBuilderCreate<TPipelineDelegate,out TPipelineBuilder,out TPipeline> :
Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate, TPipelineBuilder, TPipeline>
    where TPipelineDelegate : System.Delegate
    where TPipelineBuilder : Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate<TPipelineDelegate, TPipelineBuilder, TPipeline>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineDelegate'></a>

`TPipelineDelegate`

The pipeline builder delegate type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineBuilder'></a>

`TPipelineBuilder`

The pipeline builder type.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipeline'></a>

`TPipeline`

The pipeline type.

Derived  
&#8627; [IAsyncPipelineBuilderComplete&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IAsyncPipelineBuilderComplete_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Async.IAsyncPipelineBuilderComplete<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IPipelineBuilderComplete&lt;TParam,TResult,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderComplete_TParam,TResult,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Default.IPipelineBuilderComplete<TParam,TResult,TPipelineBuilder,TPipeline>')  
&#8627; [IAsyncPipelineBuilder&lt;TParam,TResult&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')  
&#8627; [IPipelineBuilder&lt;TParam,TResult&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')  
&#8627; [IPipelineBuilderFromDelegate&lt;TPipelineDelegate,TPipelineBuilder,TPipeline&gt;](IPipelineBuilderFromDelegate_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderFromDelegate<TPipelineDelegate,TPipelineBuilder,TPipeline>')

Implements [Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore&lt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineDelegate](IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineDelegate 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate<TPipelineDelegate,TPipelineBuilder,TPipeline>.TPipelineDelegate')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipelineBuilder](IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate<TPipelineDelegate,TPipelineBuilder,TPipeline>.TPipelineBuilder')[,](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')[TPipeline](IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipeline 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate<TPipelineDelegate,TPipelineBuilder,TPipeline>.TPipeline')[&gt;](IPipelineBuilderCore_TPipelineDelegate,TPipelineBuilder,TPipeline_.md 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCore<TPipelineDelegate,TPipelineBuilder,TPipeline>')
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.Copy()'></a>

## IPipelineBuilderCreate<TPipelineDelegate,TPipelineBuilder,TPipeline>.Copy() Method

Copies the pipeline builder.

```csharp
TPipelineBuilder Copy();
```

#### Returns
[TPipelineBuilder](IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate<TPipelineDelegate,TPipelineBuilder,TPipeline>.TPipelineBuilder')  
The new pipeline builder instance that has the same configuration as the current one.

<a name='Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.New()'></a>

## IPipelineBuilderCreate<TPipelineDelegate,TPipelineBuilder,TPipeline>.New() Method

Creates the new pipeline builder instance of the same type without the components added and the target set.

```csharp
TPipelineBuilder New();
```

#### Returns
[TPipelineBuilder](IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.md#Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate_TPipelineDelegate,TPipelineBuilder,TPipeline_.TPipelineBuilder 'Excellence.Pipelines.Core.PipelineBuilders.Shared.IPipelineBuilderCreate<TPipelineDelegate,TPipelineBuilder,TPipeline>.TPipelineBuilder')  
The new pipeline builder instance without the components added and the target set.