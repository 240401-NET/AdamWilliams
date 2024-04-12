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
}