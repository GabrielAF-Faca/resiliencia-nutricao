using System.Diagnostics.CodeAnalysis;

namespace Ufn.Resiliencia.Api.Auth.WebApi.Api.Util;

/// <summary>
/// Helper class to run async methods within a sync process.
/// </summary>
[ExcludeFromCodeCoverage]
internal static class AsyncUtil
{
    private static readonly TaskFactory _taskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

    /// <summary>
    /// Executes an async Task method which has a void return value synchronously
    /// USAGE: AsyncUtil.RunSync(() => AsyncMethod());
    /// </summary>
    /// <param name="task">Task method to execute</param>
    public static void RunSync(Func<Task> task)
        => _taskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();

    /// <summary>
    /// Executes an async Task method which has a T return type synchronously
    /// </summary>
    /// <typeparam name="TResult">Return Type</typeparam>
    /// <param name="task">Task method to execute</param>
    /// <returns></returns>
    public static TResult RunSync<TResult>(Func<Task<TResult>> task)
        => _taskFactory
            .StartNew(task)
            .Unwrap()
            .GetAwaiter()
            .GetResult();
}
