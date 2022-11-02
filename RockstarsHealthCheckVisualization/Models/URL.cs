﻿//using Newtonsoft.Json.Serialization;

namespace RockstarsHealthCheckVisualization.Models;


public class URL
{
    //int questionnaireID = 1;

    public static string GenerateQuestionnaireURL(int questionnaireID)
    {
        return "https://rockstarshealthcheck.azurewebsites.net/Questionaire/index/" + questionnaireID.ToString();
        //return "https://localhost:7080/Questionaire/index/" + questionnaireID.ToString();

    }
}
