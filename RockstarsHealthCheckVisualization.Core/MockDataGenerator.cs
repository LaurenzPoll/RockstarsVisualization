using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class MockDataGenerator
    {
        private static Random rnd = new Random();

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

        public List<int> RepeatIdsShort(List<int> ids, int nr)
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

        public List<int> RepeatIdsLong(int nrOfIds, int timesOneIdRepeated)
        {
            List<int> repeatedIds = new List<int>();
            for (int i = 1; i < nrOfIds+1; i++)
            {
                for(int j = 0; j < timesOneIdRepeated; j++)
                {
                    repeatedIds.Add(i);
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
            var numbers = new List<int>(Enumerable.Range(0, nr)); // range does not include given end
            var shuffledList = numbers.OrderBy(a => rnd.Next()).ToList();
            
            /* this one was fun to make and should work, but costs way too much computing power. please do not delete for now.
            List<int> randomList = new List<int>();
            int myNumber = -1;
            for (int i = 0; i < nr; i++)
            {
                while (randomList.Contains(myNumber) || myNumber != -1)     // shitloads of computing, how faster?
                {
                    Random a = new Random();
                    myNumber = a.Next(0, nr);
                }
                randomList.Add(myNumber);
            }*/

            return shuffledList;
        }

        /// <summary>
        /// generates 1/3 of the numbers equal to given mode + 2/3 of the numbers randomly,
        /// all at random locations in returned list
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        public List<int> GenerateAnswerRatings(int nr)
        {
            int mode = 4; // 3 would be a bit low, 4 is a bit much
            int nrOfRatingsMode = nr / 3;
            int nrOfRatingsRandom = nr - nrOfRatingsMode;

            int[] answerRatings = new int[nr];
            List<int> randomIndicesList = GetRandomizedListIndices(nr);
            
            // insert mode number at random places list
            for (int i = 0; i < nrOfRatingsMode; i++)
            {
                int index = randomIndicesList[i];
                answerRatings[index] = mode;
            }

            // insert random numbers at left over places list
            for (int i = nrOfRatingsMode; i < nr; i++)
            {
                int index = randomIndicesList[i];
                answerRatings[index] = GetRandomNumber(1, 6);
            }

            List<int> answerRatingsList = answerRatings.Cast<int>().ToList();
            return answerRatingsList;
        }

        

        // NEXT METHODS MORE SPECIFIC FOR MockDatasetAnswers1 (the ones above are usable for all coming mock data)

        public List<string> GetStandardQuestions()
        {
            // Quality
            string q1 = "How do you value your delivered work?";
            string q2 = "Is releasing code going well?";
            string q3 = "How healthy is the code base?";

            // Progress
            string q4 = "Is the current working process suitable?";
            string q5 = "Is the speed sufficient?";
            string q6 = "Is the mission of the project clear?";

            // Team
            string q7 = "Is the teamwork going well?";
            string q8 = "How is the quality of support?";
            string q9 = "How good is the working atmosphere?";

            // Individual
            string q10 = "Are you having fun?";
            string q11 = "Do you experience autonomy in your work?";
            string q12 = "Are you learning enough along the way?";

            List<string> questionsStandard = new List<string>()
            {
                q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12
            };

            return questionsStandard;
        }

        public List<string> GetStringsRepeated(List<string> toRepeat, int times)
        {
            List<string> repeated = new List<string>();
            for (int i = 0; i < times; i++)
            {
                for (int j = 0; j < toRepeat.Count(); j++)
                {
                    repeated.Add(toRepeat[i]);
                }
            }
            return repeated;
        }

        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            categories.Add("Quality");
            categories.Add("Process");
            categories.Add("Team");
            categories.Add("Individual");
            return categories;
        }

      

    }


    
}
