using System;
using System.Collections.Generic;

namespace Inflector
{
    public class GrammarRules
    {
        internal GrammarRules()
        {
            Rules = new InflectorRuleSet(
                new List<InflectorRule>(),
                new List<InflectorRule>(),
                new List<string>(), 
                null);

            Plurals = new PluralRules(Rules);
            Singulars = new SingularRules(Rules);
            Irregulars = new IrregularRules(Rules, Singulars, Plurals);
            Uncountables = new UncountableRules(Rules);

        }

        public Func<int, string> OrdanizeFunc
        {
            get { return Rules.Ordanize; }
            set { Rules.Ordanize = value; } 
        }

        public PluralRules Plurals { get; }

        public SingularRules Singulars { get; }

        public IrregularRules Irregulars { get; }

        public UncountableRules Uncountables { get; }

        internal InflectorRuleSet Rules { get; }

        public class PluralRules
        {
            private readonly InflectorRuleSet _rules;

            public PluralRules(InflectorRuleSet rules)
            {
                _rules = rules;
            }

            public PluralRules Add(string ruleExpression, string replacementExpression)
            {
                _rules.Plurals.Add(new InflectorRule(ruleExpression, replacementExpression));
                return this;
            }
        }

        public class SingularRules
        {
            private readonly InflectorRuleSet _rules;

            public SingularRules(InflectorRuleSet rules)
            {
                _rules = rules;
            }

            public SingularRules Add(string ruleExpression, string replacementExpression)
            {
                _rules.Singulars.Add(new InflectorRule(ruleExpression, replacementExpression));
                return this;
            }
        }

        public class IrregularRules
        {
            private readonly PluralRules _plurals;
            private readonly InflectorRuleSet _rules;
            private readonly SingularRules _singulars;

            public IrregularRules(InflectorRuleSet rules, SingularRules singulars, PluralRules plurals)
            {
                _rules = rules;
                _singulars = singulars;
                _plurals = plurals;
            }

            public IrregularRules Add(string singular, string plural)
            {
                _plurals.Add("(" + singular[0] + ")" + singular.Substring(1) + "$", "$1" + plural.Substring(1));
                _singulars.Add("(" + plural[0] + ")" + plural.Substring(1) + "$", "$1" + singular.Substring(1));
                return this;
            }
        }

        public class UncountableRules
        {
            private readonly InflectorRuleSet _rules;

            public UncountableRules(InflectorRuleSet rules)
            {
                _rules = rules;
            }

            public UncountableRules Add(string word)
            {
                _rules.Uncountables.Add(word.ToLowerInvariant());
                return this;
            }
        }
    }
}
