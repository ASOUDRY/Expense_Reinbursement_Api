using User;
using ModelsLayer;
using RepoLayer;
namespace BusinessLayer;
public class BusinessLayerClass : IBusinessLayerClass
{

    DBAccess _dbaccess = new DBAccess();
    /*
    private readonly DBAccess _dbaccess;
    public BusinessLayerClass(DBAccess d)
    {
        _dbaccess = d;
    }
    */


    public async Task<List<Ticket>> PullTicket() 
    {
         List<Ticket> ret = await _dbaccess.PullTicket();
         return ret;
    }

     public async Task<List<Ticket>> FetchTicket(string user) 
    {
         List<Ticket> ret = await _dbaccess.FetchTicket(user);
         return ret;
    }  

    public async Task<UserInfo> RegisterANewUser(UserQuery user) 
    {
        UserInfo ret = await _dbaccess.RegisterANewUser(user);
        return ret;
    }

     public async Task<UserInfo> LoginUser(string name, string Password) 
    {
        UserInfo ret = await _dbaccess.LoginUser(name, Password);
        return ret;
    }
     public async Task<Ticket> SubmitTicket(Ticket t) 
    {
        Ticket ret = await _dbaccess.SubmitTicket(t);
        return ret;
    }
     public async Task<Ticket> TicketProcessing(Ticket t) 
    {
        Ticket ret = await _dbaccess.TicketProcessing(t);
        return ret;
    }
}