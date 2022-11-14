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
        public void IDsListNr()
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
            Assert.Equal(nr, IDs.Count());
        }

        [Fact]
        public void IDstrings()
        {
            MockDataGenerator dataGenerator = new MockDataGenerator();
            int nr = 12;

            dataGenerator.GenerateIDstrings()
            
        }



    }
}
