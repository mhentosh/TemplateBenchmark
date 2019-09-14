using System;
using System.Diagnostics;

namespace TemplateBenchmark.Helpers
{
    static class ExecutionHelper
    {
        public static (string result, long ticks) GetExecutionTime(Func<string> action)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = action.Invoke();
            stopwatch.Stop();
            return (result, stopwatch.ElapsedTicks);
        }
    }
}
