using Microsoft.Data.SqlClient;
using ModelsLayer;
using User;
public class Submit {
SqlConnection connection = new SqlConnection("");
public async Task<Ticket> SubmitAsync(Ticket ticket) {

    
  /*      
        Console.WriteLine("What is the name of your expense?");
        string? ticketname = Console.ReadLine();
        float result = -1;
        while (result <= 0) {
        Console.Write("");
        Console.Write("");
        Console.WriteLine("How much are you asking to be reinbursed?");
        string? input = Console.ReadLine();
     
        float.TryParse(input, out result);
           
        if (result <= 0) {
            Console.Write("Invalid amount or Input.  ");
            Console.Write("");
            Console.Write("");
        }

        }
         string? reasoning = "";
         if (reasoning != null ) {
         while (reasoning?.Length == 0) {
        Console.WriteLine("Why did you charge this expense?");
        reasoning =  Console.ReadLine();
          if (reasoning != null ) {
        if (reasoning.Length == 0) {
            Console.WriteLine("Please submit a explanation for your ticket");
            Console.WriteLine("");
        } }
        }
    }
    */
        await Task.Delay(1000);
        try{
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Tickets2 (Id, NameOfExpense, AmountSpent, Justification, IsApproved, IsProcessed) VALUES (@Id, @Expense, @Amount, @Explanation, @Approved, @Processed)", connection);
                    cmd.Parameters.AddWithValue("@Id", ticket.Id);
                    cmd.Parameters.AddWithValue("@Expense", ticket.NameofExpense);
                    cmd.Parameters.AddWithValue("@Amount", ticket.AmountSpent);
                    cmd.Parameters.AddWithValue("@Explanation", ticket.Justification);
                    cmd.Parameters.AddWithValue("@Approved", false);
                    cmd.Parameters.AddWithValue("@Processed", false);
                //    cmd.Parameters.AddWithValue("@client", ticket.Client);
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