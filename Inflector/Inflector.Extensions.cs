using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inflector
{
    public static class InflectorExtensions
    {
        private static CultureInfo GetCurrentCulture()
        {
            if (Inflector.SetDefaultCultureFunc == null)
            {
                throw new NotSupportedException("Could not determinate the default culture. Make sure Inflector.SetDefaultCultureFunc is defined.");
            }
            return Inflector.SetDefaultCultureFunc();
        }

        public static string Pluralize(this string word)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Pluralize(word);
        }

        public static string Singularize(this string word)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Singularize(word);
        }

        public static string Titleize(this string word)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Titleize(word);

        }

        public static string Humanize(this string lowercaseAndUnderscoredWord)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Humanize(lowercaseAndUnderscoredWord);
        }

        public static string Pascalize(this string lowercaseAndUnderscoredWord)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Pascalize(lowercaseAndUnderscoredWord);
        }

        public static string Camelize(this string lowercaseAndUnderscoredWord)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Camelize(lowercaseAndUnderscoredWord);
        }

        public static string Underscore(this string pascalCasedWord)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Underscore(pascalCasedWord);
        }

        public static string Capitalize(this string word)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Capitalize(word);
        }

        public static string Uncapitalize(this string word)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Uncapitalize(word);
        }


        public static string Ordinalize(this int number)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Ordinalize(number);
        }


        public static string Dasherize(this string underscoredWord)
        {
            Inflector inflector = new Inflector(GetCurrentCulture());
            return inflector.Dasherize(underscoredWord);
        }

    }
}
