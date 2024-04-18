using System.Text.RegularExpressions;

namespace memoKeeper;

public class Validator {
    public static string getUserInput(){
        string userInput = Console.ReadLine();
        if(userInput == "" || userInput == null){
            return " ";
        }
        return userInput;
    }

    public static int getIntUserInput(string UserInput){
        try{
            return Convert.ToInt32(UserInput);
        } catch {
            return -1;
        }
        
    }
    public static bool IsValidDateFormat(string date)
    {
        Regex exp = new Regex(@"^(1[0-2]|0?[1-9])(\/|-)(3[01]|[12][0-9]|0?[1-9])\2([0-9]{2})?[0-9]{2}$");
        if (exp.IsMatch(date))
        {
            return true;
        }
        //throw new FormatException("Date must be dd/mm/yyyy or dd-mm-yyyy format.");
        return false;
    }
}