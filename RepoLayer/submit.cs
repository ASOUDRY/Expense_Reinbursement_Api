using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer;
public class Submit {
SqlConnection connection = new SqlConnection($"Server=tcp:alexander-resume-server.database.windows.net,1433;Initial Catalog=Expense-Reinbursement-Api-Storage;Persist Security Info=False;User ID=Munchydragon;Password={Secrets.password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
public async Task<Ticket> SubmitAsync(Ticket ticket) {
        await Task.Delay(1000);
        try{
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Tickets (Id, NameOfExpense, AmountSpent, Justification, IsApproved, IsProcessed) VALUES (@Id, @Expense, @Amount, @Explanation, @Approved, @Processed)", connection);
                    cmd.Parameters.AddWithValue("@Id", ticket.Id);
                    cmd.Parameters.AddWithValue("@Expense", ticket.NameofExpense);
                    cmd.Parameters.AddWithValue("@Amount", ticket.AmountSpent);
                    cmd.Parameters.AddWithValue("@Explanation", ticket.Justification);
                    cmd.Parameters.AddWithValue("@Approved", false);
                    cmd.Parameters.AddWithValue("@Processed", false);
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
        return ticket;
        }
   }