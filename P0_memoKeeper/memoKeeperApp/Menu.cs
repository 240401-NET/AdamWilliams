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
                    Menu.drawBanner();
                    Console.WriteLine("Please enter a title for your memo:");
                    string title = MenuBL.getUserInput();
                    Console.WriteLine("Please enter a message for your memo:");
                    string message = MenuBL.getUserInput();
                    Memo newMemo = Memo.createMemo(title, message);
                    //display full memo with options
                    Console.Clear();
                    Memo.displayMemo(newMemo);
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
        drawBanner();
        Console.WriteLine("1.) View all memo's.");
        Console.WriteLine("2.) View memo's from a specific date.");
        Console.WriteLine("3.) Search and view memo by title.");
        Console.WriteLine("4.) Write new memo.");
        Console.WriteLine("\n0.) Exit.");
        Console.Write("\nPlease enter selection number: ");
    }

    public static void displayAllMemos(ref List<Memo> memoList){
                
        bool menuFlag = true;

        while (menuFlag)
        {
            drawBanner();
            //if there are no saved menus, or if it is the first time running:
            if (memoList.Count()<1){
                Console.WriteLine("Empty List. No memos.");
            }

            displayMemoList(memoList);
            
            //append directions at the end of the list.
            Console.WriteLine("\n 0.) Back to Main Menu.");
            Console.Write("\n \nPlease enter selection number: ");
    
            MenuBL.displayAllMemosBL(ref memoList, ref menuFlag);

        }
         


    }

    public static void viewMemoByDate(ref List<Memo> memoList){
        
        bool menuFlag = true;

        while (menuFlag)
        {            
            
            drawBanner();
            Console.WriteLine("Search for Memo by date\n");
            Console.WriteLine("\n \n 0.) Back to Main Menu.\n");
            Console.Write("Please enter the date of the memo's you wish to display"+
                                        $"(in the format dd/mm/yyyy not including leading 0's): ");
            
            MenuBL.viewMemoByDateBL(ref memoList, ref menuFlag);
        
        }
        

    }

    public static void viewMemoByTitle(ref List<Memo> memoList){
        bool menuFlag = true;
        
        while (menuFlag)
        {
           drawBanner();
            Console.WriteLine("Search for Memo by Title\n");
            Console.WriteLine("\n \n 0.) Back to Main Menu.\n");
            Console.Write("Please enter the title of the memo (case and space sensitive): ");
    
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
            drawBanner();
            Memo.displayMemo(mEdit);
            Console.WriteLine("1.) Save and Return to Menu");
            Console.WriteLine("2.) Edit Message");
            Console.WriteLine("3.) Delete Memo");
            Console.WriteLine("\n0.) Discard changes and Return to Menu");
            Console.Write("\n\nPlease enter selection number: ");
            
            saveMenuFlag = MenuBL.saveMenuBL(ref memoList, ref m, ref mEdit, saveMenuFlag);
            
        }
       
    }

    public static void drawBanner(){
            Console.Clear();
            Console.WriteLine(@"                                                   
   __  ___                 __ __                    
  /  |/  /__ __ _  ___    / //_/__ ___ ___  ___ ____
 / /|_/ / -_)  ' \/ _ \  / ,< / -_) -_) _ \/ -_) __/
/_/  /_/\__/_/_/_/\___/ /_/|_|\__/\__/ .__/\__/_/   
                                    /_/             ");
    }

}