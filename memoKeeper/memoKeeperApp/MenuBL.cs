using System.Reflection.Metadata;
using System.Text;
using memoKeeper;

namespace memoKeeper;

public class MenuBL(){

    //handle all the business logic for Menu
    public static bool displayAllMemosBL(ref List<Memo> memoList, ref bool menuFlag){
        
        int userInput = getIntUserInput(getUserInput());
        
        if(userInput > memoList.Count() || userInput < 0){
            Console.WriteLine("\nInvalid selection. Please try again.\n");
            pauseForEnter();
        } else if(userInput <= memoList.Count() && userInput > 0){
            Memo m = memoList[userInput-1];
            Memo.displayMemo(m);
            Menu.saveMenu(ref memoList, ref m);
            menuFlag = false;       
        } else if (userInput == 0) {
            menuFlag = false;}
        
        return menuFlag;
    }

    public static bool viewMemoByDateBL(ref List<Memo> memoList, ref bool menuFlag){

        string userDate = getUserInput();

        if (userDate == "0"){
            menuFlag = false;
        } else if (userDate != "0"){
            if(userDate.Length!=10) {
                if(userDate.Length!=8 && userDate != "0"){
                    Console.WriteLine("Incorrect format. Please try again. Press Enter to continue");
                    pauseForEnter();
                } else {
                    List<Memo> matchingMemos = new();
                    if(memoList.Count()>0){
                        matchingMemos = getMatchingDates(memoList, ref matchingMemos, userDate);
                        if(matchingMemos.Count()==0){
                            Console.WriteLine("\n \nDate not found. Please try again. Press Enter to continue.\n \n");
                            pauseForEnter();
                        } else {
                            Console.Clear();
                            Console.WriteLine($"Memos from {userDate}: \n");
                            Menu.displayMemoList(matchingMemos);
                        }
                    } else if(memoList.Count()==0){
                        Console.Clear();
                        Console.WriteLine("List is empty. Nothing to search.\n \nPress Enter to continue.");
                        pauseForEnter();  
                    }
                    if (matchingMemos.Count()>0)
                    {
                        Console.WriteLine("\n 0.) Back to Main Menu\n \nPlease enter selection number below:\n");
                        try
                        {
                            var userInput = Convert.ToInt32(getUserInput());
                            bool selecting = true;
        
                            while (selecting)
                            {
                                if (userInput>0 && matchingMemos.Count()>0)
                                {
                                    Memo m = matchingMemos[userInput-1];
                                    Memo.displayMemo(m);
                                    Menu.saveMenu(ref memoList, ref m);
                                    menuFlag = false;
                                    selecting = false;
                                } else if(userInput == 0){
                                    menuFlag = false;
                                    selecting = false;
                                } else {
                                    Console.WriteLine("Invalid Respone. Please try again. Press Enter to continue.");
                                    pauseForEnter();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Please enter a valid selection. Press Enter to continue.");
                            pauseForEnter();
                        }
                    }
                }
            }
        }
        
        return menuFlag;
    }

    public static List<Memo> getMatchingDates(List<Memo> memoList, ref List<Memo> matchingMemos, string userDate){
        foreach(Memo m in memoList){            
            if(m.date.Equals(userDate)){
                matchingMemos.Add(m);
            }                    
        }
        return matchingMemos;
    }

    public static bool viewMemoByTitleBL(ref List<Memo> memoList, ref bool menuFlag){
        string userInput = getUserInput();

        List<Memo> matchingMemos = new();

        if(userInput == "0"){
            menuFlag = false;
        } else {
            Console.Clear();
            Console.WriteLine($"Memos containing {userInput} in the title: \n");
            matchingMemos = getMatchingTitles(memoList, ref matchingMemos, userInput);
            Menu.displayMemoList(matchingMemos);
            
            if(matchingMemos.Count == 0){
                    Console.WriteLine($"No titles found containing \"{userInput}\".\nPress Enter to continue.\n");
                    pauseForEnter();
            }
        Console.WriteLine("\n 0.) Back to Main Menu\n \nPlease enter your selection below:\n");
        }
        if (userInput != "0" && matchingMemos.Count() != 0)
        {

            bool selecting = true;

            while (selecting)
            {
                userInput = getUserInput();
                if(userInput == "0"){
                    selecting = false;
                    menuFlag = false;
                } else if(matchingMemos.Count()>0) {
                    try{
                        int index = Convert.ToInt32(userInput);
                        if (index>0)
                        {
                            Memo m = matchingMemos[index-1];
                            Memo.displayMemo(m);
                            Menu.saveMenu(ref memoList, ref m);
                            selecting = false;
                            menuFlag = false;
                        }else {
                            Console.WriteLine("Invalid Respone. Please try again.");
                        }
                    } catch(Exception e) {
                        Console.WriteLine("Invalid Response. Please try again.");
                    }
                }
            }
        }
        return menuFlag;
    }

    public static List<Memo> getMatchingTitles(List<Memo> memoList, ref List<Memo> matchingMemos, string userInput){
        foreach(Memo m in memoList){            
            if(m.title.Contains(userInput)){
                matchingMemos.Add(m);
            }                    
        }
        return matchingMemos;
    }

    public static void pauseForEnter(){
        ConsoleKeyInfo key;
        do{key = Console.ReadKey();} while(key.Key != ConsoleKey.Enter);
    }

    public static bool saveMenuBL(ref List<Memo> memoList, ref Memo m, ref Memo mEdit, bool saveMenuFlag){

                int userInputInt = getIntUserInput(getUserInput());

                switch (userInputInt)
            {
                case 1: // Save and Return to Menu
                    Memo.saveMemo(memoList, ref m, mEdit);
                    saveMenuFlag = false;
                    break;
                case 2: // Edit message
                    Memo.displayMemo(mEdit);
                    Console.WriteLine("(Please enter your revised note below then press Enter:)");
                    string newMessage = getUserInput();
                    mEdit = Memo.editMemo(mEdit, newMessage);
                    break;
                case 3: // Delete Memo
                    Memo.deleteMemo(ref memoList, m);
                    saveMenuFlag = false;
                    break;
                case 0: // Discard message and Return to Menu
                    saveMenuFlag = false;
                    break;
                default:
                    Console.WriteLine("Invalid entry. Press Enter to continue");
                    pauseForEnter();
                    break;
            }
            

            return saveMenuFlag;
    }

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