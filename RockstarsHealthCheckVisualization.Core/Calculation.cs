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
}



