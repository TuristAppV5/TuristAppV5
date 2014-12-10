using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristAppV5.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
namespace TuristAppV5.Tests
{
    [TestClass()]
    public class KommentarTests
    {
        private Kommentar _kommentar;

        [TestInitialize]

        public void BeforeTest()
        {
            _kommentar = new Kommentar();
        }

        [TestMethod]
        public void ChechKommentarNameText()
        {

            string navn1 = null;
            string navn2 = "";
            string navn3 = "a";
            string navn4 = "";
            for (int i = 0; i < 30; i++)
            {
                navn4 = navn4 + "a";
            }
            string navn5 = "";
            for (int i = 0; i < 31; i++)
            {
                navn5 = navn5 + "";
            }
            // hvis navnet er null
            _kommentar.Navn = navn3;
            Assert.AreEqual(navn3, _kommentar.Navn);
            try
            {
                _kommentar.Navn = navn1;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Navnet skal indeholde tegn og må højst være 30 tegn", ex.Message);
            }
            // hvis navnet er tomt
            _kommentar.Navn = navn4;
            Assert.AreEqual(navn4, _kommentar.Navn);
            try
            {
                _kommentar.Navn = navn2;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Navnet skal indeholde tegn og må højst være 30 tegn", ex.Message);
            }

            // hvis navnet er på 31 tegn
            _kommentar.Navn = navn4;
            Assert.AreEqual(navn4, _kommentar.Navn);
            try
            {
                _kommentar.Navn = navn2;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Navnet skal indeholde tegn og må højst være 30 tegn", ex.Message);
            }

        }

        [TestMethod]
        public void CheckKommentarTekstTest()
        {
            string text1 = null;
            string text2 = "";
            string Text3 = "";

            for (int i = 0; i < 19; i++)
            {
                Text3 = Text3 = "a";
            }

            string text4 = "";
            for (int i = 0; i < 20; i++)
            {
                text4 = text4 + "a";
            }

            string text5 = "";
            for (int i = 0; i < 500; i++)
            {
                text5 = text5 + "a";
            }

            string text6 = "";
            for (int i = 0; i < 501; i++)
            {
                text6 = text6 + "a";
            }
            // hvis teksten er null
            _kommentar.Tekst = text4;
            Assert.AreEqual(text4, _kommentar.Tekst);
            try
            {
                _kommentar.Tekst = text1;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Beskrivelsen skal indeholde tegn og må højst være 500 tegn", ex.Message);
            }

            _kommentar.Tekst = text5; // hvis teksten er tom
            Assert.AreEqual(text5, _kommentar.Tekst);
            try
            {
                _kommentar.Tekst = text2;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual("Beskrivelsen skal indeholde tegn og må højst være 500 tegn", ex.Message);
            }
            // hvis teksten er 19 tegn lang 
            _kommentar.Tekst = text5;
            Assert.AreEqual(text5, _kommentar.Tekst);
            try
            {
                _kommentar.Tekst = Text3;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Beskrivelsen skal indeholde tegn og må højst være 500 tegn", ex.Message);

            }
            // hvis teksten er over 500 tegn 
            _kommentar.Tekst = text5;
            Assert.AreEqual(text5, _kommentar.Tekst);
            try
            {
                _kommentar.Tekst = text6;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Beskrivelsen skal indeholde tegn og må højst være 500 tegn", ex.Message);
            }
        }
    }
}
