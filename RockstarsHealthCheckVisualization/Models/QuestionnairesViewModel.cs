namespace RockstarsHealthCheckVisualization.Models;

public class _QuestionnairesViewModel
{
    private List<QuestionnaireViewModel> questionnaireList = new List<QuestionnaireViewModel>();

    public QuestionnairesViewModel()
    {

    }

    public void AddToQuestionnaireList(QuestionnaireViewModel questionnaire)
    {
        questionnaireList.Add(questionnaire);
    }

    public List<QuestionnaireViewModel> GetquestionnaireList()
    {
        return questionnaireList;
    }

}
