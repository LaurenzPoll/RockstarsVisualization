using RockstarsHealthCheckVisualization.Core.Charts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core;

public class Calculation
{


    public Dictionary<int, double> GetAverageAnswerRange(Dictionary<int, List<int>> answers)
    {
        Dictionary<int, double> averageList = new();
        foreach(KeyValuePair<int, List<int>> dictionaryEntry in answers)
        {
            averageList.Add(dictionaryEntry.Key, Queryable.Average(dictionaryEntry.Value.AsQueryable()));
        }

        return (averageList);
    }

    public Dictionary<int, List<int>> GetTrendRange(Dictionary<int, List<int>> trendAnswers)
    {
        foreach (KeyValuePair<int, List<int>> dictionaryEntry in trendAnswers)
        {
            int i = dictionaryEntry.Value.Count;
        }


        List<DataPoint> dataPointsTrendData = new();

        //dataPointsTrendData.Add(new DataPoint();











        //Dictionary<int, List<int>> better = new();
        //Dictionary<int, List<int>> equal = new();
        //Dictionary<int, List<int>> worse = new();


        //List<Dictionary<int, List<int>>> trend = new();

        //List<int> keys = new();

        ////Get all keys from source
        //foreach (var key in trendAnswers)
        //{
        //    if (!keys.Contains(key.Key))
        //    {
        //        keys.Add(key.Key);
        //    }
        //}



        //foreach (int key in keys)
        //{
        //    Dictionary<int, List<int>> temporaryDict = new();
        //    temporaryDict.Add(key, new List<int>());

        //    trend.Add(temporaryDict);
        //}


        //foreach (KeyValuePair<int, List<int>> dictionaryEntry in trendAnswers)
        //{

        //    if (!keys.Contains(dictionaryEntry.Key))
        //    {
        //        Dictionary<int, List<int>> temporaryDict = new();
        //        temporaryDict.Add(dictionaryEntry.Key, new List<int>());

        //        trend.Add(temporaryDict);
        //    }

        //    trend[dictionaryEntry.Key].Add(dictionaryEntry.Value);

        //}










        //foreach (KeyValuePair<int, List<int>> dictionaryEntry in trendAnswers)
        //{
        //    foreach(var value in dictionaryEntry.Value)
        //    {
        //        switch(value)
        //        {
        //            case -1:
        //                if (!better.ContainsKey(dictionaryEntry.Key))
        //                {
        //                    better.Add(dictionaryEntry.Key, new List<int>());
        //                }

        //                better[dictionaryEntry.Key].Add(value);
        //                break;

        //            case -2:
        //                if (!equal.ContainsKey(dictionaryEntry.Key))
        //                {
        //                    equal.Add(dictionaryEntry.Key, new List<int>());
        //                }

        //                equal[dictionaryEntry.Key].Add(value);
        //                break;
        //            case -3:
        //                if (!worse.ContainsKey(dictionaryEntry.Key))
        //                {
        //                    worse.Add(dictionaryEntry.Key, new List<int>());
        //                }

        //                worse[dictionaryEntry.Key].Add(value);
        //                break;
        //        };
        //    }
        //}

        return null;
    }

}



