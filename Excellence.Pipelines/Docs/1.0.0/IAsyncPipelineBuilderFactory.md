#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineBuilderFactories](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineBuilderFactories 'Excellence.Pipelines.Core.PipelineBuilderFactories')

## IAsyncPipelineBuilderFactory Interface

The pipeline builder factory.

```csharp
public interface IAsyncPipelineBuilderFactory
```
### Methods

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider)'></a>

## IAsyncPipelineBuilderFactory.Create<TParam,TResult>(IServiceProvider) Method

Creates the new async pipeline builder instance.

```csharp
Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult> Create<TParam,TResult>(System.IServiceProvider? serviceProvider=null);
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).TResult'></a>

`TResult`

The result type.
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).serviceProvider'></a>

`serviceProvider` [System.IServiceProvider](https://docs.microsoft.com/en-us/dotnet/api/System.IServiceProvider 'System.IServiceProvider')

The service provider.

#### Returns
[Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder&lt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')[TParam](IAsyncPipelineBuilderFactory.md#Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).TParam 'Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.Create<TParam,TResult>(System.IServiceProvider).TParam')[,](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')[TResult](IAsyncPipelineBuilderFactory.md#Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.Create_TParam,TResult_(System.IServiceProvider).TResult 'Excellence.Pipelines.Core.PipelineBuilderFactories.IAsyncPipelineBuilderFactory.Create<TParam,TResult>(System.IServiceProvider).TResult')[&gt;](IAsyncPipelineBuilder_TParam,TResult_.md 'Excellence.Pipelines.Core.PipelineBuilders.IAsyncPipelineBuilder<TParam,TResult>')  
The pipeline builder.