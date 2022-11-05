namespace User;
public class UserInfo {

    private bool _isEmployee = true;
    private bool _managStatus = false;
    private string _name = "";
    private string _password = "";

     public string Id {get; set;} = "";
   // public Guid Id {get; set;} = Guid.NewGuid();
    public bool IsEmployee {
        get {
            return _isEmployee;
        }
        set {
               _isEmployee = value;
            }
        }
      
    public bool ManagStatus 
    {
        get {
            return _managStatus;
        }
        set {
               _managStatus = value;
            }
        }
       
    public string Name {
        get {
            return _name;
        }
        set {
              //value is the thing user is trying to set the property as
            if(String.IsNullOrWhiteSpace(value))
            {
                //we're gonna throw some exception, regarding input validation
                throw new ArgumentException("We need a username");
            }
            else
            {
                //we'll set the value they passed as our private field value
                _name = value;
            }
        }
    }

     public string Password {
        get {
            return _password;
        }
        set {
              //value is the thing user is trying to set the property as
            if(String.IsNullOrWhiteSpace(value))
            {
                //we're gonna throw some exception, regarding input validation
                throw new ArgumentException("We need a username");
            }
            else
            {
                //we'll set the value they passed as our private field value
                _password = value;
            }
        }
    }

    public void acceptValues(string value, string value2, bool value3, bool value4, string value5) {
        Name = value;
        Password = value2;
        ManagStatus = value3;
        IsEmployee = value4;
        Id = value5;

    }

      public void becomeEmployee(bool value) {
            _isEmployee = value;
    }

     public void becomeManag(bool value) {
            ManagStatus = value;
    
    }
}
