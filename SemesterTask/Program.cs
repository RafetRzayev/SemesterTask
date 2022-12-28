using System;

namespace SemesterTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generalMethods = new GeneralMethods();
            generalMethods.CreateEmail("Tiina-liina näide");
            generalMethods.CreateAccountName("Ts-liina näide");
            generalMethods.ElectionWereHeldAt("1995");

            Console.WriteLine();

            var statistic = new Statistic();
            statistic.ParliamentSeatsAmongParties("2022");
            Console.WriteLine();
            statistic.PopularityOfParties("2022");
            Console.WriteLine();
            statistic.MostAndLeastPopularParty("2022");
            Console.WriteLine();
            statistic.DifferencePopularity("2021", "2022", "Reformierakond");
            Console.WriteLine();
            statistic.PopularityInRange("2021", "2022");
            Console.WriteLine();
            statistic.MostPopularInRange("2021", "2022");
            Console.WriteLine();
            statistic.AllPartyNames();
        }
    }
}
