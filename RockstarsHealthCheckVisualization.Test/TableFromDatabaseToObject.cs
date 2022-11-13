
using RockstarsHealthCheckVisualization.DataMock1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RockstarsHealthCheckVisualization.Test
{
    
    public class TableFromDatabaseToObject
    {
        [Fact]
        public void ReturnsListObjects()
        {
            List<TestObjectDB> testObjects = new List<TestObjectDB>();
            DatabaseManager databaseManager = new DatabaseManager();
            testObjects = databaseManager.GetAllTestObjectsDB();

            Assert.Equal(5, testObjects.Count);
        }




    }
}
