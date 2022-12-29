using System;

namespace SemesterTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region General methods

            var generalMethods = new GeneralMethods();
            generalMethods.CreateEmail("Tiina-liina näide");
            generalMethods.CreateAccountName("Ts-liina näide");
            generalMethods.ElectionWereHeldAt("1995");

            Console.WriteLine();

            #endregion

            #region Statistics

            var statistic = new Statistic();
            statistic.ParliamentSeatsAmongParties("2022");
            Console.WriteLine();
            statistic.PopularityOfParties("2022");
            Console.WriteLine();
            statistic.MostAndLeastPopularParty("2022");
            Console.WriteLine();
            statistic.DifferencePopularity("2020", "2022", "Reformierakond");
            Console.WriteLine();
            statistic.PopularityInRange("2010", "2022");
            Console.WriteLine();
            statistic.MostPopularInRange("2010", "2022");
            Console.WriteLine();
            statistic.AllPartyNames();

            Console.WriteLine();

            #endregion

            #region 2019 Election analysis

            var electionAnalysis = new ParliamentElectionAnalysis();
            var tresholdValue = electionAnalysis.ElectoralTresholdValue();
            Console.WriteLine($"Treshold value: {tresholdValue}");
            Console.WriteLine();
            electionAnalysis.PartiesExceedTresholdValue();
            Console.WriteLine();
            var districtNumber = 2;
            var simpleQuota = electionAnalysis.QuotaForElectoralDistrict(districtNumber);
            Console.WriteLine($"Simple quota for electoral district number {districtNumber} is {simpleQuota}");
            Console.WriteLine();
            electionAnalysis.DistrictMandators(districtNumber);
            Console.WriteLine();
            electionAnalysis.Print(districtNumber);

            #endregion
        }
    }
}
