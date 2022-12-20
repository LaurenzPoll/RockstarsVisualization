//using RockstarsHealthCheckVisualization.Core.GarbageBin;

namespace RockstarsHealthCheckVisualization.Core;

public interface IRepository
{
    //private List<Answer> answers = new List<Answer>();

    public List<Questionnaire> GetAllQuestionnaires();

    //private int userID;

    //public List<Question> GetQuestionsFromQuestionnaire(int questionnaireId);

    public int GetUserIDFromDataBase(string email);

    public List<Answer> GetAllAnswers();

    public List<Answer> GetAllAnswersFromUser(int userID, DateTime date);

    public List<int> GetAnswerRangesFromQuestionId(int questionID);

    public List<EmailDTO> GetEmails();
}
