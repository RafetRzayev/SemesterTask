using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SemesterTask
{
    internal class Statistic
    {
        private const string BASE_PATH = @"..\..\..\Statistics";

        internal void ParliamentSeatsAmongParties(string year)
        {
            /*
            Since 100 and 101 are very close numbers,
            we can calculate the percentage of popularity of the parties
            for the number of chairs.We firmly believe that
            the remaining 1 chair is reserved for the most popular party
            */

            var path = Path.Combine(BASE_PATH, year + ".txt");
            var lines = File.ReadAllLines(path);
            string partyName;
            int supportPercent;

            var supportDetails = new List<SupportDetail>();
            
            foreach (var line in lines)
            {
                /*
                Trim() deletes right and left spaces
                Since the part like the last space shows the party name,
                we use the Substring() method to take that part.
                The line after the last space shows the popularity rate
                */
                partyName = line.Trim()[..line.LastIndexOf(" ")];
                supportPercent = int.Parse(line.Trim()[line.LastIndexOf(" ")..]);

                supportDetails.Add(new SupportDetail
                {
                    PartyName = partyName,
                    SupportPercent = supportPercent
                });
            }

            var maxSupportPercent = supportDetails.Max(x => x.SupportPercent);
            supportDetails.Find(x => x.SupportPercent == maxSupportPercent).SupportPercent++;

            Console.WriteLine($"{"Party name", -25}{"Seats", -5}");

            foreach (var supportDetail in supportDetails)
            {
                Console.WriteLine($"{supportDetail.PartyName, -25}{supportDetail.SupportPercent, -5}");
            }
        }

        internal void PossibleCombinationOfParties(string year)
        {
            var path = Path.Combine(BASE_PATH, year + ".txt");
            var lines = File.ReadAllLines(path);
            string partyName;
            int supportPercent;
            int seatCount;
            var keyValuePairs = new SortedDictionary<int, string>();

            foreach (var line in lines)
            {
                partyName = line.Trim()[..line.LastIndexOf(" ")];
                supportPercent = int.Parse(line.Trim()[line.LastIndexOf(" ")..]);

                seatCount = (int)Math.Round(101 * supportPercent / 100.0);

                keyValuePairs.Add(seatCount, partyName);
            }
        }

        internal void PopularityOfParties(string year)
        {
            var path = Path.Combine(BASE_PATH, year + ".txt");
            var lines = File.ReadAllLines(path);
            string partyName;
            int supportPercent;

            var supportDetails = new List<SupportDetail>();

            foreach (var line in lines)
            {
                partyName = line.Trim()[..line.LastIndexOf(" ")];
                supportPercent = int.Parse(line.Trim()[line.LastIndexOf(" ")..]);

                supportDetails.Add(new SupportDetail
                {
                    PartyName = partyName,
                    SupportPercent = supportPercent
                });
            }

            supportDetails.Sort((y, x) =>
            {
                return x.SupportPercent.CompareTo(y.SupportPercent);
            });

            Console.WriteLine($"{"Party name", -25}{"Popularity percent", -5}");

            foreach (var supportDetail in supportDetails)
            {
                Console.WriteLine($"{supportDetail.PartyName, -25}{supportDetail.SupportPercent + "%", -5}");
            }
        }

        internal void MostAndLeastPopularParty(string year)
        {
            var path = Path.Combine(BASE_PATH, year + ".txt");
            var lines = File.ReadAllLines(path);
            string partyName;
            int supportPercent;

            var supportDetails = new List<SupportDetail>();

            foreach (var line in lines)
            {
                partyName = line.Trim()[..line.LastIndexOf(" ")];
                supportPercent = int.Parse(line.Trim()[line.LastIndexOf(" ")..]);

                supportDetails.Add(new SupportDetail
                {
                    PartyName = partyName,
                    SupportPercent = supportPercent
                });
            }

            var maxPercent = supportDetails.Max(x => x.SupportPercent);
            var minPercent = supportDetails.Min(x => x.SupportPercent);
            var mostPopuplar = supportDetails.Find(x => x.SupportPercent == maxPercent);
            var leastPopuplar = supportDetails.Find(x => x.SupportPercent == minPercent);

            Console.WriteLine($"Most popular party:{mostPopuplar.PartyName,-25}\nPopularity percent:{mostPopuplar.SupportPercent + "%",-5}");
            Console.WriteLine($"Least popular party:{leastPopuplar.PartyName,-25}\nPopularity percent:{leastPopuplar.SupportPercent + "%",-5}");
        }

        internal void DifferencePopularity(string year1, string year2, string partyName)
        {
            var path = Path.Combine(BASE_PATH, year1 + ".txt");
            var lines = File.ReadAllLines(path);
            string partyNameFromFile;
            int supportPercentYear1 = 0;
            int supportPercentYear2 = 0;

            foreach (var line in lines)
            {
                partyNameFromFile = line.Trim()[..line.LastIndexOf(" ")];

                if (partyNameFromFile.Equals(partyName))
                {
                    supportPercentYear1 = int.Parse(line.Trim()[line.LastIndexOf(" ")..]);
                    break;
                }
            }

            path = Path.Combine(BASE_PATH, year2 + ".txt");
            lines = File.ReadAllLines(path);

            foreach (var line in lines)
            {
                partyNameFromFile = line.Trim()[..line.LastIndexOf(" ")];

                if (partyNameFromFile.Equals(partyName))
                {
                    supportPercentYear2 = int.Parse(line.Trim()[line.LastIndexOf(" ")..]);
                    break;
                }
            }

            var difference = supportPercentYear2 - supportPercentYear1;
            if (difference > 0)
            {
                Console.WriteLine($"grew {difference}%");
            }
            else if(difference < 0)
            {
                Console.WriteLine($"decrease {difference}%");
            }
            else
            {
                Console.WriteLine($"Doesn't changed support percantage");
            }
        }

        internal void PopularityInRange(string year1InString, string year2InString)
        {
            string partyName;
            int supportPercent;
            int year1=int.Parse(year1InString);
            int year2 = int.Parse(year2InString);
            var supportDetails = new List<SupportDetail>();

            for (int i = Math.Min(year1, year2); i <= Math.Max(year1, year2); i++)
            {
                var path = Path.Combine(BASE_PATH, i + ".txt");
                var lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    partyName = line.Trim()[..line.LastIndexOf(" ")];
                    supportPercent = int.Parse(line.Trim()[line.LastIndexOf(" ")..]);

                    supportDetails.Add(new SupportDetail
                    {
                        PartyName = partyName,
                        SupportPercent = supportPercent
                    });
                }

                var maxPercent = supportDetails.Max(x => x.SupportPercent);
                var minPercent = supportDetails.Min(x => x.SupportPercent);
                var mostPopuplar = supportDetails.Find(x => x.SupportPercent == maxPercent);
                var leastPopuplar = supportDetails.Find(x => x.SupportPercent == minPercent);

                Console.WriteLine($"{i} - {mostPopuplar.PartyName},{leastPopuplar.PartyName}");

                supportDetails.Clear();
            }
        }

        internal void MostPopularInRange(string year1InString, string year2InString)
        {
            string partyName;
            int supportPercent;
            int year1 = int.Parse(year1InString);
            int year2 = int.Parse(year2InString);

            var supportDetails = new List<SupportDetail>();

            var maxPercent = 0;
            var mostPopularPartyName = "";
            var mostPopularYear = Math.Min(year1, year2);

            for (int i = Math.Min(year1, year2); i <= Math.Max(year1, year2); i++)
            {
                var path = Path.Combine(BASE_PATH, i + ".txt");
                var lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    partyName = line.Trim()[..line.LastIndexOf(" ")];
                    supportPercent = int.Parse(line.Trim()[line.LastIndexOf(" ")..]);

                    supportDetails.Add(new SupportDetail
                    {
                        PartyName = partyName,
                        SupportPercent = supportPercent
                    });

                    if (maxPercent < supportPercent)
                    {
                        maxPercent = supportPercent;
                        mostPopularPartyName = partyName;
                        mostPopularYear = i;
                    }
                }
            }

            Console.WriteLine($"{mostPopularPartyName} {maxPercent}% {mostPopularYear}");
        }

        internal void AllPartyNames()
        {
            string partyName;
            List<string> partyNames = new List<string>();

            for (int i = 2010; i <= 2022; i++)
            {
                var path = Path.Combine(BASE_PATH, i + ".txt");
                var lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    partyName = line.Trim()[..line.LastIndexOf(" ")];

                    if (!partyNames.Any(x => x.Equals(partyName)))
                        partyNames.Add(partyName);
                }
            }

            foreach (var item in partyNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
