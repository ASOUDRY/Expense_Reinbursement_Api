using User;
using ModelsLayer;
using Microsoft.Data.SqlClient;
namespace RepoLayer;
public class DBAccess : IDBAccess
{

    Registration Register = new Registration();
    Login Login = new Login();
    Submit Submit = new Submit();
    ProcessTicket Process = new ProcessTicket();
    Review Review = new Review();

    FetchTicket Fetch = new FetchTicket();

    SqlConnection connection = new SqlConnection("");

    public async Task<List<Ticket>> PullTicket() 
    {
         List<Ticket> ret = await Review.PullTicketsAsync();
         return ret;
    }

    public async Task<List<Ticket>> FetchTicket(string user) 
    {
         List<Ticket> ret = await Fetch.FetchTicketAsync(user);
         return ret;
    }      

    public async Task<UserInfo> RegisterANewUser(UserQuery user) 
    {
        UserInfo ret = await Register.RegisterAsync(user);
        return ret;              
    }

     public async Task<UserInfo> LoginUser(string name, string Password) 
    {
        UserInfo ret = await Login.LoginAsync(name, Password);
        return ret;              
    }
     public async Task<Ticket> SubmitTicket(Ticket t) 
    {
        Ticket ret = await Submit.SubmitAsync(t);
        return ret;              
    }
     public async Task<Ticket> TicketProcessing(Ticket t) 
    {
        Ticket ret = await Process.ProcessingAsync(t);
        return ret;              
    }
    }

