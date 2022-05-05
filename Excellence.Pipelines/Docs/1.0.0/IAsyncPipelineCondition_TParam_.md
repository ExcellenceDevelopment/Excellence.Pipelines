#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineConditions](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineConditions 'Excellence.Pipelines.Core.PipelineConditions')

## IAsyncPipelineCondition<TParam> Interface

The pipeline builder condition.

```csharp
public interface IAsyncPipelineCondition<in TParam>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineConditions.IAsyncPipelineCondition_TParam_.TParam'></a>

`TParam`

The parameter type.
### Methods

<a name='Excellence.Pipelines.Core.PipelineConditions.IAsyncPipelineCondition_TParam_.InvokeAsync(TParam)'></a>

## IAsyncPipelineCondition<TParam>.InvokeAsync(TParam) Method

Checks if the parameter meets the condition.

```csharp
System.Threading.Tasks.Task<bool> InvokeAsync(TParam param);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineConditions.IAsyncPipelineCondition_TParam_.InvokeAsync(TParam).param'></a>

`param` [TParam](IAsyncPipelineCondition_TParam_.md#Excellence.Pipelines.Core.PipelineConditions.IAsyncPipelineCondition_TParam_.TParam 'Excellence.Pipelines.Core.PipelineConditions.IAsyncPipelineCondition<TParam>.TParam')

The parameter.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when the parameter meets the condition or [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when it doesn't.