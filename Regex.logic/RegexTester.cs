namespace Regex.logic
{
    public class regextester
    {
        public class Solution
        {
            public bool IsMatch(string s, string p)
            {

                if (string.IsNullOrEmpty(p))
                    return string.IsNullOrEmpty(s);

                if (p.Length >= 2 && p[1].ToString().Equals("*"))
                {

                    if (s.StartsWith(p[0]) || (s.Length > 0 && p[0].ToString().Equals(".")))
                    {
                        if (!IsMatch(s, p.Substring(2)))
                            return IsMatch(s.Substring(1), p);
                        
                        return true;
                    }
                    if (!s.StartsWith(p[0]))
                        return IsMatch(s, p.Substring(2));
                }
                if (s.StartsWith(p[0]) || (s.Length > 0 && p[0].ToString().Equals(".")))
                    return IsMatch(s.Substring(1), p.Substring(1));
                return false;
            }
        }
    }

}
