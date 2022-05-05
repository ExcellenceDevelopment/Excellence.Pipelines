#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.Pipelines](Excellence.Pipelines.md#Excellence.Pipelines.Core.Pipelines 'Excellence.Pipelines.Core.Pipelines')

## IPipeline<TParam,TResult> Interface

The pipeline.

```csharp
public interface IPipeline<in TParam,out TResult>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.Pipelines.IPipeline_TParam,TResult_.TParam'></a>

`TParam`

The parameter type.

<a name='Excellence.Pipelines.Core.Pipelines.IPipeline_TParam,TResult_.TResult'></a>

`TResult`

The result type.
### Methods

<a name='Excellence.Pipelines.Core.Pipelines.IPipeline_TParam,TResult_.Invoke(TParam)'></a>

## IPipeline<TParam,TResult>.Invoke(TParam) Method

Invokes the pipeline.

```csharp
TResult Invoke(TParam param);
```
#### Parameters

<a name='Excellence.Pipelines.Core.Pipelines.IPipeline_TParam,TResult_.Invoke(TParam).param'></a>

`param` [TParam](IPipeline_TParam,TResult_.md#Excellence.Pipelines.Core.Pipelines.IPipeline_TParam,TResult_.TParam 'Excellence.Pipelines.Core.Pipelines.IPipeline<TParam,TResult>.TParam')

The parameter.

#### Returns
[TResult](IPipeline_TParam,TResult_.md#Excellence.Pipelines.Core.Pipelines.IPipeline_TParam,TResult_.TResult 'Excellence.Pipelines.Core.Pipelines.IPipeline<TParam,TResult>.TResult')  
The pipeline result.