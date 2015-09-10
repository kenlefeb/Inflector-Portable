using System;
using System.Globalization;
using JetBrains.Annotations;

namespace Inflector.Rules
{
    public abstract class CultureRules
    {
        private readonly GrammarRules _rules;

        protected CultureRules(
            [NotNull] CultureInfo culture, 
            [NotNull] Func<PluralRules,PluralRules> plurals,
            [NotNull] Func<SingularRules, SingularRules> singulars, 
            [NotNull] Func<IrregularRules, IrregularRules> irregulars, 
            [NotNull] Func<UncountableRules, UncountableRules> uncountables, 
            [NotNull] Func<int, string> ordanizeFunc)
        {
            if (culture == null) throw new ArgumentNullException(nameof(culture));
            if (plurals == null) throw new ArgumentNullException(nameof(plurals));
            if (singulars == null) throw new ArgumentNullException(nameof(singulars));
            if (uncountables == null) throw new ArgumentNullException(nameof(uncountables));
            if (ordanizeFunc == null) throw new ArgumentNullException(nameof(ordanizeFunc));
            Culture = culture;

            _rules = new GrammarRules();
            _rules.OrdanizeFunc = ordanizeFunc;
            plurals(_rules.Plurals);
            singulars(_rules.Singulars);
            uncountables(_rules.Uncountables);
            irregulars(_rules.Irregulars);
        }

        internal InflectorRuleSet RuleSet => _rules.Rules;

        public CultureInfo Culture { get; }
    }
}
