using Microsoft.Data.SqlClient;
using ModelsLayer;
public class Review {
SqlConnection connection = new SqlConnection("");

public async Task<List<Ticket>> PullTicketsAsync() {
    List<Ticket> TicketList = new List<Ticket>();
    await Task.Delay(1000);
     try
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Tickets2 WHERE IsProcessed = 0 ;", connection);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
               while(reader.Read()) 
                {
                    string id = (string) reader["Id"];
                    string n = (string) reader["NameofExpense"];
                    float a = (float) reader["AmountSpent"];
                    string j = (string) reader["Justification"];
           //         string c = (string) reader ["Client"];
     
                    Ticket ticket = new Ticket {
                        Id = id,
                        NameofExpense = n,
                        AmountSpent = a,
                        Justification = j,
                     //   Client = c                   
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
