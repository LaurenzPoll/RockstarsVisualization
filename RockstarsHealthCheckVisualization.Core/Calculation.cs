using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{

    public class Calculation
    {
        private string connectionString = "Data Source=rockstars.database.windows.net;Initial Catalog=RockstarsDataBase;Persist Security Info=True;User ID=RockstarAdmin;Password=Rockstars!";


        public Dictionary<int, double> GetAverageAnswerRange(Dictionary<int, List<int>> answers)
        {
            Dictionary<int, double> averageList = new();
            foreach(KeyValuePair<int, List<int>> dictionaryEntry in answers)
            {
                averageList.Add(dictionaryEntry.Key, Queryable.Average(dictionaryEntry.Value.AsQueryable()));
            }

            return (averageList);


            /*
            int nrOfQuestions = 12;
            List<int> answerRanges = new List<int>()
            for (int i = 0; i < ints.Count/nrOfQuestions; i+nrOfQuestions)
            {
                for(int j = 0; j < nrOfQuestions; j++)
                {
                    
                }
            }
            */
        }

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
}



