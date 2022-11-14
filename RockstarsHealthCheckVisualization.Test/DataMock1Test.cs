using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockstarsHealthCheckVisualization.DataMock1;

namespace RockstarsHealthCheckVisualization.Test
{
    public class DataMock1Test
    {
        [Fact]
        public void MakeTableWorks()
        {
            string name = "MakingTableWorks";
            List<string> columns = new string[] { "columnA", "columnB", "columnC" }.ToList();
            List<string> types = new string[] { "int", "int", "int"}.ToList();

            TestDalMock1 testDal = new TestDalMock1();
            int returnedRows = testDal.MakeTable(name, columns, types);

            Assert.Equal(5, testObjects.Count);
        }

    }

    /*public class MockAnswersDto1
    {
        [Fact]
        public void ReturnsListObjects()
        {
            List<MockAnswerDto1> answers = new List<MockAnswerDto1>();
            DatabaseManagerTest databaseManager = new DatabaseManagerTest();
            answers = databaseManager.GetAllAnswers();

            Assert.Equal(432, answers.Count);
        }




    }*/
}
