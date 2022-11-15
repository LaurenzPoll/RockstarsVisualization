using RockstarsHealthCheckVisualization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace RockstarsHealthCheckVisualization.Test
{
    public class MockDataGeneratorTest
    {
        public MockDataGenerator generator = new MockDataGenerator();

        [Fact]
        public void IDsListCount()
        {
            MockDataGenerator dataGenerator = new MockDataGenerator();
            int nr = 12;

            List<int> IDs = dataGenerator.GenerateIDs(nr);
            Assert.Equal(nr, IDs.Count());
        }

        [Fact]
        public void IDsCorrect()
        {
            MockDataGenerator dataGenerator = new MockDataGenerator();
            int nr = 12;

            List<int> IDs = dataGenerator.GenerateIDs(nr);
            Assert.Equal(12, IDs[11]);
        }

        [Fact]
        public void IDstrings()
        {
            MockDataGenerator dataGenerator = new MockDataGenerator();
            int nr = 12;
            List<int> IDs = dataGenerator.GenerateIDs(nr);

            List<string> IDstrings = dataGenerator.GenerateIDstrings(IDs);
        }

        [Fact]
        public void GetRepeatedIdsShortTest()   // (3, 2) should result in 1,2,3,1,2,3
        {
            List<int> IDs = new List<int>();
            IDs = generator.GetRepeatedIdsShort(3, 2);
            int[] IDsArray = IDs.ToArray();
            int[] ExpectedIDsArray = { 1, 2, 3, 1, 2, 3 };
            Assert.Equal(ExpectedIDsArray, IDsArray);
        }

        [Fact]
        public void GetRepeatedIdsLongTest()   // (3, 2) should result in 1,1,2,2,3,3
        {
            List<int> IDs = new List<int>();
            IDs = generator.GetRepeatedIdsLong(3, 2);
            int[] IDsArray = IDs.ToArray();
            int[] ExpectedIDsArray = { 1, 1, 2, 2, 3, 3 };
            Assert.Equal(ExpectedIDsArray, IDsArray);
        }

        
        [Fact]
        public void GetRepeatedIdsCustomTest()   // (3, (1,2,2) ) should result in 1,1,1, 2,2,2, 2,2,2, 3,3,3, 3,3,3
        {
            List<int> IDs = new List<int>();
            int[] timesBaseRepeatedArray = { 1, 2, 2 };
            List<int> timesBaseRepeated = timesBaseRepeatedArray.ToList();
            IDs = generator.GetRepeatedIdsCustom(3, timesBaseRepeated);
            int[] IDsArray = IDs.ToArray();
            int[] ExpectedIDsArray = { 1, 1, 1, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3 };
            Assert.Equal(ExpectedIDsArray, IDsArray);
        }


        [Fact]
        public void GetRandomizedListIndicesReturnsList()
        {
            MockDataGenerator dataGenerator = new MockDataGenerator();
            int nr = 100;
            List<int> randomIndices = dataGenerator.GetRandomizedListIndices(nr);

            Assert.Equal(100, randomIndices.Count());

        }
        
        [Fact]
        public void GenerateAnswerRatingsCreatesListInts()
        {
            MockDataGenerator dataGenerator = new MockDataGenerator();
            int nr = 100;
            List<int> answerRatings = dataGenerator.GenerateAnswerRatings(nr);

            Assert.Equal(100, answerRatings.Count());   // only works if list is full of ints
        }

        [Fact]
        public void GenerateAnswerRatingsWithinRange()
        {
            MockDataGenerator dataGenerator = new MockDataGenerator();
            int nr = 100;
            List<int> answerRatings = dataGenerator.GenerateAnswerRatings(nr);

            List<bool> allInRange = new List<bool>();
            foreach (int x in answerRatings)
            {
                if (x >= 1 && x <= 5)
                {
                    allInRange.Add(true);
                }
                else
                {
                    allInRange.Add(false);
                }
            }
            
            Assert.DoesNotContain(false, allInRange);
        }

        
    }
}
