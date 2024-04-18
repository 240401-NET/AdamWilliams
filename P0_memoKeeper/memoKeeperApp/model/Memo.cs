using System.Text.RegularExpressions;

namespace memoKeeper;

public class Memo{

    private string _title;
    private string _date;
    private string _message;

    //Getters and Setters
    public string Title
    {
        get {return _title;}
        set {_title = value;}
    }
    
    public string Date
    {
        get {return _date;}
        set {_date = DateTime.Now.ToShortDateString();}
    }

    public string Message
    {
        get {return _message;}
        set {_message = value;}
    }

    public Memo() {
        _title = " ";
        _date = DateTime.Now.ToShortDateString();
        _message = " ";
    }
    public Memo(string t, string d, string m) {
        
        _title = t;
        _date = d;
        _message = m;
    }

    public bool IsValidDateFormat()
    {
        Regex exp = new Regex(@"^(1[0-2]|0?[1-9])(\/|-)(3[01]|[12][0-9]|0?[1-9])\2([0-9]{2})?[0-9]{2}$");
        if (exp.IsMatch(_date))
        {
            return true;
        }
        //throw new FormatException("Date must be dd/mm/yyyy or dd-mm-yyyy format.");
        return false;
    }


}