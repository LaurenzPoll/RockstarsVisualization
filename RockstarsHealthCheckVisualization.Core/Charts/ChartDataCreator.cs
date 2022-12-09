namespace RockstarsHealthCheckVisualization.Core.Charts;
public class ChartDataCreator
{
    private DTOAnswers dtoAnswers;
    private List<DataPoint> dataPoints;
    private List<int> answerRanges;
    private List<int> questionIds;
    Dictionary<int, List<int>> answerDictionary;
    private readonly Calculation calculation;


    private List<Answer> answers;

    public ChartDataCreator()
    {
        dtoAnswers = new DTOAnswers();
        dataPoints = new List<DataPoint>();
        answerRanges = new List<int>();
        questionIds = new List<int>();
        answerDictionary = new();
        calculation = new Calculation();
        answers = dtoAnswers.GetAllAnswers();
    }

    public List<DataPoint> Alles()
    {
        foreach (Answer answer in answers)
        {
            if (answer.answerRange <= 0)
            {
                continue;
            }

            if (!answerDictionary.ContainsKey(answer.questionID))
            {
                answerDictionary.Add(answer.questionID, new List<int>());
            }
            answerDictionary[answer.questionID].Add(answer.answerRange);
        }

        foreach (var ans in answers)
        {
            if (ans.answerRange > 0)
            {
                answerRanges.Add(ans.answerRange);
                questionIds.Add(ans.questionID);
            }
        }

        Dictionary<int, double> averages = calculation.GetAverageAnswerRange(answerDictionary);
        foreach (var avg in averages)
        {
            if (answers.Find(x => x.questionID == avg.Key).question.Contains("[Trend]"))
            {
                continue;
            }

            dataPoints.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, Math.Round(avg.Value, 2)));
        }

        return dataPoints;
    }

}
