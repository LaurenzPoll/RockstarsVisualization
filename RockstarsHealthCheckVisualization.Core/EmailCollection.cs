﻿using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;

namespace RockstarsHealthCheckVisualization.Core;

public class EmailCollection
{
    private string ToEmail;
    private string Link;
    private int LinkID;
    private readonly IRepository repository;
    private List<Questionnaire> QuestionnaireList = new List<Questionnaire>();

    public List<Questionnaire> questionnairesList { get { return QuestionnaireList; } }
    public string toEmail
    {
        get { return ToEmail; }
        set { ToEmail = value; }
    }

    public string link
    {
        set { Link = value; }
    }

    public int linkID
    {
        get { return LinkID; }
        set { LinkID = value; }
    }

    public EmailCollection(IRepository _repository)
    {
        repository = _repository;
        Link = "";
    }

    public EmailCollection(IRepository _repository, string link)
    {
        repository = _repository;
        Link = link;
    }

    public void SendMultipleEmails(List<string> emails)
    {
        foreach(var email in emails)
        {
            SendMail(email);
        }
    }

    public List<EmailDTO> GetEmails()
    {
        return repository.GetEmails();
    }

    public void FillSelectQuestionnaireList()
    {
        QuestionnaireList.AddRange(repository.GetAllQuestionnaires());
    }

    public List<Questionnaire> GetList()
    {
        return QuestionnaireList;
    }

    public async void SendMail(string toEmail)
    {
        MailjetClient client = new MailjetClient("f61e465b778f2c147258769edf6d84f4", "1f78e321e4a2492382bc1f43129cab42")
        {


        };
        MailjetRequest request = new MailjetRequest
        {
            Resource = Send.Resource,
        }
        .Property(Send.Messages, new JArray {
        new JObject {
                    {
                        "FromEmail", "fontysrockstars@gmail.com"
                    },
                    {
                        "FromName", "Rockstar"
                    },
                    {
                        "Recipients", JArray.Parse(@"[{'Email': '" + toEmail + "'}]")
                    },
                    {
                        "Subject", "Rockstars Health Check"
                    },
                    {
                        "Text-part", "Rockstars Health Check"
                    },
                    {
                        "Html-part",
                        "<h3>Hello Rockstar!,</h3> <br/>" +
                        "We would like to know how you are doing <br/>" +
                        "Please let us know by filling in our questionnaire<br/>" +
                        "<a href='" + this.Link + "'>Rockstar Health Check</a>!<br/>" +
                        "Thank you!"
                    }
                        }});

        Console.WriteLine(request.Body);
        MailjetResponse response = await client.PostAsync(request);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
            Console.WriteLine(response.GetData());
        }
        else
        {
            Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
            Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
            Console.WriteLine(response.GetData());
            Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
        }
    }

}
