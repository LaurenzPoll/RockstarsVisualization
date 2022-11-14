using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class MockDataGenerator
    {
        public List<int> GenerateIDs(int nr)
        {
            List<int> ids = new List<int>();
            int id;
            for (int i = 1; i < nr+1; i++)
            {
                id = i;
                ids.Add(id);
            }
            return ids;
        }

        public List<string> GenerateIDstrings(List<int> ids)
        {
            List<string> idStrings = new List<string>();
            string idString = "";
            for (int i = 0; i < ids.Count; i++)
            {
                string indexString = i.ToString();
                int nrOfZeros = 6 - indexString.Length;
                for (int j = 0; j < nrOfZeros; j++)
                {
                    idString = $"{idString}0";
                }
                idString = idString+indexString;
                idStrings.Add(idString);
            }
            return idStrings;
        }

        public List<int> RepeatIds(List<int> ids, int nr)
        {
            List<int> repeatedIds = new List<int>();
            for (int i = 0; i < nr; i++)
            {
                foreach (int id in ids)
                {
                    repeatedIds.Add(id);
                }
            }
            return repeatedIds;
        }

        public List<string> GetFirstNames(int nr)
        {
            CSVParser csvParser = new CSVParser();
            List<string> names = csvParser.GetLinesCSV("MockNames.csv");

            List<string> firstNames = new List<string>();
            for (int i = 0; i < nr; i = i + 3)
            {
                firstNames.Add(SelectRandomString(names));
            }
            return firstNames;
        }

        public List<string> GetLastNames(int nr)
        {
            CSVParser csvParser = new CSVParser();
            List<string> names = csvParser.GetLinesCSV("MockNames.csv");

            List<string> lastNames = new List<string>();
            for (int i = 1; i < nr; i = i + 3)
            {
                lastNames.Add(SelectRandomString(names));
            }
            return lastNames;
        }

        public string SelectRandomString(List<string> strings)
        {
            int lengthList = strings.Count;
            Random rd = new Random();
            int index = rd.Next(lengthList);

            string theString = strings[index];
            return theString;
        }

        internal List<string> MakeEmailAddresses(int nr)
        {
            var emailAddresses = new List<string>();
            MockDataGenerator mockDataGenerator = new MockDataGenerator();
            for (int i = 0; i < nr; i++)
            {
                string firstName = mockDataGenerator.SelectRandomString(mockDataGenerator.GetFirstNames(1));   
                string firstLetter = firstName[0].ToString();
                string lastName = mockDataGenerator.SelectRandomString(mockDataGenerator.GetLastNames(1));     
                string emailAddress = $"{firstLetter}.{lastName}@rockstars.com";    // only for rockstars employees for now
                emailAddresses[i] = emailAddress;
            }
            return emailAddresses;
        }


    }
}
