namespace RockstarsHealthCheckVisualization.Core;

internal class Question
{
    private int questionID;
    private Enum.QuestionCategory category;
    private string question;
    internal Enum.QuestionType type;

    public Question(int questionId, string question, Enum.QuestionCategory category, Enum.QuestionType type)
    {
        questionID = questionId;
        this.question = question;
        this.category = category;
        this.type = type;
    }
}
