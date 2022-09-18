#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineSteps](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineSteps 'Excellence.Pipelines.Core.PipelineSteps')

## IPipelineStep<TParam,TResult> Interface

The pipeline step.

```csharp
public interface IPipelineStep<TParam,TResult>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineSteps.IPipelineStep_TParam,TResult_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.PipelineSteps.IPipelineStep_TParam,TResult_.TResult'></a>

`TResult`

The result type.
### Methods

<a name='Excellence.Pipelines.Core.PipelineSteps.IPipelineStep_TParam,TResult_.Invoke(TParam,System.Func_TParam,TResult_)'></a>

## IPipelineStep<TParam,TResult>.Invoke(TParam, Func<TParam,TResult>) Method

Executes the pipeline step logic.

```csharp
TResult Invoke(TParam param, System.Func<TParam,TResult> next);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineSteps.IPipelineStep_TParam,TResult_.Invoke(TParam,System.Func_TParam,TResult_).param'></a>

`param` [TParam](IPipelineStep_TParam,TResult_.md#Excellence.Pipelines.Core.PipelineSteps.IPipelineStep_TParam,TResult_.TParam 'Excellence.Pipelines.Core.PipelineSteps.IPipelineStep<TParam,TResult>.TParam')

The parameter.

<a name='Excellence.Pipelines.Core.PipelineSteps.IPipelineStep_TParam,TResult_.Invoke(TParam,System.Func_TParam,TResult_).next'></a>

`next` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TParam](IPipelineStep_TParam,TResult_.md#Excellence.Pipelines.Core.PipelineSteps.IPipelineStep_TParam,TResult_.TParam 'Excellence.Pipelines.Core.PipelineSteps.IPipelineStep<TParam,TResult>.TParam')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TResult](IPipelineStep_TParam,TResult_.md#Excellence.Pipelines.Core.PipelineSteps.IPipelineStep_TParam,TResult_.TResult 'Excellence.Pipelines.Core.PipelineSteps.IPipelineStep<TParam,TResult>.TResult')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The pipeline next step delegate.

#### Returns
[TResult](IPipelineStep_TParam,TResult_.md#Excellence.Pipelines.Core.PipelineSteps.IPipelineStep_TParam,TResult_.TResult 'Excellence.Pipelines.Core.PipelineSteps.IPipelineStep<TParam,TResult>.TResult')  
The result.