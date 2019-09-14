using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TemplateBenchmark.Substitutions
{
    internal class RegexSubstitutor
    {
        public SubstitutorType Type => SubstitutorType.Regex;

        Regex regex = new Regex(@"{\w*}", RegexOptions.Compiled);

        public string FindAndSubstitute(Dictionary<string, string> dic, string source)
        {
            return regex.Replace(source, (match) =>
            {
                return dic.TryGetValue(match.Value, out var templateValue) ? templateValue : match.Value;
            });

        }
    }
}
