namespace Regex.logic
{
    public class regextester
    {        
        public class Solution
        {
            public bool IsMatch(string s, string p)
            {

                if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(p))
                    return true;
                if (s.Length != 0 && p.Length == 0)
                    return false;

                if (p.Length >= 2 && p[1].ToString().Equals("*"))
                {

                    if (s.Length == 0)
                    {
                        if (p.Length == 2)
                            return true;

                        return IsMatch(s, p.Substring(2));
                    }
                    if (s[0] == p[0] || p[0].ToString().Equals("."))
                    {
                        if (!IsMatch(s, p.Substring(2)))
                            return IsMatch(s.Substring(1), p);

                        return true;
                    }
                    if (s[0] != p[0])
                        return IsMatch(s, p.Substring(2));
                }
                if ( !string.IsNullOrEmpty(s) &&(s[0] == p[0] || p[0].ToString().Equals(".")))
                    return IsMatch(s.Substring(1), p.Substring(1));
                return false;
            }
        }
    }

}
