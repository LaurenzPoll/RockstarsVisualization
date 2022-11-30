using System.Runtime.Serialization;

namespace RockstarsHealthCheckVisualization.Models
{
    public class GraphData
    {
            public GraphData(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            // setting the name to be used when serializing to JSON.
            [DataMember(Name = "x")]
            public Nullable<double> X = null;

            //setting the name to be used whenserializing to JSON.
            [DataMember(Name = "y")]
            public Nullable<double> Y = null;
    }
}
