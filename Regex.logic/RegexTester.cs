namespace Regex.logic
{
    public class regextester
    {
        public class SolutionRecursive
        {
            public bool IsMatch(string s, string p)
            {

                if (string.IsNullOrEmpty(p))
                    return string.IsNullOrEmpty(s);
                var firstMatch = !string.IsNullOrEmpty(s) && (s.StartsWith(p[0]) || p.StartsWith("."));
                if (p.Length >= 2 && p[1].ToString().Equals("*"))
                {
                    return IsMatch(s, p.Substring(2)) || (firstMatch && IsMatch(s.Substring(1), p));
                }
                return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
            }
        }

        public class SolutionDynamic
        {
            public bool IsMatch(string s, string p)
            {

                var gridCheck = new bool[s.Length + 1, p.Length + 1];
                gridCheck[0, 0] = true;
                for (int j = 1; j < p.Length; j += 2)
                {
                    gridCheck[0, j + 1] = p[j].ToString().Equals("*") && gridCheck[0, j - 1];

                }
                for (int i = 1; i < s.Length + 1; i++)
                {
                    for (int j = 1; j < p.Length + 1; j++)
                    {
                        if (p[j - 1].ToString().Equals("*"))
                        {
                            gridCheck[i, j] = gridCheck[i, j - 2] || gridCheck[i - 1, j] && (s[i - 1] == p[j - 2] || p[j - 2].ToString().Equals("."));
                        }
                        if (s[i - 1] == p[j - 1] || p[j - 1].ToString().Equals("."))
                            gridCheck[i, j] = gridCheck[i - 1, j - 1];
                    }
                }
                return gridCheck[s.Length, p.Length];

            }
        }
    }

}
