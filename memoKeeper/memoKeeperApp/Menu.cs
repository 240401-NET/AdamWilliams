// using System.ComponentModel.DataAnnotations;
// using System.Linq.Expressions;
// using System.Text.RegularExpressions;

using System.Diagnostics;

namespace memoKeeper;

public class Menu{
    public static void mainMenu(ref List<Memo> memoList){
        string userInput = "0";
        bool inMenu = true;
        

        
        while (inMenu)
        {
            Menu.printMenu();
            userInput = Console.ReadLine();
            
    
            switch(userInput)
            {
                case "1": //View all memos
                    Menu.displayAllMemos(ref memoList);
                    break;
                
                case "2": //View list by date
                    Menu.viewMemoByDate(ref memoList);
                    break;
                
                case "3": //Search and View by title
                    Menu.viewMemoByTitle(ref memoList);
                    break;
                
                case "4": //Write a new memo
                    MemoManipulation.createMemo(ref memoList);
                    break;
                
                case "0":
                    inMenu = false;
                    break;
                default:
                    Console.WriteLine("Entry not valid. Please try again.");
                    break;
    
        }
        }
    
    }

    public static void printMenu(){
        Console.Clear();
        Console.WriteLine("Memo Keeper\n \n \n");
        Console.WriteLine("1.) View all memo's.");
        Console.WriteLine("2.) View memo's from a specific date.");
        Console.WriteLine("3.) Search and view memo by title.");
        Console.WriteLine("4.) Write new memo.");
        Console.WriteLine("\n0.) Exit.");
        Console.WriteLine("\nPlease enter selection.\n");
    }

    public static void displayAllMemos(ref List<Memo> memoList){
        Console.Clear();
        
        bool menuFlag = true;

        while (menuFlag)
        {
            int i = 1;
            if (memoList.Count()<1){
                Console.WriteLine("Empty List. No memos.");
            }
    
            foreach(Memo m in memoList){
                if(m != null){
                    Console.WriteLine($"{i}.) {m.title} - {m.date}");
                }
                i++;
            } 
            Console.WriteLine("\n 0.) Back.");
            Console.WriteLine("\n \nPlease enter selection. \n");
    
            MenuBL.displayAllMemosBL(ref memoList, ref menuFlag);

        }
         


    }

    public static void viewMemoByDate(ref List<Memo> memoList){
        
        bool menuFlag = true;

        while (menuFlag)
        {            
            
            Console.Clear();
            Console.WriteLine("Search for Memo by date\n");
            Console.WriteLine("\n \n 0.) Back to Main Menu.\n");
            Console.WriteLine("Please enter the date of the memo's you wish to display"+
                                        $"(in the format dd/mm/yyyy not including leading 0's):\n");
            
        MenuBL.viewMemoByDateBL(ref memoList, ref menuFlag);
        
        }
        

    }

    public static List<Memo> displayMatchingDates(List<Memo> memoList, ref List<Memo> matchingMemos, string userDate){
        int i = 1;
        Console.Clear();
        Console.WriteLine($"Memos from {userDate}: \n");
        foreach(Memo m in memoList){            
            if(m.date.Equals(userDate)){
                Console.WriteLine($"{i}.) {m.title} - {m.date}");
                matchingMemos.Add(m);
                i++;
            }                    
        }

        return matchingMemos;
    }

    public static void viewMemoByTitle(ref List<Memo> memoList){
        bool menuFlag = true;
        
        while (menuFlag)
        {
            Console.Clear();
            Console.WriteLine("Please enter the title of the memo (case and space sensitive):");
            Console.WriteLine("\n \n 0.) Back to Main Menu.\n");
    
            MenuBL.viewMemoByTitleBL(ref memoList, ref menuFlag);
        }

    }

    public static string getUserInput(){
        return Console.ReadLine();
    }
}