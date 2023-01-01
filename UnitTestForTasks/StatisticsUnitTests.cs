using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemesterTask;
using System.Collections.Generic;

namespace UnitTestForTasks
{
    [TestClass]
    public class StatisticsUnitTests
    {
        [TestMethod]
        public void AllPartyNamesTest()
        {
            var statistic = new Statistic();

            var realResult = statistic.AllPartyNames();
            var exceptedResult = new List<string>
            {
                "Keskerakond", "EKRE", "Eestimaa Rohelised", "Eesti 200", "SDE",
                "Isamaa","Reformierakond","Vabaerakond","Elurikkuse erakond","Tulevikuerakond",
                "Erakond parempoolsed"
            };
       
            CollectionAssert.AreEqual(exceptedResult, realResult);
        }
    }
}
