using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemesterTask;

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
        public void QuotaForElectoralDistrict11()
        {
            var electionAnalysis = new ParliamentElectionAnalysis();

            var realResult = electionAnalysis.QuotaForElectoralDistrict(11);
            var exceptedResult = 5386.25;

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void QuotaForElectoralDistrict12()
        {
            var electionAnalysis = new ParliamentElectionAnalysis();

            var realResult = electionAnalysis.QuotaForElectoralDistrict(12);
            var exceptedResult = 5887.857142857143;

            Assert.AreEqual(exceptedResult, realResult);
        }

        [TestMethod]
        public void QuotaForElectoralDistrict4()
        {
            var electionAnalysis = new ParliamentElectionAnalysis();

            var realResult = electionAnalysis.QuotaForElectoralDistrict(4);
            var exceptedResult = 6048.6;

            Assert.AreEqual(exceptedResult, realResult);
        }
    }
}
