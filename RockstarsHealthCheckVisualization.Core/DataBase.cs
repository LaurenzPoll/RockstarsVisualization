using System.Data.SqlClient;

namespace RockstarsHealthCheckVisualization.Core;

public class DataBase
{
    private string connectionString = "Data Source=rockstars.database.windows.net;Initial Catalog=RockstarsDataBase;Persist Security Info=True;User ID=RockstarAdmin;Password=Rockstars!";

    public List<int> GetAnswerRangesFromQuestionId(int questionID)
    {
        List<int> answerRanges = new List<int>();
        int answerRange = 0;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand query = new SqlCommand("SELECT AnswerRange FROM Answers WHERE QuestionID = @questionID", conn))
            {
                conn.Open();
                SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@questionId", questionID)
                };
                query.Parameters.AddRange(parameters);
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    answerRange = reader.GetInt32(0);


                    answerRanges.Add(answerRange);
                }

            }
        }

        return answerRanges;
    }
}
