#### [Excellence.Pipelines.Core](Excellence.Pipelines.md 'Excellence.Pipelines')
### [Excellence.Pipelines.Core.PipelineConditions](Excellence.Pipelines.md#Excellence.Pipelines.Core.PipelineConditions 'Excellence.Pipelines.Core.PipelineConditions')

## IPipelineCondition<TParam> Interface

The pipeline builder condition.

```csharp
public interface IPipelineCondition<in TParam>
```
#### Type parameters

<a name='Excellence.Pipelines.Core.PipelineConditions.IPipelineCondition_TParam_.TParam'></a>

`TParam`

The parameter type.
### Methods

<a name='Excellence.Pipelines.Core.PipelineConditions.IPipelineCondition_TParam_.Invoke(TParam)'></a>

## IPipelineCondition<TParam>.Invoke(TParam) Method

Checks if the parameter meets the condition.

```csharp
bool Invoke(TParam param);
```
#### Parameters

<a name='Excellence.Pipelines.Core.PipelineConditions.IPipelineCondition_TParam_.Invoke(TParam).param'></a>

`param` [TParam](IPipelineCondition_TParam_.md#Excellence.Pipelines.Core.PipelineConditions.IPipelineCondition_TParam_.TParam 'Excellence.Pipelines.Core.PipelineConditions.IPipelineCondition<TParam>.TParam')

The parameter.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when the parameter meets the condition or [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when it doesn't.