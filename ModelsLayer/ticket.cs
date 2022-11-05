using System.ComponentModel.DataAnnotations;
namespace ModelsLayer;
public class Ticket {

// Optional Date Time Parameter
//  string iDate = "05/05/2005";
//DateTime oDate = Convert.ToDateTime(iDate);

//    private string _client = "";
    private string _id = "";
    private bool _isProcessed;
    private bool _isApproved;
    public string Id {
        get {
            return _id;
        }
        set {
               _id = value;
            }
        }
    private string _nameOfExpense = "";
    private float _amountSpent;
    private string _justification = "";
    // verify
   // [StringLength]
       [Required(ErrorMessage = "It is required to name your expense.")]
    public string NameofExpense {
        get {
            return _nameOfExpense;
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
                _nameOfExpense = value;
            }
        }
    }
    /*
     public string Client {
        get {
            return _client;
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
                _client = value;
            }
        }
    }
  */
    // Verify
    [Range(1, 9999, ErrorMessage = "You did not enter a valid expense. Please submit a valid expense.")]
    public float AmountSpent {
        get {
            return _amountSpent;
        }
        set {
        
                _amountSpent = value;
            }
        }
    public string Justification {
        get {
            return _justification;
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
                _justification = value;
            }
        }
    }
    public bool IsProcessed {
        get {
            return _isProcessed;
        }
        set {
               _isProcessed = value;
            }
        }
    public bool IsApproved {
        get {
            return _isApproved;
        }
        set {
               _isApproved = value;
            }
        }

public void loadTicket(string value, float value3, string value4, bool value5, bool value6, string value7) {
    NameofExpense = value;
     
      AmountSpent = value3;
       Justification = value4;
        IsApproved = value5;
         IsProcessed = value6;
          Id = value7;
}
}