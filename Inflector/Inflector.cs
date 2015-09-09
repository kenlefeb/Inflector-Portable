using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Inflector.Rules;
using JetBrains.Annotations;

namespace Inflector
{
    public class Inflector
    {
        private static readonly Dictionary<string, InflectorRuleSet> _localizedRules;
        private readonly CultureInfo _currentCulture;

        #region Default Rules

        //TODO: this will be replaced with a DI engine 
        static Inflector()
        {
            _localizedRules = new Dictionary<string, InflectorRuleSet>
                             {
                                 {"en", new EnglishCultureRules().RuleSet}
                             };
        }

        #endregion

        public Inflector(CultureInfo culture)
        {
            _currentCulture = culture;

            if (!_localizedRules.ContainsKey(_currentCulture.Name.ToLowerInvariant()))
            {
                //TODO: implementation missing
            }
        }

        public bool SupportsCulture([NotNull] CultureInfo culture)
        {
            if (culture == null) throw new ArgumentNullException(nameof(culture));

            return _localizedRules.ContainsKey(culture.Name);
        }

        public string Pluralize(string word)
        {
            return ApplyRules(GetCurrentRules().Plurals, word);
        }

        public string Singularize(string word)
        {
            return ApplyRules(GetCurrentRules().Singulars, word);
        }

        public string Titleize(string word)
        {
            return Regex.Replace(Humanize(Underscore(word)), @"\b([a-z])",
                                 match => match.Captures[0].Value.ToUpper());
        }

        //TODO: this must be improved to handle Pascal Casing
        public string Humanize(string lowercaseAndUnderscoredWord)
        {
            return Capitalize(Regex.Replace(lowercaseAndUnderscoredWord, @"_", " "));
        }

        public string Pascalize(string lowercaseAndUnderscoredWord)
        {
            return Regex.Replace(lowercaseAndUnderscoredWord, "(?:^|_)(.)",
                                 match => match.Groups[1].Value.ToUpper());
        }

        public string Camelize(string lowercaseAndUnderscoredWord)
        {
            return Uncapitalize(Pascalize(lowercaseAndUnderscoredWord));
        }

        public string Underscore(string pascalCasedWord)
        {
            return Regex.Replace(
                Regex.Replace(
                    Regex.Replace(pascalCasedWord, @"([A-Z]+)([A-Z][a-z])", "$1_$2"), @"([a-z\d])([A-Z])",
                    "$1_$2"), @"[-\s]", "_").ToLower();
        }

        public string Capitalize(string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }

        public string Uncapitalize(string word)
        {
            return word.Substring(0, 1).ToLower() + word.Substring(1);
        }

        public string Ordinalize(int number)
        {
            var rules = GetCurrentRules();
            if (rules.Ordanize != null)
            {
                return rules.Ordanize(number);
            }
            return number.ToString(_currentCulture.NumberFormat);
        }

        public string Dasherize(string underscoredWord)
        {
            return underscoredWord.Replace('_', '-');
        }

        private string ApplyRules(IList<InflectorRule> rules, string word)
        {
            string result = word;

            if (!GetCurrentRules().Uncountables.Contains(word.ToLower()))
            {
                for (int i = rules.Count - 1; i >= 0; i--)
                {
                    if ((result = rules[i].Apply(word)) != null)
                    {
                        break;
                    }
                }
            }

            return result;
        }

        private InflectorRuleSet GetCurrentRules()
        {
            return _localizedRules[_currentCulture.Name.ToLowerInvariant()];
        }
    }
}
