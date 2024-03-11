using System.Text;

namespace Business.Helpers
{
    public static class CNFConcater
    {
        public static string GetConcatedCNF(this List<string> inputs)
        {
            //!p, p, (p or b), (!p or b) -> (!p & (p & ((p or b) & (!p or b))))
            if (inputs == null || inputs.Count == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(inputs[0]);

            for (int i = 1; i < inputs.Count; i++)
            {
                if(i == inputs.Count - 1)
                {
                    sb.Append(" & ");
                }
                else
                {
                    sb.Append(" & (");
                }
                sb.Append(inputs[i]);
            }

            for (int i = 1; i < inputs.Count-1; i++)
            {
                sb.Append(")");
            }

            return $"({sb})";
        }
    }
}
