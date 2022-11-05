 using Microsoft.Data.SqlClient;
 using User;
 using ModelsLayer;
 public class FetchTicket {
List<Ticket> TicketList = new List<Ticket>();
SqlConnection connection = new SqlConnection("");
 public async Task<List<Ticket>> FetchTicketAsync(string User) {
    await Task.Delay(1000);
 try
        {
            connection.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM Tickets2 WHERE Id = '{User}';", connection);
 
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
           
/*
            if(TicketList.Count == 0) {
                Console.WriteLine("You have no tickets of this type available.");

            }
            else {
                  Console.WriteLine("Here are your reviewed Tickets");
                     Console.WriteLine("");
                  
            foreach(Ticket item in TicketList) {
                string proxy = "Rejected.";
                if (item.IsProcessed == false) {
                 proxy = "Pending.";
                }
                if (item.IsApproved == true) {
                    proxy = "Your ticket was approved.";
                }
                           Console.WriteLine("NameofExpense: " + item.NameofExpense + ", Amount Spent: " + item.AmountSpent + ", Justification: " + item.Justification + ", Status: " + proxy);
                           Console.WriteLine("");
            }
            }
        */    
    }
 }