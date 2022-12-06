using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.DataMock1
{
    public class TestDalMock1   // for trying out database stuff without destroying stuff
    {
        public List<MockAnswerDto1> Answers { get; set; }
        public List<TestObjectMock1> TestObjects { get; set; }   
        public string connectionString = "Data Source = rockstars.database.windows.net; Initial Catalog = RockstarsDataBase; Persist Security Info = True; User ID = RockstarAdmin; Password = Rockstars!";

        public List<TestObjectMock1> GetAllTestObjectsDB() 
        {
            List<TestObjectMock1> testObjects = new List<TestObjectMock1>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from CSVtoTableTestData", conn))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read()) // stays true while reader gives back rows (until end table)
                    {
                        TestObjectMock1 testObject = new TestObjectMock1();
                        testObject.Id = reader.GetInt16(0);
                        testObject.Name = reader.GetString(1);

                        testObjects.Add(testObject);
                    }
                }
            }

            return testObjects;
        }

        public int CreateTable(string name, List<string> columnNames, List<string> dataTypes)   // returning int rowsAffected makes it testable
        {
            // first check if table with that name already exists, implement code here! int rows affected needs to be before if/try statement, for test to work


            string columnNamesAndTypes = "";
            for(int i = 0; i < columnNames.Count; i++)
            {
                columnNamesAndTypes = $"{columnNamesAndTypes} {columnNames[i]} {dataTypes[i]},";
            }

            columnNamesAndTypes = $"({columnNamesAndTypes})";
            
            string tableString = $"create table {name} {columnNamesAndTypes};";

            int rowsAffected = 12345;   // for checking if rows affected changes to -1 which is the case when table is made
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
