using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.DataMock1
{
    public class AnswerDal
    {
        public List<MockAnswerDto1> Answers { get; set; }
        public List<TestObjectDB> TestObjects { get; set; }   
        public string connectionString = "Data Source = rockstars.database.windows.net; Initial Catalog = RockstarsDataBase; Persist Security Info = True; User ID = RockstarAdmin; Password = Rockstars!";

        public List<TestObjectDB> GetAllTestObjectsDB() // for trying out stuff with database without messing everything up
        {
            List<TestObjectDB> testObjects = new List<TestObjectDB>();

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

        public int CreateTable(string name, List<string> columnNames, List<string> dataTypes)   // returning int rowsAffected makes it testable
        {
            string columnNamesAndTypes = "";
            for(int i = 0; i < columnNames.Count; i++)
            {
                columnNamesAndTypes = $"{columnNamesAndTypes} {columnNames[i]} {dataTypes[i]},";
            }

            columnNamesAndTypes = $"({columnNamesAndTypes})";
            
            string tableString = $"create table {name} {columnNamesAndTypes};";

            int rowsAffected;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand makeTable = new SqlCommand(tableString, conn))
                {
                    conn.Open();
                    rowsAffected = makeTable.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        /*public void WriteMockAnswers1ToDB()
        {
            string sqlFillTable = "insert into MockAnswers1 ([ID], [FilledOutQuestionnaireID], [QuestionID], [Question], [QuestionCategory], " +
                                  "[UserID], [UserIDstring], [UserName], [AnswerRange], [AnswerComment], [Date]) " +
                                  "values(@id,@fId,@qId,@q,@qC,@uId,@uIdS,@uN,@aR,@aC,@d)";

            // Create the connection (and be sure to dispose it at the end)
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                MockAnswerDto1 answerDto = new MockAnswerDto1();
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
                try
                {
                    conn.Open();

                    // Prepare the command to be executed on the db
                    using (SqlCommand cmd = new SqlCommand(sqlFillTable, conn))
                    {
                        // Create and set the parameters values 
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = textbox2.text;
                        cmd.Parameters.Add("@fId", SqlDbType.NVarChar).Value = textbox3.text;

                        // Let's ask the db to execute the query
                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                            MessageBox.Show("Row inserted!!" + );
                        else
                            // Well this should never really happen
                            MessageBox.Show("No row inserted");

                    }
                }
                catch (Exception ex)
                {
                    // We should log the error somewhere, 
                    // for this example let's just show a message
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }



        }*/

        public List<MockAnswerDto1> GetAllAnswers()
        {
            List<MockAnswerDto1> Answers = new List<MockAnswerDto1>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from CSVtoTableTestData", conn))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read()) // stays true while reader gives back rows (until end table)
                    {
                        MockAnswerDto1 answerDto = new MockAnswerDto1();
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
