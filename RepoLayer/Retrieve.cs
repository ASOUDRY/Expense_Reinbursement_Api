 using Microsoft.Data.SqlClient;

 using ModelsLayer;
 namespace RepoLayer;
 public class FetchTicket {
List<Ticket> TicketList = new List<Ticket>();

SqlConnection connection = new SqlConnection($"Server=tcp:alexander-resume-server.database.windows.net,1433;Initial Catalog=Expense-Reinbursement-Api-Storage;Persist Security Info=False;User ID=Munchydragon;Password={Secrets.password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
 public async Task<List<Ticket>> FetchTicketAsync(string User) {
    await Task.Delay(1000);
 try
        {
            connection.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM Tickets WHERE Id = '{User}';", connection);
 
            SqlDataReader reader = command.ExecuteReader();
            
            if(reader.HasRows)
            {
               while(reader.Read()) 
                {
                    string id = (string) reader["Id"];
                    string n = (string) reader["NameOfExpense"];
                    float a = (float) reader["AmountSpent"];
                    string j = (string) reader["Justification"];
                    bool ap = (bool) reader["IsApproved"];
                    bool p = (bool) reader["IsProcessed"];
                   
                    Ticket ticket = new Ticket {
                        Id = id,
                       NameofExpense = n,
                       AmountSpent = a,
                       Justification = j,
                       IsApproved = ap,
                       IsProcessed = p
                       
                    };     
                    TicketList.Add(ticket); 
               }
            }
        }
        catch(SqlException ex)
        {
            //great opportunity to log to logger
            throw ex;
        }
        finally
        {
            connection.Close();
        }
        return TicketList;  
    }
 }