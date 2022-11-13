using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.DataMock1
{
    public class DatabaseManager
    {
        public List<AnswerDto> Answers { get; set; }
        public List<TestObjectDB> TestObjects { get; set; }   
        public string connectionString = "Data Source = rockstars.database.windows.net; Initial Catalog = RockstarsDataBase; Persist Security Info = True; User ID = RockstarAdmin; Password = Rockstars!";

        public List<TestObjectDB> GetAllTestObjectsDB() // for trying out stuff with database without messing everything up
        {
            List<TestObjectDB> TestObjects = new List<TestObjectDB>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from CSVtoTableTestData", conn))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read()) // stays true while reader gives back rows (until end table)
                    {
                        TestObjectDB testObject = new TestObjectDB();
                        testObject.Id = reader.GetInt16(0);
                        testObject.Name = reader.GetString(1);

                        TestObjects.Add(testObject);
                    }
                }
            }

            return TestObjects;
        }

        public List<AnswerDto> GetAllAnswers()
        {
            List<AnswerDto> Answers = new List<AnswerDto>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from CSVtoTableTestData", conn))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read()) // stays true while reader gives back rows (until end table)
                    {
                        AnswerDto answerDto = new AnswerDto();
                        int ID = reader.GetInt32(0);
                        int FilledOutQuestionnaireID = reader.GetInt32(1);
                        int QuestionID = reader.GetInt32(2);
                        string Question = reader.GetString(3);
                        string QuestionCategory = reader.GetString(4);
                        int UserID = reader.GetInt32(5);
                        string UserIDstring = reader.GetString(6);
                        string UserName = reader.GetString(7);
                        int AnswerRange = reader.GetInt32(8);
                        string? AnswerComment = reader.GetString(9);
                        DateTime Date = reader.GetDateTime(10);

                        Answers.Add(answerDto);
                    }
                }
            }

            return Answers;
        }


    }
}
