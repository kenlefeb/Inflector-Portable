using System.Globalization;
using NUnit.Framework;

namespace Inflector.Tests
{
    [TestFixture]
    public class PortuguesePluralizeTests : InflectorTestBase
    {
        [Test]
        public void Pluralize()
        {
            foreach (var pair in TestData)
            {
                Assert.AreEqual(pair.Value, pair.Key.Pluralize());
            }
        }

        [Test]
        public void Singularize()
        {
            foreach (var pair in TestData)
            {
                Assert.AreEqual(pair.Key, pair.Value.Singularize());
            }
        }

        public PortuguesePluralizeTests()
        {
            Inflector.SetDefaultCultureFunc = () => new CultureInfo("pt");

            TestData.Add("a", "as");
            TestData.Add("o", "os");
            TestData.Add("um", "uns");

            TestData.Add("utilizador", "utilizadores");
            TestData.Add("aplicação", "aplicações");
            TestData.Add("algum", "alguns");
            TestData.Add("país", "países");
            TestData.Add("deus", "deuses");
            TestData.Add("matriz", "matrizes");
            TestData.Add("categoria", "categorias");
            TestData.Add("filme", "filmes");
            TestData.Add("indice", "indices");
            TestData.Add("cliente", "clientes");
            TestData.Add("perfil", "perfis");
            TestData.Add("homem", "homens");
            TestData.Add("mulher", "mulheres");
            TestData.Add("peixe", "peixes");
            TestData.Add("departamento", "departamentos");
            TestData.Add("item", "itens");

            TestData.Add("segunda-feira", "segundas-feiras");
            TestData.Add("terça-feira", "terças-feiras");
            TestData.Add("quarta-feira", "quartas-feiras");
            TestData.Add("quinta-feira", "quintas-feiras");
            TestData.Add("sexta-feira", "sextas-feiras");


            TestData.Add("palavra-chave", "palavras-chave");
            TestData.Add("qualquer", "quaisquer");

            TestData.Add("sol", "sóis");
            TestData.Add("girasol", "girasóis");

            TestData.Add("pé", "pés");
            TestData.Add("pontapé", "pontapés");


            TestData.Add("malmequer", "malmequeres");
            TestData.Add("gentil", "gentis");

            TestData.Add("louva-a-deus", "louva-a-deus");


            TestData.Add("toráx", "toráx");
            TestData.Add("fénix", "fénix");
            TestData.Add("fax", "faxes");

            TestData.Add("catalão", "catalães");
            TestData.Add("alemão", "alemães");
            TestData.Add("cão", "cães");
            TestData.Add("capitão", "capitães");
            TestData.Add("escrivão", "escrivães");
            TestData.Add("pão", "pães");

            TestData.Add("cidadão", "cidadãos");
            TestData.Add("cortesão", "cortesãos");
            TestData.Add("cristão", "cristãos");
            TestData.Add("irmão", "irmãos");
            TestData.Add("pagão", "pagãos");
            TestData.Add("acórdão", "acórdãos");
            TestData.Add("bênção", "bênçãos");
            TestData.Add("órfão", "órfãos");
            TestData.Add("órgão", "órgãos");
            TestData.Add("sótão", "sótãos");


            TestData.Add("quintal", "quintais");
            TestData.Add("anel", "anéis");
            TestData.Add("funil", "funis");
            TestData.Add("lençol", "lençóis");
            TestData.Add("azul", "azuis");
            TestData.Add("êxul", "êxules");

            TestData.Add("postal", "postais");
            TestData.Add("papel", "papéis");

            TestData.Add("sal", "sais");
            TestData.Add("estatal", "estatais");

            TestData.Add("português", "portugueses");

            TestData.Add("arroz", "arrozes");
            TestData.Add("gravidez", "gravidezes");
            TestData.Add("cruz", "cruzes");
            TestData.Add("variz", "varizes");
        }
    }
}
