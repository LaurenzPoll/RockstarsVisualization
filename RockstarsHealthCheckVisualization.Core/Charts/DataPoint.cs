﻿using System.Runtime.Serialization;

namespace RockstarsHealthCheckVisualization.Core.Charts;

[DataContract]
public class DataPoint
{
    [DataMember(Name = "text")]
    public string TrendName { get; set; }

    public DataPoint(string label, double y)
    {
        this.Label = label;
        this.Y = y;
    }

    //Explicitly setting the name to be used while serializing to JSON.
    [DataMember(Name = "label")]
    public string Label = "";

    //Explicitly setting the name to be used while serializing to JSON.
    [DataMember(Name = "y")]
    public Nullable<double> Y = null;
}
