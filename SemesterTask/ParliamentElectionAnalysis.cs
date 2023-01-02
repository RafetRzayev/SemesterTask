using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SemesterTask.Models;

namespace SemesterTask
{
    public class ParliamentElectionAnalysis
    {
        private const string PATH = @"..\..\..\..\ExamData_2022\RegionResults_2019.txt";
        private readonly string[] _lines;

        private readonly List<DistrictDetail> _districtDetails;
        private readonly List<PartyDistrictVote> _partyDistrictVotes;

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

            _partyDistrictVotes = new List<PartyDistrictVote>();

            /*
             * We save the data in the RegionResults_2019.txt file to a list
             */
            for (int i = 1; i < _lines.Length; i++)
            {
                var partyDistrictVote = _lines[i].Split(",");

                _partyDistrictVotes.Add(new PartyDistrictVote
                {
                    DistrictNumber = int.Parse(partyDistrictVote[0]),
                    PartyName = partyDistrictVote[1],
                    VoteCount = int.Parse(partyDistrictVote[2])
                });
            }
        }

        public int ElectoralTresholdValue()
        {
            /*
             * We collect all votes and find 5 percent
             */
            var totalVotes = _partyDistrictVotes.Sum(x => x.VoteCount);

            var tresholdValue = totalVotes * 0.05;

            return (int)tresholdValue;
        }

        public void PartiesExceedTresholdValue()
        {
            var tresholdValue = ElectoralTresholdValue();
            int totalVotes;
            var partyDistrictVoteIndexs = new List<int>();

            Console.WriteLine($"{"Party name",-35}{"Votes",-4}");

            for (int i = 0; i < _partyDistrictVotes.Count; i++)
            {
                if (IsCountedThisPartyCount(partyDistrictVoteIndexs, i))
                    continue;

                totalVotes = _partyDistrictVotes[i].VoteCount;

                for (int j = i + 1; j < _partyDistrictVotes.Count; j++)
                {
                    if (_partyDistrictVotes[i].PartyName.Equals(_partyDistrictVotes[j].PartyName))
                    {
                        totalVotes += _partyDistrictVotes[j].VoteCount;

                        partyDistrictVoteIndexs.Add(j);
                    }
                }

                /*
                 * We collect the votes of a party and find out whether it passed 5 percent or not
                 */
                if (totalVotes >= tresholdValue)
                {
                    Console.WriteLine($"{_partyDistrictVotes[i].PartyName,-35}{totalVotes,-4}");
                }
            }    
            
            bool IsCountedThisPartyCount(List<int> partyDistrictVoteIndexs, int partyDistrictVoteIndex)
            {
                if (partyDistrictVoteIndexs.Contains(partyDistrictVoteIndex))
                    return true;

                return false;
            }
        }

        public double QuotaForElectoralDistrict(int districtNumber)
        {
            var mandatorCount = _districtDetails.Find(x => x.DistrictNumber == districtNumber).MandatorCount;

            var totalVotes = _partyDistrictVotes.Where(x => x.DistrictNumber == districtNumber).Sum(x => x.VoteCount);

            var simpleQuota = (double)totalVotes / mandatorCount;

            return simpleQuota;
        }

        public void DistrictMandators(int districtNumber)
        {
            var simpleQuota = QuotaForElectoralDistrict(districtNumber);
            double exceedQuota;

            var partyVoteCountByDistrict = _partyDistrictVotes.Where(x => x.DistrictNumber == districtNumber);

            foreach (var item in partyVoteCountByDistrict)
            {
                exceedQuota = Math.Round(item.VoteCount / simpleQuota - 0.001);

                Console.WriteLine($"{item.PartyName} => {exceedQuota}");
            }
        }

        public void Print(int districtNumber)
        {
            var simpleQuota = QuotaForElectoralDistrict(districtNumber);
            double exceedQuota;

            Console.WriteLine($"Simple quota for {_districtDetails.Find(x => x.DistrictNumber == districtNumber).DistrictName} is {simpleQuota}");
            Console.WriteLine($"{"Party name",-35}{"Places",-4}");

            var partyVoteCountByDistrict = _partyDistrictVotes.Where(x => x.DistrictNumber == districtNumber);

            foreach (var item in partyVoteCountByDistrict)
            {
                exceedQuota = Math.Round(item.VoteCount / simpleQuota - 0.001);

                Console.WriteLine($"{item.PartyName, -35}{exceedQuota,-4}");
            }
        }
    }
}
