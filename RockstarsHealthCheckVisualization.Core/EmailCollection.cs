using Mailjet.Client;
using Mailjet.Client.Resources;
using System;
using Newtonsoft.Json.Linq;

namespace RockstarsHealthCheckVisualization.Core;

public class EmailCollection
{
    private readonly IRepository repository;

    public EmailCollection(IRepository _repository)
    {
        repository = _repository;
    }

    public void GetEmails()
    {
        return repository.GetEmails();
    }

    public void FillSelectQuestionnaireList()
    {
        IRepository data = new();
        QuestionnaireList.AddRange(data.GetAllQuestionnaires());
    }

    public List<QuestionnaireViewModel> GetList()
    {
        return QuestionnaireList;
    }

    public async void SendMail()
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
                        "Recipients", JArray.Parse(@"[{'Email': '" + this.ToEmail + "'}]")
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
