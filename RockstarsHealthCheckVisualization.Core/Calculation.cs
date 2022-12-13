using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

    public Dictionary<int, double> GetTrendRange(Dictionary<int, List<int>> trendAnswers)
    {
        Dictionary<int, double> better = new();
        Dictionary<int, double> equal = new();
        Dictionary<int, double> worse = new();

        foreach (KeyValuePair<int, List<int>> dictionaryEntry in trendAnswers)
        {
            foreach(var value in dictionaryEntry.Value)
            {
                if (value == -1)
                {

                }
                else if(value == -2)
                {

                }
                else if(value == -3)
                {

                }
            }
            


            averageList.Add(dictionaryEntry.Key, Queryable.Average(dictionaryEntry.Value.AsQueryable()));
        }

        return ();
    }

}



