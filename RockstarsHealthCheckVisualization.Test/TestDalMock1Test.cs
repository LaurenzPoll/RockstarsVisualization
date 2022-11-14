
using RockstarsHealthCheckVisualization.DataMock1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RockstarsHealthCheckVisualization.Test
{
    
    public class TestDalMock1Test   // to try out database stuff without destroying stuff
    {
        [Fact]
        public void ReturnsListObjects()
        {
            List<TestObjectMock1> testObjects = new List<TestObjectMock1>();
            TestDalMock1 testDal = new TestDalMock1();
            testObjects = testDal.GetAllTestObjectsDB();

            Assert.Equal(5, testObjects.Count);
        }

        // !!! this test passes, but only works if table with that name does not already exist
        /*[Fact]
        public void MakeTableWorks()    
        {
            string name = "MakingTableWorks";
            List<string> columns = new string[] { "columnA", "columnB", "columnC" }.ToList();
            List<string> types = new string[] { "int", "int", "int" }.ToList();

            TestDalMock1 testDal = new TestDalMock1();
            int returnedRows = testDal.CreateTable(name, columns, types);

            Assert.Equal(-1, returnedRows); // -1 is default return value if rows being affected is not applicable (which is the case)
        }*/




    }
}
