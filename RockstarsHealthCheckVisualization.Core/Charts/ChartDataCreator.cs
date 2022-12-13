using System.Numerics;
using System.Runtime.Intrinsics.X86;

namespace RockstarsHealthCheckVisualization.Core.Charts;
public class ChartDataCreator
{
    private List<DataPoint> dataPointsQuestionData;
    private List<DataPoint> dataPointTrendData;
    Dictionary<int, List<int>> trendDictionary;
    private List<int> trendAnswerRanges;
    private List<int> trendQuestionIds;

    private DTOAnswers dtoAnswers;
    private List<int> answerRanges;
    private List<int> questionIds;
    Dictionary<int, List<int>> answerDictionary;
    private readonly Calculation calculation;


    private List<Answer> answers;

    public ChartDataCreator()
    {
        dataPointTrendData = new();
        trendDictionary = new();
        trendAnswerRanges = new();
        trendQuestionIds = new();

        dataPointsQuestionData = new List<DataPoint>();
        dtoAnswers = new DTOAnswers();
        answerRanges = new List<int>();
        questionIds = new List<int>();
        answerDictionary = new();
        calculation = new Calculation();
        answers = dtoAnswers.GetAllAnswers();
    }

    public List<DataPoint> Alles()
    {
        SplitAnswersToDictionarys();

        GetAllIDsAndAnswerRanges();


        Dictionary<int, double> questionAverages = calculation.GetAverageAnswerRange(answerDictionary);

        Dictionary<int, double> trendAverages = calculation.GetTrendRange(trendDictionary);


        foreach (var avg in questionAverages)
        {
            if (answers.Find(x => x.questionID == avg.Key).question.Contains("[Trend]"))
            {
                continue;
            }

            dataPointsQuestionData.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, Math.Round(avg.Value, 2)));
        }

        

        foreach (var avg in trendAverages)
        {
            //dataPointTrendData.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, (int)Math.Round((double)(100 * complete) / total));
        }

        return dataPointsQuestionData;
    }

    public List<DataPoint> GetDataForTrend()
    {
        return null;
    }




    private void GetAllIDsAndAnswerRanges()
    {
        foreach (var ans in answers)
        {
            if (ans.answerRange > 0)
            {
                answerRanges.Add(ans.answerRange);
                questionIds.Add(ans.questionID);
            }
            else if (ans.answerRange < 0)
            {
                trendAnswerRanges.Add(ans.answerRange);
                trendQuestionIds.Add(ans.questionID);
            }
        }
    }



    private void SplitAnswersToDictionarys()
    {
        foreach (Answer answer in answers)
        {
            if (answer.answerRange < 0)
            {
                if (!trendDictionary.ContainsKey(answer.questionID))
                {
                    trendDictionary.Add(answer.questionID, new List<int>());
                }
                else
                {
                    trendDictionary[answer.questionID].Add(answer.answerRange);
                }
                continue;
            }

            if (!answerDictionary.ContainsKey(answer.questionID))
            {
                answerDictionary.Add(answer.questionID, new List<int>());
            }
            answerDictionary[answer.questionID].Add(answer.answerRange);
        }
    }

}
