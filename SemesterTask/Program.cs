using SemesterTask.Models;
using System;

namespace SemesterTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region General methods

            var generalMethods = new GeneralMethods();

            var createdEmails = generalMethods.CreateEmail("Tiina-liina näide");
            Console.WriteLine($"Created {createdEmails[0]}, {createdEmails[1]}\n");

            var accountName = generalMethods.CreateAccountName("Ts-liina näide");
            Console.WriteLine($"Created {accountName} account name and appended the accountNames.txt file\n");

            string year = "1995";
            var electionWereHeldAt = generalMethods.ElectionWereHeldAt(year);
            if (electionWereHeldAt)
                Console.WriteLine($"Election were held at {year}\n");
            else
                Console.WriteLine($"Election weren't held at {year}\n");

            #endregion

            #region Statistics

            var statistic = new Statistic();

            var supportDetails = statistic.ParliamentSeatsAmongParties("2022");
            /*
             * In order to make it neat, we allocate 25 characters 
             * for the party name and 5 characters for the number of chairs
             */
            Console.WriteLine($"{"Party name",-25}{"Seats",-5}");
            foreach (var supportDetail in supportDetails)
            {
                Console.WriteLine($"{supportDetail.PartyName,-25}{supportDetail.SupportPercent,-5}");
            }
            Console.WriteLine();

            Console.WriteLine("All possible combinations:");
            statistic.PossibleCombinationOfParties("2022");
            Console.WriteLine();

            statistic.PopularityOfParties("2022");
            Console.WriteLine();

            statistic.MostAndLeastPopularParty("2022");
            Console.WriteLine();
            
            var difference = statistic.DifferencePopularity("2020", "2022", "Keskerakond");

            if (difference > 0)
                Console.WriteLine($"grew {difference}%\n");
            else if (difference < 0)
                Console.WriteLine($"decrease {-difference}%\n");
            else
                Console.WriteLine($"Doesn't changed support percantage\n");

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
            Console.WriteLine($"Treshold value: {tresholdValue}\n");

            electionAnalysis.PartiesExceedTresholdValue();
            Console.WriteLine();

            var districtNumber = 4;
            var simpleQuota = electionAnalysis.QuotaForElectoralDistrict(districtNumber);
            Console.WriteLine($"Simple quota for electoral district number {districtNumber} is {simpleQuota}\n");

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
