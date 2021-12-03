using Npgsql;
using System.Data;

namespace MorCompany.Fiscalizacion.Datos
{
    public class RepositorioBase
    {
        private string connectionString;

        public RepositorioBase(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public IDbConnection OpenConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
