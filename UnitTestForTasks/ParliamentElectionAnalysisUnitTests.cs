using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemesterTask;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestForTasks
{
    [TestClass]
    public class ParliamentElectionAnalysisUnitTests
    {
        [TestMethod]
        public void ElectoralTresholdValueTest()
        {
            var electionAnalysis = new ParliamentElectionAnalysis();
           
            var realResult = electionAnalysis.ElectoralTresholdValue();
            var exceptedResult = 28057;

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void QuotaForElectoralDistrictTest()
        {
            var electionAnalysis = new ParliamentElectionAnalysis();

            var realResult = electionAnalysis.QuotaForElectoralDistrict(11);
            var exceptedResult = 5386.25;

            Assert.AreEqual(exceptedResult, realResult);
        }
    }
}
