using System.Text.RegularExpressions;

namespace Inflector
{
    /// <summary>
    /// This class is not meant to be used directly.
    /// </summary>
    public class InflectorRule
    {
        private readonly Regex _regex;
        private readonly string _replacement;

        internal InflectorRule(string pattern, string replacement)
        {
            _regex = new Regex(pattern, RegexOptions.IgnoreCase);
            _replacement = replacement;
        }

        internal string Apply(string word)
        {
            if (!_regex.IsMatch(word))
            {
                return null;
            }

            return _regex.Replace(word, _replacement);
        }
    }
}