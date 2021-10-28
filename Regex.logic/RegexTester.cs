namespace Regex.logic
{
    public class regextester
    {
        public class Solution
        {
            public bool IsMatch(string s, string p)
            {
                if (s.Length == 0 && p.Length == 0)
                    return true;
                if ((s.Length != 0 && p.Length == 0))
                    return false;

                if (p.StartsWith("."))
                {
                    if (p.StartsWith(".*"))
                    {
                        if (s.Length == 0)
                        {
                            if (p.Length == 2)
                                return true;

                            return IsMatch(s, p.Substring(2));
                        }
                        if (!IsMatch(s, p.Substring(2)))
                            return IsMatch(s.Substring(1), p);
                        return true;

                    }
                    else
                    {
                        if (s.Length == 0)
                            return false;
                        return IsMatch(s.Substring(1), p.Substring(1));
                    }
                }

                if (p.Length >= 2 && p[1].ToString().Equals("*"))
                {
                    if (s.Length == 0)
                    {
                        if (p.Length == 2)
                            return true;

                        return IsMatch(s, p.Substring(2));
                    }
                    if (s[0] == p[0])
                    {
                        if (!IsMatch(s, p.Substring(2)))
                            return IsMatch(s.Substring(1), p);

                        return true;
                    }
                    if (s[0] != p[0])
                        return IsMatch(s, p.Substring(2));

                }

                if (s.Length > 0 && s[0] == p[0])
                    return IsMatch(s.Substring(1), p.Substring(1));

                return false;

            }
        }
    }
}
