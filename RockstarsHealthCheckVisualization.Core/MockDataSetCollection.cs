using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class MockDataSetCollection
    {
        private List<MockDataSet1> mockDataSets;

        internal MockDataSetCollection()
        {
            this.mockDataSets = new List<MockDataSet1>();
        }

        internal void AddMockDataSet(MockDataSet1 mockDataSet)
        {
            this.mockDataSets.Add(mockDataSet);
        }




    }
}
