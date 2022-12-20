namespace RockstarsHealthCheckVisualization.Models;

public class URL
{
    public static string GenerateQuestionnaireURL(int questionnaireID)
    {
        return "https://rockstarshealthcheck.azurewebsites.net/Questionaire/Index/" + questionnaireID.ToString();
        //return "https://localhost:7080/Questionaire/index/" + questionnaireID.ToString();
    }
}
