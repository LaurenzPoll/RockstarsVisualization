namespace RockstarsHealthCheckVisualization.Core;

public class Questionnaire
{
    private int QuestionnaireID;
    private string QuestionnaireName;

    public Questionnaire(int questionnaireID, string questionnaireName)
    {
        this.QuestionnaireID = questionnaireID;
        this.QuestionnaireName = questionnaireName;
    }

    public Questionnaire()
    {

    }

    public int GetId()
    {
        return QuestionnaireID;
    }

    public string GetName()
    {
        return QuestionnaireName;
    }
}
