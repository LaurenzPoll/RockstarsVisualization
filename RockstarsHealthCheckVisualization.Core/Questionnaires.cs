namespace RockstarsHealthCheckVisualization.Core;

public class Questionnaires
{
    private List<Questionnaire> questionnaireList = new List<Questionnaire>();

    public Questionnaires()
    {

    }

    public void AddToQuestionnaireList(Questionnaire questionnaire)
    {
        questionnaireList.Add(questionnaire);
    }

    public List<Questionnaire> GetquestionnaireList()
    {
        return questionnaireList;
    }
}
