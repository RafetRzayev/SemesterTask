using System;
using System.IO;
using System.Linq;

namespace SemesterTask
{
    public class GeneralMethods
    {
        private const string BASE_PATH = @"..\..\..\..\ExamData_2022\accountNames.txt";

        private readonly int[] _electionYears = { 1992, 1995, 1999, 2003, 2007, 2011, 2015, 2019, 1934, 2005, 2009, 2013, 2017, 2021 };
      
        internal void CreateEmail(string fullName)
        {
            fullName = fullName.Trim().ToLower();

            var nameParts = fullName.Split(' ', '-');
            var emailUserName = "";

            for (int i = 0; i < nameParts.Length - 1; i++)
            {
                emailUserName += (nameParts[i] + ".");
            }

            emailUserName += nameParts.Last();

            var eeEmail = $"{emailUserName}@parlamanet.ee";
            var euEmail = $"{emailUserName}@parlamanet.eu";

            Console.WriteLine($"Created {eeEmail}, {euEmail}");
        }

        public string CreateAccountName(string fullName)
        {
            fullName = fullName.Trim().ToLower();

            var nameParts = fullName.Split(' ', '-');

            var accountName = "";

            for (int i = 0; i < nameParts.Length - 1; i++)
            {
                accountName += nameParts[i][0];
            }

            accountName += nameParts.Last();

            File.AppendAllText(BASE_PATH, accountName + "\n");

            return accountName;
        }

        public bool ElectionWereHeldAt(string yearInString)
        {
            if (int.TryParse(yearInString, out int year))
            {
                if (_electionYears.Contains(year))
                    return true;
                else
                    return false;
            }
            else
            {
                Console.WriteLine($"{yearInString} doesn't in correct format");
            }

            return false;
        }
    }
}
