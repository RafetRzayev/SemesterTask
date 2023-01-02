using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemesterTask;
using System.Collections.Generic;

namespace UnitTestForTasks
{
    [TestClass]
    public class AdvancedTaskUnitTests
    {
        [TestMethod]
        public void MostStabilePartiesTest()
        {
            var advancedTask = new AdvancedTasks();

            var realResult = advancedTask.MostStabileParties();
            var exceptedResult = new List<string> { "Tulevikuerakond" };

            CollectionAssert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void MostFluctuatingPartiesTest()
        {
            var advancedTask = new AdvancedTasks();

            var realResult = advancedTask.MostFluctuatingParties();
            var exceptedResult = new List<string> { "EKRE" };

            CollectionAssert.AreEqual(exceptedResult, realResult);
        }
    }
}
