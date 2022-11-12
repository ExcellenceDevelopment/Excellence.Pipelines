#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilderFactories](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilderFactories 'Excellence.Pipelines.Core.PipelineBuilderFactories')

## IAsyncPipelineBuilderFactory Interface

The pipeline builder factory.

```csharp
public interface IAsyncPipelineBuilderFactory
```
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.CreateAsyncPipelineBuilder_TParam,TResult_()'></a>

## IAsyncPipelineBuilderFactory.CreateAsyncPipelineBuilder<TParam,TResult>() Method

Creates the new async pipeline builder instance.

```csharp
Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult> CreateAsyncPipelineBuilder<TParam,TResult>();
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.CreateAsyncPipelineBuilder_TParam,TResult_().TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.CreateAsyncPipelineBuilder_TParam,TResult_().TResult'></a>

`TResult`

The result type.

#### Returns
[Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder&lt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')[TParam](IAsyncPipelineBuilderFactory.md#Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.CreateAsyncPipelineBuilder_TParam,TResult_().TParam 'Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.CreateAsyncPipelineBuilder<TParam,TResult>().TParam')[,](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')[TResult](IAsyncPipelineBuilderFactory.md#Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.CreateAsyncPipelineBuilder_TParam,TResult_().TResult 'Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.CreateAsyncPipelineBuilder<TParam,TResult>().TResult')[&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')  
The pipeline builder.