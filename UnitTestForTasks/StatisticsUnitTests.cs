using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemesterTask;
using SemesterTask.Models;
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

        [TestMethod]
        public void DifferencePopularityReformierakond2020_2022()
        {
            var statistic = new Statistic();

            var realResult = statistic.DifferencePopularity("2020", "2022", "Reformierakond");
            var exceptedResult = 4;

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void DifferencePopularityReformierakond2010_2022()
        {
            var statistic = new Statistic();

            var realResult = statistic.DifferencePopularity("2010", "2022", "Reformierakond");
            var exceptedResult = 9;

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void DifferencePopularityKeskerakond2010_2022()
        {
            var statistic = new Statistic();

            var realResult = statistic.DifferencePopularity("2010", "2022", "Keskerakond");
            var exceptedResult = -9;

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void DifferencePopularityKeskerakond2020_2022()
        {
            var statistic = new Statistic();

            var realResult = statistic.DifferencePopularity("2020", "2022", "Keskerakond");
            var exceptedResult = -1;

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void ParliamentSeatsAmongParties2022()
        {
            var statistic = new Statistic();

            var realResult = statistic.ParliamentSeatsAmongParties("2022");
            var exceptedResult = new List<SupportDetail>
            {
                new SupportDetail
                {
                    PartyName="Reformierakond",
                    SupportPercent=32
                },
                new SupportDetail
                {
                    PartyName="Keskerakond",
                    SupportPercent=15
                },
                new SupportDetail
                {
                    PartyName="Eestimaa Rohelised",
                    SupportPercent=3
                },
                new SupportDetail
                {
                    PartyName="Eesti 200",
                    SupportPercent=14
                },
                new SupportDetail
                {
                    PartyName="Tulevikuerakond",
                    SupportPercent=0
                },
                new SupportDetail
                {
                    PartyName="Erakond parempoolsed",
                    SupportPercent=1
                },
                new SupportDetail
                {
                    PartyName="SDE",
                    SupportPercent=8
                },
                new SupportDetail
                {
                    PartyName="EKRE",
                    SupportPercent=22
                },
                new SupportDetail
                {
                    PartyName="Isamaa",
                    SupportPercent=6
                }
            };

            CollectionAssert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void ParliamentSeatsAmongParties2020()
        {
            var statistic = new Statistic();

            var realResult = statistic.ParliamentSeatsAmongParties("2020");
            var exceptedResult = new List<SupportDetail>
            {
                new SupportDetail
                {
                    PartyName="Reformierakond",
                    SupportPercent=28
                },
                new SupportDetail
                {
                    PartyName="Keskerakond",
                    SupportPercent=16
                },
                new SupportDetail
                {
                    PartyName="Eestimaa Rohelised",
                    SupportPercent=5
                },
                new SupportDetail
                {
                    PartyName="Eesti 200",
                    SupportPercent=18
                },
                new SupportDetail
                {
                    PartyName="Tulevikuerakond",
                    SupportPercent=1
                },
                new SupportDetail
                {
                    PartyName="SDE",
                    SupportPercent=9
                },
                new SupportDetail
                {
                    PartyName="EKRE",
                    SupportPercent=17
                },
                new SupportDetail
                {
                    PartyName="Isamaa",
                    SupportPercent=7
                }
            };

            CollectionAssert.AreEqual(exceptedResult, realResult);
        }
    }
}
