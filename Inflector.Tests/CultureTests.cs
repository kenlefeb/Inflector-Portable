using System;
using System.Globalization;
using NUnit.Framework;

namespace Inflector.Tests
{
    [TestFixture]
    public class CultureTests : InflectorTestBase
    {
        [SetUp]
        public void Init()
        {
            Inflector.SetDefaultCultureFunc = null;
        }

        [Test]
        public void DefaultCulture()
        {
            Inflector.SetDefaultCultureFunc = () => new CultureInfo("pt");

            Assert.AreEqual("anéis", "anel".Pluralize());
        }

        [Test]
        public void EnglishCulture()
        {
            var inflector = new Inflector(new CultureInfo("en"));

            Assert.AreEqual("cats", inflector.Pluralize("cat"));
        }

        [Test]
        public void MostSimilarCulture()
        {
            Inflector.SetDefaultCultureFunc = () => new CultureInfo("pt-PT");
            Assert.AreEqual("homens", "homem".Pluralize());
        }

        [Test]
        public void RuntimeCultureSwitch()
        {
            Inflector.SetDefaultCultureFunc = () => new CultureInfo("en");
            Assert.AreEqual("indices", "index".Pluralize());

            Inflector.SetDefaultCultureFunc = () => new CultureInfo("pt");
            Assert.AreEqual("homens", "homem".Pluralize());
        }

        [Test]
        public void UnsupportedCulture()
        {
            Assert.Catch<NotSupportedException>(() =>
                                                {
                                                    var inflector = new Inflector(new CultureInfo("fr"));
                                                    var hommes = inflector.Pluralize("homme");
                                                });
        }

        [Test]
        public void UnsupportedDefaultCulture()
        {
            Assert.Catch<NotSupportedException>(() =>
                                                {
                                                    Inflector.SetDefaultCultureFunc = () => new CultureInfo("fr");
                                                    var hommes = "homme".Pluralize();
                                                });
        }
    }
}
