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
                using (SqlCommand query = new SqlCommand("SELECT Answers.AnswerID, Answers.FilledOutQuestionnaireID, Answers.QuestionID, Questions.Question, Answers.AnswerRange, Answers.AnswerComment FROM Answers INNER JOIN Questions ON Answers.QuestionID = Questions.QuestionID", conn))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read()) // stays true while reader gives back rows (until end table)
                    {
                        
                        int answerId = reader.GetInt32(0);
                        int filledOutQuestionnaireId = reader.GetInt32(1);
                        int questionId = reader.GetInt32(2);
                        string question = reader.GetString(3);
                        int answerRange = reader.GetInt32(4);
                        string answerComment = "";
                        if (!reader.IsDBNull(5))
                        {
                            answerComment = reader.GetString(5);
                        }
                        Answer answer = new Answer(answerId, questionId, question, filledOutQuestionnaireId,  answerRange, answerComment);
                        
                        answers.Add(answer);
                    }
                    
                }
            }

            return answers;
        }





    }
}
