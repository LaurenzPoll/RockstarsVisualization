using RockstarsHealthCheckVisualization.Core;
using System.Data.SqlClient;

namespace RockstarsHealthCheckVisualization.DAL;

public class Repository : IRepository
{
    private string connectionString = "Data Source=rockstars.database.windows.net;Initial Catalog=RockstarsDataBase;Persist Security Info=True;User ID=RockstarAdmin;Password=Rockstars!";
    private List<Answer> answers = new List<Answer>();
    private int userID;

    public List<User> GetUserList()
    {
        List<User> users = new List<User>();
        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var command = new SqlCommand("SELECT UserID, Email, Name FROM Users", connection);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            string name;
            if (reader.IsDBNull(2))
            {
                name = "name not available";
            }
            else
            {
                name = reader.GetString(2);
            }

            users.Add(new User
            {
                UserId = reader.GetInt32(0),
                Email = reader.GetString(1),
                Name = name
                
            });
        }

        connection.Close();

        return users;
    }
    public List<Questionnaire> GetAllQuestionnaires()
    {
        Questionnaires questionnaires = new Questionnaires();

        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var command = new SqlCommand("SELECT QuestionnaireID, QuestionnaireName FROM Questionnaires", connection);
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            questionnaires.AddToQuestionnaireList(new Questionnaire(reader.GetInt32(0), reader.GetString(1)));
        }

        connection.Close();

        return questionnaires.GetquestionnaireList();
    }

    public int GetUserIDFromDataBase(string email)
    {
        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var command = new SqlCommand("IF not exists(SELECT * FROM users WHERE Email = '" + email + "')" +
                                     "\nBEGIN" +
                                     "\nINSERT INTO Users(Email) VALUES('" + email + "')" +
                                     "\nEND" +
                                     "\nSELECT * FROM users WHERE Email = '" + email + "'", connection);

        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            userID = reader.GetInt32(0);
        }

        connection.Close();

        return userID;
    }

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
                    Answer answer = new Answer(answerId, questionId, question, filledOutQuestionnaireId, answerRange, answerComment);

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
            using (SqlCommand query = new SqlCommand("SELECT DISTINCT a.AnswerID, a.FilledOutQuestionnaireID, a.QuestionID, q.Question, a.AnswerRange, a.AnswerComment, fq.DateTime, fq.UserID, fq.QuestionnaireID FROM Answers AS a INNER JOIN Questions AS q ON a.QuestionID = q.QuestionID INNER JOIN FilledOutQuestionnaires AS fq ON a.FilledOutQuestionnaireID = fq.FilledOutQuestionnaireID WHERE fq.UserID = @userId", conn))
            {
                conn.Open();
                SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@userId", userID),
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
                    int questionnaireId = reader.GetInt32(8);
                    if (!reader.IsDBNull(5))
                    {
                        answerComment = reader.GetString(5);
                    }
                    Answer answer = new Answer(answerId, questionId, question, filledOutQuestionnaireId, answerRange, answerComment, dateTime, userId, questionnaireId);

                    answers.Add(answer);
                }

            }
        }

        return answers;
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

    public List<EmailDTO> GetEmails()
    {
        List<EmailDTO> emails = new List<EmailDTO>();
        string email;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (var query = new SqlCommand("SELECT Email FROM Users"))
            {
                query.Connection = conn;
                conn.Open();
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    email = reader.GetString(0);

                    emails.Add(new EmailDTO(email));
                }
            }
        }
        return emails;
    }
}
