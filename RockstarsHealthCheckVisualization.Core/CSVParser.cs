using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class CSVParser
    {
        public List<string> GetLinesCSV(string fileName)
        {
            // var fileStream = new FileStream(@"names.csv", FileAccess.Read);
            // var filestream = AssemblyLoadEventArgs.GetManifertResourceStream(RockstarsHealthCheck.)

            string csvString = "";

            var assembly = Assembly.GetExecutingAssembly(); 

            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("names.csv"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    csvString = reader.ReadToEnd();
                }
            }

            List<string> csvList = csvString.Split("\n").ToList();
            return csvList;

            /*
            //adding lines to list
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list;
            */
        }

        

    }
}
