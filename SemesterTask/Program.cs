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
            var accountName = generalMethods.CreateAccountName("Ts-liina näide");
            Console.WriteLine($"Created {accountName} account name and appended the accountNames.txt file");

            string year = "1995";
            var electionWereHeldAt = generalMethods.ElectionWereHeldAt(year);
            if (electionWereHeldAt)
                Console.WriteLine($"Election were held at {year}");
            else
                Console.WriteLine($"Election weren't held at {year}");

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

            Console.WriteLine("All party names");

            foreach (var partyName in statistic.AllPartyNames())
            {
                Console.WriteLine(partyName);
            }
            
            Console.WriteLine();

            #endregion

            #region 2019 Election analysis

            var electionAnalysis = new ParliamentElectionAnalysis();
            var tresholdValue = electionAnalysis.ElectoralTresholdValue();
            Console.WriteLine($"Treshold value: {tresholdValue}");
            Console.WriteLine();
            electionAnalysis.PartiesExceedTresholdValue();
            Console.WriteLine();
            var districtNumber = 11;
            var simpleQuota = electionAnalysis.QuotaForElectoralDistrict(districtNumber);
            Console.WriteLine($"Simple quota for electoral district number {districtNumber} is {simpleQuota}");
            Console.WriteLine();
            electionAnalysis.DistrictMandators(districtNumber);
            Console.WriteLine();
            electionAnalysis.Print(districtNumber);

            Console.WriteLine();

            #endregion

            #region Advanced task

            var advancedTasks = new AdvancedTasks();
            var mostStabileParties = advancedTasks.MostStabileParties();

            Console.WriteLine("Most stabile parties:");
            foreach (var item in mostStabileParties)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var mostFluctuatingParties = advancedTasks.MostFluctuatingParties();

            Console.WriteLine("Most fluctuating parties:");
            foreach (var item in mostFluctuatingParties)
            {
                Console.WriteLine(item);
            }

            #endregion
        }
    }
}
