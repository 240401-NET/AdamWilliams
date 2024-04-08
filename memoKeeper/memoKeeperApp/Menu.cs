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
            printMainMenu();
            userInput = MenuBL.getUserInput();            
    
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
                    Console.Clear();
                    Console.WriteLine("Please enter a title for your memo:");
                    string title = MenuBL.getUserInput();
                    Console.WriteLine("Please enter a message for your memo:");
                    string message = MenuBL.getUserInput();
                    Memo newMemo = MemoManipulation.createMemo(title, message);
                    //display full memo with options
                    Console.Clear();
                    MemoManipulation.displayMemo(newMemo);
                    saveMenu(ref memoList, ref newMemo);
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

    public static void printMainMenu(){
        Console.Clear();
        Console.WriteLine("Memo Keeper\n");
        Console.WriteLine("1.) View all memo's.");
        Console.WriteLine("2.) View memo's from a specific date.");
        Console.WriteLine("3.) Search and view memo by title.");
        Console.WriteLine("4.) Write new memo.");
        Console.WriteLine("\n0.) Exit.");
        Console.WriteLine("\nPlease enter selection number.\n");
    }

    public static void displayAllMemos(ref List<Memo> memoList){
                
        bool menuFlag = true;

        while (menuFlag)
        {
            Console.Clear();
            if (memoList.Count()<1){
                Console.WriteLine("Empty List. No memos.");
            }

            displayMemoList(memoList);
            
            Console.WriteLine("\n 0.) Back.");
            Console.WriteLine("\n \nPlease enter selection number. \n");
    
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

    public static void displayMemoList(List<Memo> memos){
        int i = 1;
        foreach(Memo m in memos){
            if(m != null){
                Console.WriteLine($"{i}.) {m.title} - {m.date}");
            }
            i++;
        }
    }

    public static void saveMenu(ref List<Memo> memoList, ref Memo m){
        bool saveMenuFlag = true;
        Memo mEdit = new();
        mEdit.message = m.message;
        mEdit.date = m.date;
        mEdit.title = m.title; 
        while (saveMenuFlag)
        {
            Console.Clear();
            MemoManipulation.displayMemo(mEdit);
            Console.WriteLine("1.) Save and Return to Menu");
            Console.WriteLine("2.) Edit Message");
            Console.WriteLine("3.) Delete Memo");
            Console.WriteLine("\n0.) Discard changes and Return to Menu");
            Console.WriteLine("\n\nPlease enter selection number.\n");
            
            saveMenuFlag = MenuBL.saveMenuBL(ref memoList, ref m, ref mEdit, saveMenuFlag);
            
            
            
            
            
    
            
        }
       
    }

}