#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.Pipelines](Excellence.Pipelines.md#Excellence.Pipelines.Core.Pipelines 'Excellence.Pipelines.Core.Pipelines')

## IAsyncPipeline<TParam,TResult> Interface

The async pipeline.

```csharp
public interface IAsyncPipeline<in TParam,TResult>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.Pipelines.IAsyncPipeline_TParam,TResult_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.Pipelines.IAsyncPipeline_TParam,TResult_.TResult'></a>

`TResult`

The result type.
### Methods

<a name='Excellence.Pipelines.Core.Pipelines.IAsyncPipeline_TParam,TResult_.InvokeAsync(TParam,System.Threading.CancellationToken)'></a>

## IAsyncPipeline<TParam,TResult>.InvokeAsync(TParam, CancellationToken) Method

Invokes the pipeline.

```csharp
System.Threading.Tasks.Task<TResult> InvokeAsync(TParam param, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='Excellence.Pipelines.Core.Pipelines.IAsyncPipeline_TParam,TResult_.InvokeAsync(TParam,System.Threading.CancellationToken).param'></a>

`param` [TParam](IAsyncPipeline_TParam,TResult_.md#Excellence.Pipelines.Core.Pipelines.IAsyncPipeline_TParam,TResult_.TParam 'Excellence.Pipelines.Core.Pipelines.IAsyncPipeline<TParam,TResult>.TParam')

The parameter.

<a name='Excellence.Pipelines.Core.Pipelines.IAsyncPipeline_TParam,TResult_.InvokeAsync(TParam,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipeline_TParam,TResult_.md#Excellence.Pipelines.Core.Pipelines.IAsyncPipeline_TParam,TResult_.TResult 'Excellence.Pipelines.Core.Pipelines.IAsyncPipeline<TParam,TResult>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The async pipeline result.