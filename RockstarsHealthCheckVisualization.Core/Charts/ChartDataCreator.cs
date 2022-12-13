namespace RockstarsHealthCheckVisualization.Core.Charts;
public class ChartDataCreator
{
    private List<DataPoint> dataPointsQuestionData;
    private List<DataPoint> dataPointTrendData;
    private Dictionary<int, List<int>> trendDictionary;
    private List<int> trendAnswerRanges;
    private List<int> trendQuestionIds;

    private DTOAnswers dtoAnswers;
    private List<int> answerRanges;
    private List<int> questionIds;
    private Dictionary<int, List<int>> answerDictionary;
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

        foreach (var avg in questionAverages)
        {
            if (answers.Find(x => x.questionID == avg.Key).question.Contains("[Trend]"))
            {
                continue;
            }

            dataPointsQuestionData.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, Math.Round(avg.Value, 2)));
        }

        return dataPointsQuestionData;
    }

    public List<List<DataPoint>> GetDataForTrend()
    {
        List<List<DataPoint>> dataPointsTrend = new();

        foreach (KeyValuePair<int, List<int>> key in trendDictionary)
        {
            Dictionary<int, List<int>> better = new();
            Dictionary<int, List<int>> equal = new();
            Dictionary<int, List<int>> worse = new();

            List<DataPoint> newdatapoint = new();


            foreach (var value in key.Value)
            {
                switch (value)
                {
                    case -1:
                        if (!better.ContainsKey(key.Key))
                        {
                            better.Add(key.Key, new List<int>());
                        }

                        better[key.Key].Add(value);
                        break;

                    case -2:
                        if (!equal.ContainsKey(key.Key))
                        {
                            equal.Add(key.Key, new List<int>());
                        }

                        equal[key.Key].Add(value);
                        break;
                    case -3:
                        if (!worse.ContainsKey(key.Key))
                        {
                            worse.Add(key.Key, new List<int>());
                        }

                        worse[key.Key].Add(value);
                        break;
                };
            }

            newdatapoint.Add(new DataPoint("better", better.Values.First().Count));
            newdatapoint.Add(new DataPoint("equal", equal.Values.First().Count));
            newdatapoint.Add(new DataPoint("worse", worse.Values.First().Count));

            dataPointsTrend.Add(newdatapoint);
        }

        return dataPointsTrend;
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
