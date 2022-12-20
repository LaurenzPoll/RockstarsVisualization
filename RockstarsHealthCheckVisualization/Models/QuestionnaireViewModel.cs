namespace RockstarsHealthCheckVisualization.Models;

public class QuestionnaireViewModel
{
    private int QuestionnaireID;
    private string QuestionnaireName;

    public QuestionnaireViewModel(int questionnaireID, string questionnaireName)
    {
        this.QuestionnaireID = questionnaireID;
        this.QuestionnaireName = questionnaireName;
    }

    public int GetId(){
        return QuestionnaireID;
    }

    public string GetName(){
        return QuestionnaireName;
    }
}
