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
        public string connectionString = "Data Source = rockstars.database.windows.net; Initial Catalog = RockstarsDataBase; Persist Security Info = True; User ID = RockstarAdmin; Password = Rockstars!";

        public List<AnswerDto> GetAllAnswers()
        {
            
        }

    }
}
