
using RockstarsHealthCheckVisualization.DataMock1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RockstarsHealthCheckVisualization.Test
{
    
    public class MockAnswersDto1
    {
        [Fact]
        public void ReturnsListObjects()
        {
            List<AnswerDto> answers = new List<AnswerDto>();
            DatabaseManager databaseManager = new DatabaseManager();
            answers = databaseManager.GetAllAnswers();

            Assert.Equal(432, answers.Count);
        }




    }
}
