<!-- omit in toc -->
# Pipelines

<!-- omit in toc -->
## Table of contents

- [Overview](#overview)
- [Create pipeline builders](#create-pipeline-builders)
  - [Constructor](#constructor)
  - [Factory](#factory)
  - [`Copy`](#copy)
- [Add components](#add-components)
  - [`Use` delegate](#use-delegate)
  - [`Use` interface](#use-interface)
- [Add components and execute conditionally](#add-components-and-execute-conditionally)
  - [`UseWhen`](#usewhen)
  - [`BranchWhen`](#branchwhen)
- [Set the pipeline target](#set-the-pipeline-target)
  - [`UseTarget`](#usetarget)
- [Build the pipeline](#build-the-pipeline)
  - [`BuildPipeline`](#buildpipeline)

<br/>

## Overview

Pipelines are created using pipeline builders.

`IPipelineBuilder<TParam, TResult>` is used to create pipelines that accept an argument (`TParam`) and return a result (`TResult`).

`IAsyncPipelineBuilder<TParam, TResult>` is used to create pipelines that accept arguments (`TParam`, `CancellationToken`) and return a result (`Task<TResult>`).

All examples below use `IAsyncPipelineBuilder<TParam, TResult>`.

<br />

## Create pipeline builders

### Constructor

A pipeline builder can be created using the public constructor.

**Example**:

```csharp
var pipelineBuilder = new AsyncPipelineBuilder<int, int>(serviceProvider);
```

<br/>

### Factory

A new pipeline builder can be created using the factory.

It is possible to pass the `IServiceProvider` instance as an argument.

**Example**:

```csharp
var factory = new AsyncPipelineBuilderFactory(serviceProvider);

var pipelineBuilder = factory.CreateAsyncPipelineBuilder<int, int>();
```

<br/>

### `Copy`

`Copy` creates a new pipeline builder from the existing one (source) and returns it.

The configuration (components, target) is copied to a new instance.

A new pipeline builder uses the same `IServiceProvider` instance as the source one.

**Example:**

```csharp
public class TargetService
{
    public Task<int> Compute(int param, CancellationToken cancellationToken) => Task.FromResult(param + 1);
}

/* ... */

var service = new TargetService();

// components and target are copied from the source pipeline builder
var pipelineBuilderCopy = pipelineBuilder.Copy();

var pipelineCopy = pipelineBuilderCopy.BuildPipeline();
 ```

<br/>

## Add components

A component is a delegate that accepts one parameter (the next step of the pipeline) and returns a delegate containing the current step logic.

Every pipeline executes steps in the order these steps have been added.

<br/>

### `Use` delegate

`Use` adds the component created from the delegate.

**Example**:

```csharp
pipelineBuilder.Use
(
    next => (param, cancellationToken) =>
    {
        var modifiedParam = param + 5;

        return next.Invoke(modifiedParam, cancellationToken);
    }
);
```

<br/>

### `Use` interface

A component can be added using the interface implementation.

**Example**:

```csharp
public class PipelineStep : IAsyncPipelineStep<int, int>
{
    public async Task<int> Invoke(int param, CancellationToken cancellationToken, Func<int, CancellationToken, Task<int>> next)
    {
        var nextResult = await next.Invoke(param, cancellationToken);

        var result = nextResult * 2;

        return result;
    }
}

/* ... */

// pipeline step is provided by the factory
pipelineBuilder.Use(() => new PipelineStep());

// pipeline step is provided by the factory accepting service provider
pipelineBuilder.Use((sp) => sp.GetRequiredService<PipelineStep>());

// pipeline step is provided by the service provider
pipelineBuilder.Use<PipelineStep>();
```

<br/>

## Add components and execute conditionally

It is possible to add components that are executed only when some condition is met.

<br/>

### `UseWhen`

`UseWhen` adds the pipeline branch with its configuration that is executed when the condition is met.

When the condition is met the branch is executed and then the main pipeline is executed.

When the condition is NOT met the branch is skipped and the main pipeline is executed.

The pipeline branch is configured using the new pipeline builder instance and configuration delegate.

**Example (condition delegate - predicate)**:

```csharp
// branch pipeline builder is provided by the factory
pipelineBuilder.UseWhen
(
    (param) => Task.FromResult(param == -1),
    builder => builder.Use(() => new PipelineStep()),
    () => new AsyncPipelineBuilder<int, int>(serviceProvider)
);

// branch pipeline builder is provided by the factory accepting service provider
pipelineBuilder.UseWhen
(
    (param) => Task.FromResult(param == -1),
    builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
    (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<int, int>>()
);

// branch pipeline builder is provided by the service provider
pipelineBuilder.UseWhen
(
    (param) => Task.FromResult(param == -1),
    builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>())
);
```

<br/>

**Example (interface implementation)**:

```csharp
public class PipelineConditionTrue : IAsyncPipelineCondition<int>
{
    public Task<bool> Invoke(int param) => Task.FromResult(true);
}

/* ... */

// condition and branch pipeline builder are provided by the factory
pipelineBuilder.UseWhen
(
    () => new PipelineConditionTrue(),
    builder => builder.Use(() => new PipelineStep()),
    () => new AsyncPipelineBuilder<int, int>(serviceProvider)
);

// condition and branch pipeline builder are provided by the factory accepting service provider
pipelineBuilder.UseWhen
(
    (sp) => sp.GetRequiredService<PipelineConditionTrue>(),
    builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()),
    (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<int, int>>()
);

// condition and branch pipeline builder are provided by the service provider
pipelineBuilder.UseWhen<PipelineConditionTrue>(builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()));
```

<br/>

### `BranchWhen`

`BranchWhen` adds the pipeline branch with its configuration that is executed when the condition is met.

When the condition is met the branch is executed and the main pipeline is NOT executed.

When the condition is NOT met the branch is skipped and the main pipeline is executed.

The target should be set for the pipeline branch.

The pipeline branch is configured using the new pipeline builder instance and configuration delegate.

**Example (condition delegate - predicate)**:

```csharp
// branch pipeline builder is provided by the factory
pipelineBuilder.BranchWhen
(
    (param) => Task.FromResult(param == -1),
    builder => builder.Use(() => new PipelineStep()).UseTarget((param, cancellationToken) => Task.FromResult(param - 2)),
    () => new AsyncPipelineBuilder<int, int>(serviceProvider)
);

// branch pipeline builder is provided by the factory accepting service provider
pipelineBuilder.BranchWhen
(
    (param) => Task.FromResult(param == -1),
    builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param, cancellationToken) => Task.FromResult(param - 2)),
    (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<int, int>>()
);

// branch pipeline builder is provided by the service provider
pipelineBuilder.BranchWhen
(
    (param) => Task.FromResult(param == -1),
    builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param, cancellationToken) => Task.FromResult(param - 2))
);
```

<br/>

**Example (interface implementation)**:

```csharp
public class PipelineConditionTrue : IAsyncPipelineCondition<int>
{
    public Task<bool> Invoke(int param) => Task.FromResult(true);
}

/* ... */

// condition and branch pipeline builder are provided by the factory
pipelineBuilder.BranchWhen
(
    () => new PipelineConditionTrue(),
    builder => builder.Use(() => new PipelineStep()).UseTarget((param, cancellationToken) => Task.FromResult(param - 2)),
    () => new AsyncPipelineBuilder<int, int>(serviceProvider)
);

// condition and branch pipeline builder are provided by the factory accepting service provider
pipelineBuilder.BranchWhen
(
    (sp) => sp.GetRequiredService<PipelineConditionTrue>(),
    builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param, cancellationToken) => Task.FromResult(param - 2)),
    (sp) => sp.GetRequiredService<IAsyncPipelineBuilder<int, int>>()
);

// condition and branch pipeline builder are provided by the service provider
pipelineBuilder.BranchWhen<PipelineConditionTrue>(builder => builder.Use((sp) => sp.GetRequiredService<PipelineStep>()).UseTarget((param, cancellationToken) => Task.FromResult(param - 2)));
```

## Set the pipeline target

The target is the last step executed by the pipeline.

The target should be set for every pipeline or an exception will be thrown during the building of the pipeline.

<br/>

### `UseTarget`

`UseTarget` is used to set the target of the pipeline.

`UseTarget` can be called multiple times and the next call will rewrite the target that has been set before.

**Example**:

```csharp
public class TargetService
{
    public Task<int> Compute(int param, CancellationToken cancellationToken) => Task.FromResult(param + 1);
}

/* ... */

var service = new TargetService();
pipelineBuilder.UseTarget(service.Compute);
```

<br/>

## Build the pipeline

A pipeline is created (built) using a pipeline builder.

<br/>

### `BuildPipeline`

`BuildPipeline` builds the pipeline.

**Example**:

```csharp
var pipeline = pipelineBuilder.BuildPipeline();

// execute the pipeline
var pipelineResult = await pipeline.Invoke(2, CancellationToken.None);
```

<br/>