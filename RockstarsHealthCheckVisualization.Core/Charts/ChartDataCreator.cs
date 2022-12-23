using System.Runtime.Intrinsics.X86;

namespace RockstarsHealthCheckVisualization.Core.Charts;
public class ChartDataCreator
{
    private IRepository repository;
    private List<DataPoint> dataPointsQuestionData;
    private List<DataPoint> dataPointTrendData;
    private Dictionary<int, List<int>> trendDictionary;
    private List<int> trendAnswerRanges;
    private List<int> trendQuestionIds;

    private List<int> answerRanges;
    private List<int> questionIds;
    private Dictionary<int, List<int>> answerDictionary;
    private readonly Calculation calculation;


    private List<Answer> answers;
    private List<Answer> answersPerUser;

    public ChartDataCreator(IRepository repository)
    {
        this.repository = repository;
        dataPointTrendData = new();
        trendDictionary = new();
        trendAnswerRanges = new();
        trendQuestionIds = new();

        dataPointsQuestionData = new List<DataPoint>();

        answerRanges = new List<int>();
        questionIds = new List<int>();
        answerDictionary = new();
        calculation = new Calculation();

        answers = repository.GetAllAnswers();
        //answersPerUser = repository.GetAllAnswersFromUser(11, new DateTime(2022, 12, 9, 14, 24, 22, 463));
    }

    public List<DataPoint> DataForBarGraph()
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

            dataPointsQuestionData.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, Math.Round(avg.Value - 3, 2)));
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

            DataPoint dataBetter = new("better", better.Values.First().Count);
            dataBetter.TrendName = answers.Find(x => x.questionID == key.Key).question;
            newdatapoint.Add(dataBetter);


            DataPoint dataEqual = new("equal", equal.Values.First().Count);
            dataEqual.TrendName = answers.Find(x => x.questionID == key.Key).question;
            newdatapoint.Add(dataEqual);


            DataPoint dataWorse = new("worse", worse.Values.First().Count);
            dataWorse.TrendName = answers.Find(x => x.questionID == key.Key).question;
            newdatapoint.Add(dataWorse);


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

    public List<DataPoint> PerUser()
    {
        SplitAnswersToDictionarysPerUser();

        GetAllIDsAndAnswerRangesPerUser();


        Dictionary<int, double> questionAverages = calculation.GetAverageAnswerRange(answerDictionary);

        Dictionary<int, double> trendAverages = calculation.GetAverageAnswerRange(trendDictionary);


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
            dataPointTrendData.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, Math.Round(avg.Value, 2)));
        }

        return dataPointsQuestionData;
    }

    public List<DataPoint> DataForBarGraphPerUser(User user)
    {
        answersPerUser = repository.GetAllAnswersFromUser(user.UserId);

        SplitAnswersToDictionarysPerUser();

        GetAllIDsAndAnswerRangesPerUser();


        Dictionary<int, double> questionAverages = calculation.GetAverageAnswerRange(answerDictionary);

        Dictionary<int, double> trendAverages = calculation.GetAverageAnswerRange(trendDictionary);


        foreach (var avg in questionAverages)
        {
            if (answers.Find(x => x.questionID == avg.Key).question.Contains("[Trend]"))
            {
                continue;
            }

            dataPointsQuestionData.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, Math.Round(avg.Value - 3, 2)));
        }


        foreach (var avg in trendAverages)
        {
            dataPointTrendData.Add(new DataPoint(answers.Find(x => x.questionID == avg.Key).question, Math.Round(avg.Value, 2)));
        }

        return dataPointsQuestionData;
    }

    private void GetAllIDsAndAnswerRangesPerUser()
    {
        foreach (var ans in answersPerUser)
        {
            if (ans.answerRange > 0)
            {
                answerRanges.Add(ans.answerRange);
                questionIds.Add(ans.questionID);
            }
            else if (ans.answerRange < 0)
            {
                answerRanges.Add(ans.answerRange);
                questionIds.Add(ans.questionID);
            }
        }
    }



    private void SplitAnswersToDictionarysPerUser()
    {
        foreach (Answer answer in answersPerUser)
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
