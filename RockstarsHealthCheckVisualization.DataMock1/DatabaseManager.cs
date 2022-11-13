using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.DataMock1
{
    internal class DatabaseManager
    {
        public List<AnswerDto> Answers { get; set; }

        public List<AnswerDto> GetAllAnswers()
        {
            string connectionString = "";
        }

    }
}
