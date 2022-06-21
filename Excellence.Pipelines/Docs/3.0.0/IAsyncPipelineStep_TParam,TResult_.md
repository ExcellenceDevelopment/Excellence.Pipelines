#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineSteps](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineSteps 'Excellence.Pipelines.Core.PipelineSteps')

## IAsyncPipelineStep<TParam,TResult> Interface

The async pipeline step.

```csharp
public interface IAsyncPipelineStep<TParam,TResult>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.TResult'></a>

`TResult`

The result type.
### Methods

<a name='Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.Invoke(TParam,System.Threading.CancellationToken,System.Func_TParam,System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__)'></a>

## IAsyncPipelineStep<TParam,TResult>.Invoke(TParam, CancellationToken, Func<TParam,CancellationToken,Task<TResult>>) Method

Executes the pipeline step logic.

```csharp
System.Threading.Tasks.Task<TResult> Invoke(TParam param, System.Threading.CancellationToken cancellationToken, System.Func<TParam,System.Threading.CancellationToken,System.Threading.Tasks.Task<TResult>> next);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.Invoke(TParam,System.Threading.CancellationToken,System.Func_TParam,System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__).param'></a>

`param` [TParam](IAsyncPipelineStep_TParam,TResult_.md#Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.TParam 'Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep<TParam,TResult>.TParam')

The parameter.

<a name='Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.Invoke(TParam,System.Threading.CancellationToken,System.Func_TParam,System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__).cancellationToken'></a>

`cancellationToken` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

The cancellation token.

<a name='Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.Invoke(TParam,System.Threading.CancellationToken,System.Func_TParam,System.Threading.CancellationToken,System.Threading.Tasks.Task_TResult__).next'></a>

`next` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TParam](IAsyncPipelineStep_TParam,TResult_.md#Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.TParam 'Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep<TParam,TResult>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipelineStep_TParam,TResult_.md#Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.TResult 'Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep<TParam,TResult>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

The pipeline next step delegate.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TResult](IAsyncPipelineStep_TParam,TResult_.md#Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep_TParam,TResult_.TResult 'Excellence.Pipelines.Core.PipelineSteps.IAsyncPipelineStep<TParam,TResult>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The result.