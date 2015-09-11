using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using Inflector.Cultures;
using JetBrains.Annotations;

namespace Inflector
{
    public class Inflector
    {
        private static readonly Dictionary<string, Lazy<InflectorRuleSet>> _localizedRules;
        private readonly CultureInfo _currentCulture;

        //TODO: this will be replaced with a DI engine 
        static Inflector()
        {
            _localizedRules = new Dictionary<string, Lazy<InflectorRuleSet>>
                              {
                                  {"en", new Lazy<InflectorRuleSet>(() => new EnglishCultureRules().RuleSet)},
                                  {"pt", new Lazy<InflectorRuleSet>(() => new PortugueseCultureRules().RuleSet)}
                              };
        }

        public static Func<CultureInfo> SetDefaultCultureFunc;

        public Inflector([NotNull] CultureInfo culture)
        {
            if (culture == null) throw new ArgumentNullException(nameof(culture));

            _currentCulture = GetMostSimilarCulture(culture);

            if (_currentCulture == null)
            {
                if (SetDefaultCultureFunc != null)
                {
                    Debug.Write("Falling back to default culture.", "WARN");
                    _currentCulture = GetMostSimilarCulture(SetDefaultCultureFunc());
                }

                if (_currentCulture == null)
                {
                    throw new NotSupportedException($"The specificed culture '{culture.Name}' is not supported.");
                }
            }

        }

        public bool SupportsCulture([NotNull] CultureInfo culture)
        {
            if (culture == null) throw new ArgumentNullException(nameof(culture));

            var mostSimilarCulture = GetMostSimilarCulture(culture);

            return mostSimilarCulture != null;
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

        //TODO: this is not generalizable to other cultures since it does not supoorts grammatical gender
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

        private CultureInfo GetMostSimilarCulture(CultureInfo culture)
        {
            var cultureName = culture.Name.ToLowerInvariant();
            if (_localizedRules.ContainsKey(cultureName))
            {
                return culture;
            }
            if (cultureName.Length > 2)
            {
                cultureName = cultureName.Substring(0, 2);
                if (_localizedRules.ContainsKey(cultureName))
                {
                    return new CultureInfo(cultureName);
                }
            }

            return null;
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

            return result ?? word;
        }

        private InflectorRuleSet GetCurrentRules()
        {
            return _localizedRules[_currentCulture.Name.ToLowerInvariant()].Value;
        }
    }
}
