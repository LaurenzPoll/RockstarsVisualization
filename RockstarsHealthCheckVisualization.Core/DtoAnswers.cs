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
                using (SqlCommand query = new SqlCommand("SELECT a.AnswerID, a.FilledOutQuestionnaireID, a.QuestionID, q.Question, a.AnswerRange, a.AnswerComment FROM Answers AS a INNER JOIN Questions AS q ON a.QuestionID = q.QuestionID", conn))
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

        public List<Answer> GetAllAnswersFromUser(int userID)
        {
            List<Answer> answers = new List<Answer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("SELECT DISTINCT a.AnswerID, a.FilledOutQuestionnaireID, a.QuestionID, q.Question, a.AnswerRange, a.AnswerComment, fq.DateTime, fq.UserID FROM Answers AS a INNER JOIN Questions AS q ON a.QuestionID = q.QuestionID INNER JOIN FilledOutQuestionnaires AS fq ON a.FilledOutQuestionnaireID = fq.FilledOutQuestionnaireID WHERE fq.UserID = @userId", conn))
                {
                    conn.Open();
                    SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@userId", userID)
                };
                    query.Parameters.AddRange(parameters);
                    var reader = query.ExecuteReader();
                    while (reader.Read()) // stays true while reader gives back rows (until end table)
                    {

                        int answerId = reader.GetInt32(0);
                        int filledOutQuestionnaireId = reader.GetInt32(1);
                        int questionId = reader.GetInt32(2);
                        string question = reader.GetString(3);
                        int answerRange = reader.GetInt32(4);
                        string answerComment = "";
                        DateTime dateTime = reader.GetDateTime(6);
                        int userId = reader.GetInt32(7);
                        if (!reader.IsDBNull(5))
                        {
                            answerComment = reader.GetString(5);
                        }
                        Answer answer = new Answer(answerId, questionId, question, filledOutQuestionnaireId, answerRange, answerComment, dateTime, userId);

                        answers.Add(answer);
                    }

                }
            }

            return answers;
        }



    }
}
