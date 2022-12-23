
using RockstarsHealthCheckVisualization.Core;

namespace RockstarsHealthCheckVisualization.Models;

public class MailingViewModel
{
    private string ToEmail;
    private string Link;
    private int LinkID;
    private List<Questionnaire> QuestionnaireList = new List<Questionnaire>();
    public List<EmailDTO> Emails;
    public List<string> SelectedEmails;


    public MailingViewModel()
    {
        Emails = new List<EmailDTO>();
        SelectedEmails = new List<string>();

    }

    public MailingViewModel(List<EmailDTO> emailDTOs, List<Questionnaire> questionnaireList)
    {
        Emails = emailDTOs;
        QuestionnaireList.AddRange(questionnaireList);
    }    
    
    public void AddEmailToSelectedEmails(string email)
    {
        SelectedEmails.Add(email);
    }

    public string toEmail{ 
        get { return ToEmail; }
        set { ToEmail = value; } }

    public string link{
        set { Link = value; }}

    public int linkID{
        get { return LinkID; }
        set { LinkID = value; }}

    public void FillSelectQuestionnaireList(List<Questionnaire> list)
    {
        QuestionnaireList.AddRange(list);
    }
    
    public List<Questionnaire> GetList()
    {
        return QuestionnaireList;
    }
}