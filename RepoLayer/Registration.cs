using Microsoft.Data.SqlClient;
using ModelsLayer;
using User;
public class Registration {

SqlConnection connection = new SqlConnection("");

public async Task<UserInfo> RegisterAsync(UserQuery User) {

await Task.Delay(1000);

List<string> verification = new List<string>();
 try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT Username FROM UserInfo2;", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                    while(reader.Read()) 
                        {
                          string check = (string) reader["Username"];

                          if (check == User.Name) {
                        verification.Add(check);
                          }
                    }
                    }
                }
                    catch(SqlException){
                    throw;
                }
                    finally{
                    connection.Close();
                }

                if (verification.Count == 0) {
try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO UserInfo2 (Id, Username, Password, Manager, Employee) VALUES (@Id, @Username, @Password, @Manager, @Employee)", connection);
            cmd.Parameters.AddWithValue("@Id", User.Id);
            cmd.Parameters.AddWithValue("@Username", User.Name);
            cmd.Parameters.AddWithValue("@Password", User.Password);
            cmd.Parameters.AddWithValue("@Manager", false);
            cmd.Parameters.AddWithValue("@Employee", true);
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
  }
  
  if (verification.Count == 0) {
  UserInfo Snapshot = new UserInfo {
    Id = User.Id,
    Name = User.Name,
    Password = User.Password,
    ManagStatus = false,
    IsEmployee = true
  };
  return Snapshot;
  } 
  else {
     UserInfo Snapshot = new UserInfo {
    Id = User.Id,
    Name = "The Username is not available",
    Password = User.Password,
    ManagStatus = false,
    IsEmployee = true
  };
   return Snapshot;
  }   
}

}
