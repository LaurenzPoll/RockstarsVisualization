namespace RockstarsHealthCheckVisualization.Core;

public interface IRepository
{
    public User GetUserByUserID(int userID);

    public List<User> GetUserList();
    public List<Questionnaire> GetAllQuestionnaires();

    public int GetUserIDFromDataBase(string email);

    public List<Answer> GetAllAnswers();

    public List<Answer> GetAllAnswersFromUser(int userID);

    public List<int> GetAnswerRangesFromQuestionId(int questionID);

    public List<EmailDTO> GetEmails();
}
