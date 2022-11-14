using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Test
{
    public class DatabaseManagerMockData1Test
    {
        public void MakeTableWorks()
        {
            string name = "MakingTableWorks";
            List<string> columns = new string[] { "columnA", "columnB", "columnC" }.ToList();
            List<string> types = new string[] { "int", "int", "int"}.ToList();

            DatabaseManager databaseManager = new DatabaseManager();
            int returnedRows = databaseManager.MakeTable(name, columns, types);

            Assert.Equal(5, testObjects.Count);
        }

    }
}
