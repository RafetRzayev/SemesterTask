using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SemesterTask
{
    internal class ParliamentElectionAnalysis
    {
        private const string PATH = @"..\..\..\RegionResults_2019.txt";
        private readonly string[] _lines;

        private readonly List<DistrictDetail> _districtDetails;

        public ParliamentElectionAnalysis()
        {
            _lines = File.ReadAllLines(PATH);

            _districtDetails = new List<DistrictDetail>()
            {
                new DistrictDetail{ DistrictNumber = 1,MandatorCount = 10,DistrictName = "Tallinna Haabersti, Põhja-Tallinna ja Kristiine linnaosa" },
                new DistrictDetail{ DistrictNumber = 2,MandatorCount = 13,DistrictName = "Tallinna Kesklinna, Lasnamäe ja Pirita linnaosa" },
                new DistrictDetail{ DistrictNumber = 3,MandatorCount = 8,DistrictName = "Tallinna Mustamäe ja Nõmme linnaosa" },
                new DistrictDetail{ DistrictNumber = 4,MandatorCount = 15,DistrictName = "Harju- ja Raplamaa" },
                new DistrictDetail{ DistrictNumber = 5,MandatorCount = 6,DistrictName = "Hiiu-, Lääne- ja Saaremaa" },
                new DistrictDetail{ DistrictNumber = 6,MandatorCount = 5,DistrictName = "Lääne-Virumaa" },
                new DistrictDetail{ DistrictNumber = 7,MandatorCount = 7,DistrictName = "Ida-Virumaa" },
                new DistrictDetail{ DistrictNumber = 8,MandatorCount = 7,DistrictName = "Järva- ja Viljandimaa" },
                new DistrictDetail{ DistrictNumber = 9,MandatorCount = 7,DistrictName = "Jõgeva- ja Tartumaa" },
                new DistrictDetail{ DistrictNumber = 10,MandatorCount = 8,DistrictName = "Tartu linn" },
                new DistrictDetail{ DistrictNumber = 11,MandatorCount = 8,DistrictName = "Võru-, Valga- ja Põlvamaa" },
                new DistrictDetail{ DistrictNumber = 12,MandatorCount = 7,DistrictName = "Pärnumaa" },
            };
        }

        internal int ElectoralTresholdValue()
        {
            int totalVotes = 0;
            string[] votes;

            foreach (var line in _lines)
            {
                /*
                Trim() deletes right and left spaces
                */
                votes = line.Trim()[(line.IndexOf(" ") + 1)..].Split(" ");

                foreach (var voteInString in votes)
                {
                    if (int.TryParse(voteInString, out int vote))
                    {
                        totalVotes += vote;
                    }
                }
            }

            var tresholdValue = totalVotes * 0.05;

            return (int)tresholdValue;
        }

        internal void PartiesExceedTresholdValue()
        {
            var tresholdValue = ElectoralTresholdValue();
            string partyName;
            string[] votes;
            int totalVotes = 0;

            Console.WriteLine($"{"Party name",-35}{"Votes",-4}");

            foreach (var line in _lines)
            {
                partyName = line.Trim()[..line.IndexOf(" ")].Replace("_", " ");
                votes = line.Trim()[(line.IndexOf(" ") + 1)..].Split(" ");

                foreach (var voteInString in votes)
                {
                    if (int.TryParse(voteInString, out int vote))
                    {
                        totalVotes += vote;
                    }
                }

                if (totalVotes >= tresholdValue)
                {
                    Console.WriteLine($"{partyName,-35}{totalVotes,-4}");
                }
                totalVotes = 0;
            }
        }

        internal double QuotaForElectoralDistrict(int districtNumber)
        {
            int totalVotes = 0;
            string[] votes;
            int mandatorCount = _districtDetails.Find(x => x.DistrictNumber == districtNumber).MandatorCount;

            foreach (var line in _lines)
            {
                /*
                Trim() deletes right and left spaces
                */
                votes = line.Trim()[(line.IndexOf(" ") + 1)..].Split(" ");

                if (int.TryParse(votes[districtNumber - 1], out int vote))
                {
                    totalVotes += vote;
                }
            }

            var simpleQuota = (double)totalVotes / mandatorCount;

            return simpleQuota;
        }

        internal void DistrictMandators(int districtNumber)
        {
            var simpleQuota = QuotaForElectoralDistrict(districtNumber);
            string partyName;
            string[] votes;
            double exceedQuota;

            foreach (var line in _lines)
            {
                /*
                Trim() deletes right and left spaces
                */
                partyName = line.Trim()[..line.IndexOf(" ")].Replace("_", " ");
                votes = line.Trim()[(line.IndexOf(" ") + 1)..].Split(" ");

                if (int.TryParse(votes[districtNumber - 1], out int vote))
                {
                    exceedQuota = Math.Round(vote / simpleQuota + 0.001);

                    Console.WriteLine($"{partyName} => {exceedQuota}");
                }
            }
        }

        internal void Print(int districtNumber)
        {
            var simpleQuota = QuotaForElectoralDistrict(districtNumber);
            string partyName;
            string[] votes;
            double exceedQuota;

            Console.WriteLine($"Simple quota for {_districtDetails.Find(x => x.DistrictNumber == districtNumber).DistrictName} is {simpleQuota}");
            Console.WriteLine($"{"Party name",-35}{"Places",-4}");
            foreach (var line in _lines)
            {
                /*
                Trim() deletes right and left spaces
                */
                partyName = line.Trim()[..line.IndexOf(" ")].Replace("_", " ");
                votes = line.Trim()[(line.IndexOf(" ") + 1)..].Split(" ");

                if (int.TryParse(votes[districtNumber - 1], out int vote))
                {
                    exceedQuota = Math.Round(vote / simpleQuota + 0.001);

                    Console.WriteLine($"{partyName,-35}{exceedQuota}");
                }
            }
        }
    }
}
