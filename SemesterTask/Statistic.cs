using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SemesterTask.Models;

namespace SemesterTask
{
    public class Statistic
    {
        private const string BASE_PATH = @"..\..\..\..\ExamData_2022\Statistics";

        public List<SupportDetail> ParliamentSeatsAmongParties(string year)
        {
            /*
             * Since 100 and 101 are very close numbers,
             * we can calculate the percentage of popularity of the parties
             * for the number of chairs.We firmly believe that
             * the remaining 1 chair is reserved for the most popular party
             */
            var path = Path.Combine(BASE_PATH, year + ".txt");
            var lines = File.ReadAllLines(path);
            string partyName;
            int supportPercent;

            var supportDetails = new List<SupportDetail>();
            
            foreach (var line in lines)
            {
                /*
                 * Trim() deletes right and left spaces
                 * Since the part like the last space shows the party name,
                 * we use the Substring() method to take that part.
                 * The line after the last space shows the popularity rate
                 */
                partyName = line.Trim()[..line.LastIndexOf(" ")];
                supportPercent = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

                supportDetails.Add(new SupportDetail
                {
                    PartyName = partyName,
                    SupportPercent = supportPercent
                });
            }

            /*
             * We find the most supported party and increase its support percentage by 1
             */
            var maxSupportPercent = supportDetails.Max(x => x.SupportPercent);
            supportDetails.Find(x => x.SupportPercent == maxSupportPercent).SupportPercent++;

            return supportDetails;
        }

        internal void PossibleCombinationOfParties(string year)
        {
            var path = Path.Combine(BASE_PATH, year + ".txt");
            var lines = File.ReadAllLines(path);
            string partyName;
            int supportPercent;
            var minSeats = 0;

            var supportDetails = new List<SupportDetail>();
            var possibleCombinations = new List<SupportDetail>();

            foreach (var line in lines)
            {
                partyName = line.Trim()[..line.LastIndexOf(" ")];
                supportPercent = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

                supportDetails.Add(new SupportDetail
                {
                    PartyName = partyName,
                    SupportPercent = supportPercent
                });
            }

            supportDetails.Sort((x, y) =>
            {
                return x.SupportPercent.CompareTo(y.SupportPercent);
            });

            supportDetails.Last().SupportPercent++;

            Console.WriteLine($"{"Party name",-25}{"Seats",-5}");

            for (int i = 0; i < supportDetails.Count - 1; i++)
            {
                minSeats = supportDetails[i].SupportPercent;

                if (minSeats == 0) continue;

                possibleCombinations.Clear();
                possibleCombinations.Add(
                       new SupportDetail
                       {
                           PartyName = supportDetails[i].PartyName,
                           SupportPercent = supportDetails[i].SupportPercent
                       });
                Console.WriteLine($"----------------------------------------");
                for (int j = i + 1; j < supportDetails.Count; j++)
                {
                    minSeats += supportDetails[j].SupportPercent;

                    possibleCombinations.Add(
                        new SupportDetail
                        {
                            PartyName = supportDetails[j].PartyName,
                            SupportPercent = supportDetails[j].SupportPercent 
                        });

                    if (minSeats >= 51 && minSeats <= 70)
                    {
                        foreach (var item in possibleCombinations)
                        {
                            Console.WriteLine($"{item.PartyName,-25}{item.SupportPercent,-4}");
                        }
                    }
                }
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
                supportPercent = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

                supportDetails.Add(new SupportDetail
                {
                    PartyName = partyName,
                    SupportPercent = supportPercent
                });
            }

            /*
             * We sort them from size to bottom according to the party's support interest.
             */
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
                supportPercent = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

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

        public double DifferencePopularity(string year1, string year2, string partyName)
        {
            var path = Path.Combine(BASE_PATH, year1 + ".txt");
            var lines = File.ReadAllLines(path);
            string partyNameFromFile;
            int supportPercentYear1 = 0;
            int supportPercentYear2 = 0;

            /*
             * Earlier we found the support interest of the party in year1
             */
            foreach (var line in lines)
            {
                partyNameFromFile = line.Trim()[..line.LastIndexOf(" ")];

                if (partyNameFromFile.Equals(partyName))
                {
                    supportPercentYear1 = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

                    break;
                }
            }

            path = Path.Combine(BASE_PATH, year2 + ".txt");
            lines = File.ReadAllLines(path);

            /*
             * After we found the support interest of the party in year2
             */
            foreach (var line in lines)
            {
                partyNameFromFile = line.Trim()[..line.LastIndexOf(" ")];

                if (partyNameFromFile.Equals(partyName))
                {
                    supportPercentYear2 = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

                    break;
                }
            }

            return supportPercentYear2 - supportPercentYear1;
        }

        internal void PopularityInRange(string year1InString, string year2InString)
        {
            string partyName;
            int supportPercent;
            var year1 = int.Parse(year1InString);
            var year2 = int.Parse(year2InString);
            var supportDetails = new List<SupportDetail>();

            for (int i = Math.Min(year1, year2); i <= Math.Max(year1, year2); i++)
            {
                var path = Path.Combine(BASE_PATH, i + ".txt");
                var lines = File.ReadAllLines(path);

                /*
                 * For each year, we collect the party and
                 * support percentages in one list and find the desired ones                   
                 */
                foreach (var line in lines)
                {
                    partyName = line.Trim()[..line.LastIndexOf(" ")];
                    supportPercent = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

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
            var year1 = int.Parse(year1InString);
            var year2 = int.Parse(year2InString);

            var supportDetails = new List<SupportDetail>();

            var maxPercent = 0;
            var mostPopularPartyName = "";
            var mostPopularYear = Math.Min(year1, year2);

            for (int i = Math.Min(year1, year2); i <= Math.Max(year1, year2); i++)
            {
                var path = Path.Combine(BASE_PATH, i + ".txt");
                var lines = File.ReadAllLines(path);

                /*
                 * We look at party and support percentages
                 * for each year and store the year with
                 * the highest support percentage and other information in variables
                 */
                foreach (var line in lines)
                {
                    partyName = line.Trim()[..line.LastIndexOf(" ")];
                    supportPercent = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

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

        public List<string> AllPartyNames()
        {
            /*
             * We create a list for party names.
             * We add to this list by looking at the party names of all years,
             * and when adding, we check(line 342) that this party is not in the regular list.
             */
            string partyName;
            var partyNames = new List<string>();

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

            return partyNames;
        }
    }
}
