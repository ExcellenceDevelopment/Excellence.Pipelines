﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Excellence.Pipelines.Tests.PipelineBuilders.Shared
{
    public abstract class PipelineBuilderTestsBase
    {
        protected int Arg => 37;

        protected static Func<int, CancellationToken, Task<int>> TargetMainResult =>
            (param, _) => Task.FromResult(param);

        protected static Task<int> TargetMain(int param, CancellationToken cancellationToken) =>
            TargetMainResult.Invoke(param, cancellationToken);
    }
}
