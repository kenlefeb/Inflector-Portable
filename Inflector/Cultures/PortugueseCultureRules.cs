namespace Inflector.Cultures
{
    public class PortugueseCultureRules : CultureRules
    {
        public PortugueseCultureRules() :
            base(plurals => plurals
                                .Add("$", "s")
                                .Add("()r$", "$1res")
                                .Add("()ão$", "$1ões")
                                .Add("()um$", "$1uns")
                                .Add("()s$", "$1ses")
                                .Add("()il$", "$1is")
                                .Add("()m$", "$1ns")
                                .Add("()ol$", "$1óis")
                                .Add("()x$", "$1xes")
                                .Add("()al$", "$1ais")
                                .Add("()el$", "$1éis")
                                .Add("(ul)$", "$1es")
                                .Add("()zul$", "$1zuis")
                                .Add("()guês$", "$1gueses")
                                .Add("()z$", "$1zes"),
                 singulars => singulars
                                  .Add("s$", "")
                                  .Add("(n)ews$", "$1ews")
                                  .Add("([ti])a$", "$1um")
                                  .Add("((a)naly|(b)a|(d)iagno|(p)arenthe|(p)rogno|(s)ynop|(t)he)ses$", "$1$2sis")
                                  .Add("(^analy)ses$", "$1sis")
                                  .Add("([^f])ves$", "$1fe")
                                  .Add("(hive)s$", "$1")
                                  .Add("(tive)s$", "$1")
                                  .Add("([lr])ves$", "$1f")
                                  .Add("([^aeiouy]|qu)ies$", "$1y")
                                  .Add("(s)eries$", "$1eries")
                                  .Add("(m)ovies$", "$1ovie")
                                  .Add("(x|ch|ss|sh)es$", "$1")
                                  .Add("([m|l])ice$", "$1ouse")
                                  .Add("(bus)es$", "$1")
                                  .Add("(o)es$", "$1")
                                  .Add("(shoe)s$", "$1")
                                  .Add("(cris|ax|test)es$", "$1is")
                                  .Add("(octop|vir|alumn|fung)i$", "$1us")
                                  .Add("(alias|status)es$", "$1")
                                  .Add("^(ox)en", "$1")
                                  .Add("(vert|ind)ices$", "$1ex")
                                  .Add("(matr)ices$", "$1ix")
                                  .Add("(quiz)zes$", "$1"),
                 irregulars => irregulars
                                   .Add("catalão", "catalães")
                                   .Add("alemão", "alemães")
                                   .Add("cão", "cães")
                                   .Add("capitão", "catalães")
                                   .Add("escrivão", "escrivães")
                                   .Add("pão", "pães")
                                   .Add("cidadão", "cidadãos")
                                   .Add("cortesão", "cortesãos")
                                   .Add("cristão", "cristãos")
                                   .Add("irmão", "irmãos")
                                   .Add("pagão", "pagãos")
                                   .Add("acórdão", "acórdãos")
                                   .Add("bênção", "bênçãos")
                                   .Add("órfão", "órfãos")
                                   .Add("órgão", "órgãos")
                                   .Add("sótão", "sótãos")
                                   .Add("qualquer", "quaisquer")
                                   .Add("palavra-chave", "palavras-chave")
                                   .Add("segunda-feira", "segundas-feiras")
                                   .Add("terça-feira", "terças-feiras")
                                   .Add("quarta-feira", "quartas-feiras")
                                   .Add("quinta-feira", "quintas-feiras")
                                   .Add("sexta-feira", "sextas-feiras"),
                 uncountables => uncountables
                                     .Add("toráx")
                                     .Add("fénix")
                                     .Add("louva-a-deus"),
                 number =>
                 {
                     var numberString = number.ToString();

                     if (number == 0)
                     {
                         return numberString;
                     }
                     return numberString + "º";
                 })
        {
        }
    }
}
