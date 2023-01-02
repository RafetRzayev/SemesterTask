using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemesterTask;

namespace UnitTestForTasks
{
    [TestClass]
    public class GeneralMethodUnitTests
    {
        [TestMethod]
        public void CreatedEmailTestCase1()
        {
            var generalMethods = new GeneralMethods();

            var realResult = generalMethods.CreateEmail("Tiina-liina näide");
            var exceptedResult = new string[] { "tiina.liina.näide@parlamanet.ee", "tiina.liina.näide@parlamanet.eu" };

            CollectionAssert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void CreatedEmailTestCase2()
        {
            var generalMethods = new GeneralMethods();

            var realResult = generalMethods.CreateEmail("xyz-de asd");
            var exceptedResult = new string[] { "xyz.de.asd@parlamanet.ee", "xyz.de.asd@parlamanet.eu" };

            CollectionAssert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void CreatedEmailTestCase3()
        {
            var generalMethods = new GeneralMethods();

            var realResult = generalMethods.CreateEmail("Ks-Pierso Caca");
            var exceptedResult = new string[] { "ks.pierso.caca@parlamanet.ee", "ks.pierso.caca@parlamanet.eu" };

            CollectionAssert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void CreatedAccountNameTestCase1()
        {
            var generalMethods = new GeneralMethods();

            var realResult = generalMethods.CreateAccountName("Ts-liina näide");
            var exceptedResult = "tlnäide";

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void CreatedAccountNameTestCase2()
        {
            var generalMethods = new GeneralMethods();
            var realResult = generalMethods.CreateAccountName("xy zdt asdfg");
            var exceptedResult = "xzasdfg";

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void ElectionWereHeldAt1995()
        {
            var generalMethods = new GeneralMethods();

            var realResult = generalMethods.ElectionWereHeldAt("1995");
            var exceptedResult = true;

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void ElectionWereHeldAt1990()
        {
            var generalMethods = new GeneralMethods();

            var realResult = generalMethods.ElectionWereHeldAt("1990");
            var exceptedResult = false;

            Assert.AreEqual(exceptedResult, realResult);
        }
    }
}
