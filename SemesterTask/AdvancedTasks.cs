using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SemesterTask
{
    public class AdvancedTasks
    {
        private const string BASE_PATH = @"..\..\..\..\ExamData_2022\Statistics";

        public List<string> MostStabileParties()
        {
            /*
             * First, we find the numerical average of the party's support percentage.
             * Then we find the numerical average of how much the
             * percentage of support received by the party differs from the 
             * average in different years. The smaller this number is,
             * the more stable the percentage of support is.
             */
            var result = new List<string>();

            string partyName;
            int supportPercent;
            var supportsOfParty = new Dictionary<string, List<int>>();

            for (int i = 2010; i <= 2022; i++)
            {
                var path = Path.Combine(BASE_PATH, i + ".txt");
                var lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    partyName = line.Trim()[..line.LastIndexOf(" ")];
                    supportPercent = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

                    if (supportsOfParty.TryGetValue(partyName, out List<int> percents))
                    {
                        percents.Add(supportPercent);
                        supportsOfParty[partyName] = percents;
                    }
                    else
                    {                 
                        supportsOfParty.Add(partyName, new List<int> { supportPercent});
                    }
                }
            }

            decimal average;
            decimal commonDifferenceFromAverage = 0.0M;
            var differenceAverageOfAverage = new Dictionary<string, decimal>();

            decimal minDifference = decimal.MaxValue;

            foreach (var keyValue in supportsOfParty)
            {
                //Party must be present in files for at least 3 years
                if (keyValue.Value.Count < 3)
                    continue;

                average = (decimal)keyValue.Value.Average();

                foreach (var percent in keyValue.Value)
                {
                    commonDifferenceFromAverage += Math.Abs(average - percent);
                }

                var averageOfAverage = commonDifferenceFromAverage / keyValue.Value.Count;

                if (minDifference > averageOfAverage)
                    minDifference = averageOfAverage;

                differenceAverageOfAverage.Add(keyValue.Key, averageOfAverage);

                commonDifferenceFromAverage = 0.0M;
            }

            foreach (var item in differenceAverageOfAverage)
            {
                if (item.Value == minDifference)
                {
                    result.Add(item.Key);
                }
            }

            return result;
        }

        public List<string> MostFluctuatingParties()
        {
            /*
             * First, we find the numerical average of the party's support percentage.
             * Then we find the numerical average of how much the
             * percentage of support received by the party differs from the 
             * average in different years. The bigger this number is, 
             * the more the support percentage of the party has changed
             */

            var result = new List<string>();

            string partyName;
            int supportPercent;
            var supportsOfParty = new Dictionary<string, List<int>>();

            for (int i = 2010; i <= 2022; i++)
            {
                var path = Path.Combine(BASE_PATH, i + ".txt");
                var lines = File.ReadAllLines(path);

                foreach (var line in lines)
                {
                    partyName = line.Trim()[..line.LastIndexOf(" ")];
                    supportPercent = int.Parse(line.Trim()[(line.LastIndexOf(" ") + 1)..]);

                    if (supportsOfParty.TryGetValue(partyName, out List<int> percents))
                    {
                        percents.Add(supportPercent);
                        supportsOfParty[partyName] = percents;
                    }
                    else
                    {
                        supportsOfParty.Add(partyName, new List<int> { supportPercent });
                    }
                }
            }

            decimal average;
            decimal commonDifferenceFromAverage = 0.0M;
            var differenceAverageOfAverage = new Dictionary<string, decimal>();

            decimal minDifference = 0.0M;

            foreach (var keyValue in supportsOfParty)
            {
                //Party must be present in files for at least 3 years
                if (keyValue.Value.Count < 3)
                    continue;

                average =(decimal) keyValue.Value.Average();

                foreach (var percent in keyValue.Value)
                {
                    commonDifferenceFromAverage += Math.Abs(average - percent);
                }

                var averageOfAverage = commonDifferenceFromAverage / keyValue.Value.Count;

                if (minDifference < averageOfAverage )
                    minDifference = averageOfAverage;

                differenceAverageOfAverage.Add(keyValue.Key, averageOfAverage);
                commonDifferenceFromAverage = 0.0M;
            }

            foreach (var item in differenceAverageOfAverage)
            {
                if (item.Value == minDifference)
                {
                    result.Add(item.Key);
                }
            }

            return result;
        }

    }
}
