   using Microsoft.Data.SqlClient;
   using User;

   namespace RepoLayer{
   public class Login
   {

SqlConnection connection = new SqlConnection($"Server=tcp:alexander-resume-server.database.windows.net,1433;Initial Catalog=Expense-Reinbursement-Api-Storage;Persist Security Info=False;User ID=Munchydragon;Password={Secrets.password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
   public async Task<UserInfo> LoginAsync(string name, string Password) {
   UserInfo Card = new UserInfo();
   await Task.Delay(1000);
   
   try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM UserInfo WHERE Username = '{name}' AND Password = '{Password}';", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                    while(reader.Read()) 
                        {
                            string id = (string) reader["Id"];
                            string u = (string) reader["Username"];
                            string p = (string) reader["Password"];
                            bool m = (bool) reader["Manager"];
                            bool e = (bool) reader["Employee"];
                        
                    Card.acceptValues(u, p, m, e, id);
                    }
                    }
                }
                    catch(SqlException){
                    throw;
                }
                    finally{
                    connection.Close();
                }
                return Card;
   }
   }
   }