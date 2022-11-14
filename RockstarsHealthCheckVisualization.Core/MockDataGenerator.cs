using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class MockDataGenerator
    {
        /// <summary>
        /// iterating list of id's as ints (without starting zeros)
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
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

        /// <summary>
        /// iterating list of id's as strings (with starting zeros)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
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

        public int GetRandomNumber(int startRange, int endRangeNotIncluding)
        {
            Random a = new Random();
            int myNumber = 0;
            myNumber = a.Next(startRange, endRangeNotIncluding);
            return myNumber;
        }


        /// <summary>
        /// returns list of ints where every int is an index of the list, in a randomized order. given parameter is length list
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        public List<int> GetRandomizedListIndices(int nr)
        {
            Random a = new Random();
            List<int> randomList = new List<int>();
            int myNumber = 0;
            myNumber = a.Next(0, nr);   // range does not include given end
            for (int i = 0; i < nr; i++)
            {
                if (!randomList.Contains(myNumber))
                {
                    randomList.Add(myNumber);
                }
            }

            return randomList;
        }

        /// <summary>
        /// generates 1/3 of the numbers equal to given mode + 2/3 of the numbers randomly,
        /// all at random locations in returned list
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        public List<int> GenerateAnswerRatings(int nr)
        {
            int mode = 3; // maybe bit low, but 4 is too much
            int nrOfRatingsMode = nr / mode;
            int nrOfRandom = nr - nrOfRatingsMode;

            List<int> answerRatings = new List<int>();
            List<int> randomIndicesList = GetRandomizedListIndices(nr);
            
            // insert mode number at random places list
            for (int i = 0; i < nrOfRatingsMode; i++)
            {
                answerRatings[randomIndicesList[i]] = 3;
            }

            // insert random numbers at open places list
            for (int i = nrOfRatingsMode; i < nr; i++)
            {
                answerRatings[randomIndicesList[i]] = GetRandomNumber(1, 6);
            }

            return answerRatings;
        }

    }


    
}
