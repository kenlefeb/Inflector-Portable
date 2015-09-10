using System;
using System.Collections.Generic;

namespace Inflector
{
    internal class InflectorRuleSet
    {
        public InflectorRuleSet(IList<InflectorRule> plurals, IList<InflectorRule> singulars, IList<string> uncountables, Func<int, string> ordanizeFunc)
        {
            Plurals = plurals;
            Singulars = singulars;
            Uncountables = uncountables;
            Ordanize = ordanizeFunc;
        }

        internal IList<InflectorRule> Plurals { get; }
        internal IList<InflectorRule> Singulars { get; }
        internal IList<string> Uncountables { get; }

        internal Func<int, string> Ordanize { get; set; }
    }
}