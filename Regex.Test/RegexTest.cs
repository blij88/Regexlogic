using Xunit;
using static Regex.logic.regextester;

namespace Regex.Test
{
    public class RegexTest
    {  


        [Theory]
        [InlineData("aa", "a", false)]
        [InlineData("aa", "a*", true)]
        [InlineData("ac", ".*", true)]
        [InlineData("aab", "c*a*b", true)]
        [InlineData("mississippi", "mis*is*p*.",false)]
        [InlineData("aaa", "a*a",true)]
        [InlineData("ab", ".*c",false)]
        [InlineData("bbbba", ".*a*a",true)]
        [InlineData("a", ".*..a",false)]
        public void IsMatchShouldReturnTrueOnValidString(string a, string b, bool solution)
        {
            var result = new Solution().IsMatch(a, b);
            Assert.Equal(solution, result);
        }
    }
}
