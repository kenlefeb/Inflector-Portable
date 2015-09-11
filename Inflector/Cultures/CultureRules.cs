using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Inflector.Cultures
{
    public abstract class CultureRules
    {
        protected CultureRules(
            [NotNull] Func<PluralRules, PluralRules> plurals,
            [NotNull] Func<SingularRules, SingularRules> singulars,
            [NotNull] Func<IrregularRules, IrregularRules> irregulars,
            [NotNull] Func<UncountableRules, UncountableRules> uncountables,
            [NotNull] Func<int, string> ordanizeFunc)
        {
            if (plurals == null) throw new ArgumentNullException(nameof(plurals));
            if (singulars == null) throw new ArgumentNullException(nameof(singulars));
            if (uncountables == null) throw new ArgumentNullException(nameof(uncountables));
            if (ordanizeFunc == null) throw new ArgumentNullException(nameof(ordanizeFunc));
            RuleSet = new InflectorRuleSet(new List<InflectorRule>(), new List<InflectorRule>(), new List<string>(), ordanizeFunc);

            Plurals = new PluralRules(RuleSet);
            Singulars = new SingularRules(RuleSet);
            Uncountables = new UncountableRules(RuleSet);
            Irregulars = new IrregularRules(Singulars, Plurals);

            plurals(Plurals);
            singulars(Singulars);
            uncountables(Uncountables);
            irregulars(Irregulars);
        }

        public PluralRules Plurals { get; }
        public SingularRules Singulars { get; }
        public UncountableRules Uncountables { get; }
        public IrregularRules Irregulars { get; }

        internal InflectorRuleSet RuleSet { get; }
    }
}
