   using Microsoft.Data.SqlClient;
   using User;
   using ModelsLayer;
   public class Login {
   
    SqlConnection connection = new SqlConnection("");

   public async Task<UserInfo> LoginAsync(string name, string Password) {
   UserInfo Card = new UserInfo();
   await Task.Delay(1000);
   try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM UserInfo2 WHERE Username = '{name}' AND Password = '{Password}';", connection);
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