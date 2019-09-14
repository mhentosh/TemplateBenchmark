using System.Collections.Generic;
using System.Linq;
using System;
using TemplateBenchmark.Substitutions;
using TemplateBenchmark.Helpers;
using System.Threading.Tasks;
using System.Threading;

namespace TemplateBenchmark
{
    class Solution
    {
        static int BenchmarkIterations = 1000;
        public static void Main(string[] args)
        {
            var ls = new LinearSubstitutor();
            var rs = new RegexSubstitutor();

            Benchmark(PrepareBenchmarkData(10, ls, rs));
            Benchmark(PrepareBenchmarkData(50, ls, rs));
            Benchmark(PrepareBenchmarkData(100, ls, rs));
            Benchmark(PrepareBenchmarkData(200, ls, rs));
            Benchmark(PrepareBenchmarkData(500, ls, rs));
            //Benchmark(PrepareBenchmarkData(1000, ls, rs));
        }

        static IEnumerable<Func<(long, SubstitutorType)>> PrepareBenchmarkData(int sizeMultiplier, LinearSubstitutor ls, RegexSubstitutor rs)
        {
            var template = string.Join(string.Empty, Enumerable.Repeat(Template.Value, sizeMultiplier));
            Func<(long, SubstitutorType)> linearFunc = new Func<(long, SubstitutorType)>(() =>
            {
                var res = ExecutionHelper.GetExecutionTime(() => ls.FindAndSubstitute(Template.TemplateData, template));
                return (res.ticks, ls.Type);
            });
            Func<(long, SubstitutorType)> regexFunc = new Func<(long, SubstitutorType)>(() => {
                var res = ExecutionHelper.GetExecutionTime(() => rs.FindAndSubstitute(Template.TemplateData, template));
                return (res.ticks, rs.Type);
            });

            Console.WriteLine($"Template size: {sizeMultiplier} benchmark");

            return Enumerable.Repeat(regexFunc, BenchmarkIterations).Concat(Enumerable.Repeat(linearFunc, BenchmarkIterations));
        }

        static void Benchmark(IEnumerable<Func<(long ticks, SubstitutorType tp)>> data)
        {
            long linearResult = 0;
            long regexResult = 0;

            Parallel.ForEach(data, (substitutorFunc) =>
            {
                var result = substitutorFunc();
                if (result.tp == SubstitutorType.Linear)
                    Interlocked.Add(ref linearResult, result.ticks);
                else
                    Interlocked.Add(ref regexResult, result.ticks);
            });

            var avgLinear = linearResult / BenchmarkIterations;
            var avgRegex = regexResult / BenchmarkIterations;
            Console.WriteLine($"LinearSubstitute AVG ticks per {BenchmarkIterations} iterations: {avgLinear} ");
            Console.WriteLine($"RegexSubstitute AVG ticks per {BenchmarkIterations} iteration: {avgRegex} ");
            Console.WriteLine($"Linear boost = {(double)avgLinear/avgRegex * 100}%");
            Console.WriteLine();
        }
    }
}
