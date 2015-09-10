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
                                  .Add("(xul)es$", "$1")
                                  .Add("()res$", "$1r")
                                  .Add("()ões", "$1ão")
                                  .Add("()uns", "$1um")
                                  .Add("()ses$", "$1s")
                                  .Add("()is$", "$1il")
                                  .Add("()ns$", "$1m")
                                  .Add("(s|ç)óis$", "$1ol")
                                  .Add("()xes$", "$1x")
                                  .Add("(ei)xes$", "$1xe")
                                  .Add("()ais$", "$1al")
                                  .Add("()éis$", "$1el")
                                  .Add("()zuis$", "$1zul")
                                  .Add("()gueses$", "$1guês")
                                  .Add("()zes$", "$1z"),
                 irregulars => irregulars
                                   .Add("catalão", "catalães")
                                   .Add("alemão", "alemães")
                                   .Add("cão", "cães")
                                   .Add("capitão", "capitães")
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
