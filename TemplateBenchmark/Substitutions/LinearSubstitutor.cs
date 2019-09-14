using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TemplateBenchmark.Substitutions
{
    internal class LinearSubstitutor
    {
        const char OPEN_BRACE = '{';
        const char CLOSE_BRACE = '}';

        public SubstitutorType Type => SubstitutorType.Linear;

        public string FindAndSubstitute(Dictionary<string, string> dic, string source)
        {
            var sb = new StringBuilder();

            var tmp = new StringBuilder();
            using (var ms = new MemoryStream(Encoding.ASCII.GetBytes(source)))
            {
                while (ms.Position < ms.Length)
                {
                    var ch = (char)ms.ReadByte();
                    if (ch == OPEN_BRACE || (tmp.Length > 0 && ch != CLOSE_BRACE))
                    {
                        tmp.Append(ch);
                        continue;
                    }
                    else if (ch == CLOSE_BRACE && tmp.Length > 0)
                    {
                        tmp.Append(ch);
                        var templateField = tmp.ToString();
                        if (dic.TryGetValue(templateField, out var templateValue))
                        {
                            sb.Append(templateValue);
                        }
                        else
                        {
                            sb.Append(templateField);
                        }
                        tmp.Clear();
                        continue;
                    }

                    sb.Append(ch);

                }

                //Covers edge case when open brace exist but no close
                if (tmp.Length > 0)
                    sb.Append(tmp.ToString());
            }
            return sb.ToString();
        }
    }
}
