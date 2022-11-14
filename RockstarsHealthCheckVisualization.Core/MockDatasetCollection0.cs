using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class MockDatasetCollection0
    {
        private List<MockDataSet0> mockDataSets;

        internal MockDatasetCollection0()
        {
            this.mockDataSets = new List<MockDataSet0>();
        }

        internal void AddMockDataSet(MockDataSet0 mockDataSet)
        {
            this.mockDataSets.Add(mockDataSet);
        }




    }
}
