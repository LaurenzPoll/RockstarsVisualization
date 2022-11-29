using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class DTOAnswers
    {
        private string connectionString = "Data Source=rockstars.database.windows.net;Initial Catalog=RockstarsDataBase;Persist Security Info=True;User ID=RockstarAdmin;Password=Rockstars!";
        private List<Answer> answers = new List<Answer>();

        public List<Answer> GetAllAnswers()
        {
            List<Answer> answers = new List<Answer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from MockPlantEdible", conn))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read()) // stays true while reader gives back rows (until end table)
                    {
                        
                        int answerId = reader.GetInt32(0);
                        int filledOutQuestionnaireId = reader.GetInt32(1);
                        int questionId = reader.GetInt32(2);
                        int answerRange = reader.GetInt32(3);
                        string? answerComment = reader.GetString(2);
                        Answer answer = new Answer(answerId, filledOutQuestionnaireId,  answerRange, questionId, answerComment);
                        
                        answers.Add(answer);
                    }
                    
                }
            }

            return answers;
        }





    }
}
