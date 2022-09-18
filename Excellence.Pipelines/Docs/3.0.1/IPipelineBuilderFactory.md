#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilderFactories](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilderFactories 'Excellence.Pipelines.Core.PipelineBuilderFactories')

## IPipelineBuilderFactory Interface

The pipeline builder factory.

```csharp
public interface IPipelineBuilderFactory
```
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.CreatePipelineBuilder_TParam,TResult_()'></a>

## IPipelineBuilderFactory.CreatePipelineBuilder<TParam,TResult>() Method

Creates the new pipeline builder instance.

```csharp
Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult> CreatePipelineBuilder<TParam,TResult>();
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.CreatePipelineBuilder_TParam,TResult_().TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.CreatePipelineBuilder_TParam,TResult_().TResult'></a>

`TResult`

The result type.

#### Returns
[Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder&lt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')[TParam](IPipelineBuilderFactory.md#Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.CreatePipelineBuilder_TParam,TResult_().TParam 'Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.CreatePipelineBuilder<TParam,TResult>().TParam')[,](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')[TResult](IPipelineBuilderFactory.md#Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.CreatePipelineBuilder_TParam,TResult_().TResult 'Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.CreatePipelineBuilder<TParam,TResult>().TResult')[&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')  
The pipeline builder.