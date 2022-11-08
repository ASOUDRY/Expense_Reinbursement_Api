using Microsoft.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer;
public class Review {
SqlConnection connection = new SqlConnection($"Server=tcp:alexander-resume-server.database.windows.net,1433;Initial Catalog=Expense-Reinbursement-Api-Storage;Persist Security Info=False;User ID=Munchydragon;Password={Secrets.password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

public async Task<List<Ticket>> PullTicketsAsync() {
    List<Ticket> TicketList = new List<Ticket>();
    await Task.Delay(1000);
     try
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Tickets WHERE IsProcessed = 0 ;", connection);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
               while(reader.Read()) 
                {
                    string id = (string) reader["Id"];
                    string n = (string) reader["NameofExpense"];
                    float a = (float) reader["AmountSpent"];
                    string j = (string) reader["Justification"];
     
                    Ticket ticket = new Ticket {
                        Id = id,
                        NameofExpense = n,
                        AmountSpent = a,
                        Justification = j,                
                    };  
                    TicketList.Add(ticket);
               }
            }
        }
 catch(SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connection.Close();
        }
return TicketList;
}

}
