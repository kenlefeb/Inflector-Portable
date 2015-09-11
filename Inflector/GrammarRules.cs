using System;
using System.Collections.Generic;

namespace Inflector
{
    public class PluralRules
    {
        private readonly InflectorRuleSet _rules;

        internal PluralRules(InflectorRuleSet rules)
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

        internal SingularRules(InflectorRuleSet rules)
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
        private readonly SingularRules _singulars;

        internal IrregularRules(SingularRules singulars, PluralRules plurals)
        {
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

        internal UncountableRules(InflectorRuleSet rules)
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
