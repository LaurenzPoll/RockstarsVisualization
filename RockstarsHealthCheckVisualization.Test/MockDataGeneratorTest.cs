using RockstarsHealthCheckVisualization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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


    }
}
