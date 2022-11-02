using System.Data.SqlClient;

namespace RockstarsHealthCheckVisualization.Models
{

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        private string connectionString = @"Server=tcp:rockstars.database.windows.net,1433;Initial Catalog=RockstarsDataBase;Persist Security Info=False;User ID=RockstarAdmin;Password=Rockstars!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public void test()
        {
            using var connection = new SqlConnection(connectionString);

        }
    }


}