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
        public void RepeatIdsCorrect()
        {
            MockDataGenerator dataGenerator = new MockDataGenerator();
            int IDsNr = 12;
            List<int> IDs = dataGenerator.GenerateIDs(IDsNr);
            int repeatNr = 36;
            List<int> repeatedIds = dataGenerator.RepeatIds(IDs, repeatNr);

            Assert.Equal(12, repeatedIds[(IDsNr * repeatNr)-1]);
        }

        
        [Fact]
        public void GenerateAnswerRatingsCreatesListInts()
        {
            MockDataGenerator dataGenerator = new MockDataGenerator();
            int nr = 100;
            List<int> answerRatings = dataGenerator.GenerateAnswerRatings(nr);

            Assert.Equal(100, answerRatings.Count());   // only works if list is full of ints
        }

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
