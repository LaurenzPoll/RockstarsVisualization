
using RockstarsHealthCheckVisualization.DataMock1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RockstarsHealthCheckVisualization.Test
{
    
    public class TestDalMock1Test
    {
        [Fact]
        public void ReturnsListObjects()
        {
            List<TestObjectMock1> testObjects = new List<TestObjectMock1>();
            TestDalMock1 testDal = new TestDalMock1();
            testObjects = testDal.GetAllTestObjectsDB();

            Assert.Equal(5, testObjects.Count);
        }




    }
}
