using ModelsLayer;
using Microsoft.Data.SqlClient;
namespace RepoLayer;

public class ProcessTicket {
SqlConnection connection = new SqlConnection("");
           
public async Task<Ticket> ProcessingAsync(Ticket t) {
await Task.Delay(1000);
    try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand($"UPDATE Tickets2 SET IsApproved = @Approved, IsProcessed = @Processed WHERE Id = '{t.Id}'AND IsProcessed = 0 ", connection);
            cmd.Parameters.AddWithValue("@Approved", t.IsApproved);
            cmd.Parameters.AddWithValue("@Processed", true);
            cmd.ExecuteNonQuery();
        }
        catch(SqlException)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
        t.IsProcessed = true;
        return t;
    }
}