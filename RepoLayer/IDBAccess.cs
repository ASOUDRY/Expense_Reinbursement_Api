using Microsoft.Data.SqlClient;
namespace RepoLayer
{
    public interface IDBAccess
    {
        public SqlConnection GetConnection();
    }
}