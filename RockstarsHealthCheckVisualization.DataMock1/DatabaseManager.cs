﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.DataMock1
{
    internal class DatabaseManager
    {
        public List<AnswerDto> Answers { get; set; }
        public List<
        public string connectionString = "Data Source = rockstars.database.windows.net; Initial Catalog = RockstarsDataBase; Persist Security Info = True; User ID = RockstarAdmin; Password = Rockstars!";

        public List<AnswerDto> GetAllAnswers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand query = new SqlCommand("select * from CSVtoTableTestData"))
                {
                    conn.Open();
                    var reader = query.ExecuteReader();
                    while (reader.Read()) // stays true while reader gives back rows (until end table)
                    {
                        int firstColumn = reader.GetString(0);
                    }
                }
            }
        }

    }
}
