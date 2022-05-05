#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilderFactories](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilderFactories 'Excellence.Pipelines.Core.PipelineBuilderFactories')

## IPipelineBuilderFactory Interface

The pipeline builder factory.

```csharp
public interface IPipelineBuilderFactory
```
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider)'></a>

## IPipelineBuilderFactory.Create<TParam,TResult>(IServiceProvider) Method

Creates the new pipeline builder instance.

```csharp
Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult> Create<TParam,TResult>(System.IServiceProvider? serviceProvider=null);
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).TResult'></a>

`TResult`

The result type.
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')

The service provider.

#### Returns
[Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder&lt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')[TParam](IPipelineBuilderFactory.md#Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).TParam 'Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.Create<TParam,TResult>(System.IServiceProvider).TParam')[,](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')[TResult](IPipelineBuilderFactory.md#Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).TResult 'Excellence.Pipelines.Core.PipelineBuilderFactories.IPipelineBuilderFactory.Create<TParam,TResult>(System.IServiceProvider).TResult')[&gt;](IPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IPipelineBuilder<TParam,TResult>')  
The pipeline builder.