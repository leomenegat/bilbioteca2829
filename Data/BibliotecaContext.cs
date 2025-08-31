using Microsoft.Data.SqlClient;

namespace biblioteca.Data
{
    public class BibliotecaContext
    {
        private string connectionString = 
            @"Server=localhost\SQLEXPRESS;Database=BibliotecaDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
