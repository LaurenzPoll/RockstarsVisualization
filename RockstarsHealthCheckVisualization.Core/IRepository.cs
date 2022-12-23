namespace RockstarsHealthCheckVisualization.Core;

public interface IRepository
{
    public List<Questionnaire> GetAllQuestionnaires();

    public int GetUserIDFromDataBase(string email);

    public List<Answer> GetAllAnswers();

    public List<Answer> GetAllAnswersFromUser(int userID, DateTime date);

    public List<int> GetAnswerRangesFromQuestionId(int questionID);

    public List<EmailDTO> GetEmails();
}
