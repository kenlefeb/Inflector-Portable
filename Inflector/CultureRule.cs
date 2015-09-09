using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Inflector
{
    public abstract class CultureRules
    {
        private readonly CultureInfo _culture;
        private readonly GrammarRules _rules;

        protected CultureRules(
            [NotNull] CultureInfo culture, 
            [NotNull] Func<GrammarRules.PluralRules, GrammarRules.PluralRules> plurals,
            [NotNull] Func<GrammarRules.SingularRules, GrammarRules.SingularRules> singulars, 
            [NotNull] Func<GrammarRules.IrregularRules, GrammarRules.IrregularRules> irregulars, 
            [NotNull] Func<GrammarRules.UncountableRules, GrammarRules.UncountableRules> uncountables, 
            [NotNull] Func<int, string> ordanizeFunc)
        {
            if (culture == null) throw new ArgumentNullException(nameof(culture));
            if (plurals == null) throw new ArgumentNullException(nameof(plurals));
            if (singulars == null) throw new ArgumentNullException(nameof(singulars));
            if (uncountables == null) throw new ArgumentNullException(nameof(uncountables));
            if (ordanizeFunc == null) throw new ArgumentNullException(nameof(ordanizeFunc));
            _culture = culture;

            _rules = new GrammarRules();
            _rules.OrdanizeFunc = ordanizeFunc;
            plurals(_rules.Plurals);
            singulars(_rules.Singulars);
            uncountables(_rules.Uncountables);
            irregulars(_rules.Irregulars);
        }

        internal InflectorRuleSet RuleSet => _rules.Rules;

        public CultureInfo Culture => _culture;
    }
}
