﻿using System.Collections.Generic;
using System.Data.SqlClient;
namespace RockstarsHealthCheckVisualization.Models;

public class _DatabaseModel
{
    private string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False; Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


    public List<QuestionnaireViewModel> GetAllQuestionnaires()
    {
        QuestionnairesViewModel questionnaires = new QuestionnairesViewModel();

        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var command = new SqlCommand("SELECT QuestionnaireID, QuestionnaireName FROM Questionnaires", connection);
        var reader = command.ExecuteReader();

        while(reader.Read())
        {
            questionnaires.AddToQuestionnaireList(new QuestionnaireViewModel(reader.GetInt32(0), reader.GetString(1)));
        }

        connection.Close();

        return questionnaires.GetquestionnaireList();
    }
    private int userID;

    public int GetUserIDFromDataBase(string email)
    {
        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var command = new SqlCommand("IF not exists(SELECT * FROM users WHERE Email = '" + email + "')" +
                                     "\nBEGIN" +
                                     "\nINSERT INTO Users(Email) VALUES('" + email + "')"+
                                     "\nEND" +
                                     "\nSELECT * FROM users WHERE Email = '" + email + "'", connection);

        var reader = command.ExecuteReader();

        if(reader.Read())
        {
            userID = reader.GetInt32(0);
        }

        connection.Close();

        return userID;
    }


}
