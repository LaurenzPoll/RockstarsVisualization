using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.DataMock1
{
    internal class DatabaseManager
    {
        public List<AnswerDto> Answers { get; set; }
        public List<TestObjectDB> TestObjects { get; set; }   
        public string connectionString = "Data Source = rockstars.database.windows.net; Initial Catalog = RockstarsDataBase; Persist Security Info = True; User ID = RockstarAdmin; Password = Rockstars!";

        public List<TestObjectDB> GetAllAnswers()
        {
            List<AnswerDto> Answers = new List<AnswerDto>();
            List<TestObjectDB> TestObjects = new List<TestObjectDB>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from CSVtoTableTestData"))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read()) // stays true while reader gives back rows (until end table)
                    {
                        TestObjectDB testObject = new TestObjectDB();
                        testObject.Id = reader.GetInt32(0);
                        testObject.Name = reader.GetString(1);

                        TestObjects.Add(testObject);
                    }
                }
            }

            return TestObjects;
        }

    }
}
