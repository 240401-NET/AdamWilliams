using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace memoKeeper;

class Menu{
    public static void printMenu(){
        Console.WriteLine("\n \n \n");
        Console.WriteLine("1.) View all memo's.");
        Console.WriteLine("2.) View memo's from a specific date.");
        Console.WriteLine("3.) Search and view memo by title.");
        Console.WriteLine("4.) Write new memo.");
        Console.WriteLine("\n0.) Exit.");
        Console.WriteLine("\n \nPlease enter selection or type Esc to exit.");
    }

    public static void displayAllMemos(ref List<Memo> memoList){
        //Console.Clear();
        Console.WriteLine("\n \n \n");
        int i = 1;

        if (memoList.Count()<i){
            Console.WriteLine("Empty List. No memos.");
        }

        foreach(Memo m in memoList){
            try{
                Console.WriteLine($"{i}.) {m.title} - {m.date.Substring(0,8)}");
            } catch(Exception e){
                Console.WriteLine("Empty List. No memos.");
            }
            i++;
        } 
        Console.WriteLine("\n0.) Back.");
        Console.WriteLine("\n \nPlease enter selection. \n");

        int userInput = Convert.ToInt32(Console.ReadLine());
         
            if(userInput <= memoList.Count() && userInput > 0){
                MemoManipulation.displayMemo(memoList[userInput-1]);
            } else {
                return;
            }
        
        Console.ReadLine();
    }

    public static void viewMemoByDate(ref List<Memo> memoList){
        Console.Clear();
        Console.WriteLine("\n \n \nPlease enter the date of the memo's you wish to display"+
                            $"(in the format dd/mm/yyyy not including leading 0's):");
        Console.WriteLine("\n0.) Back.");
        Console.WriteLine("\n \nPlease enter selection or hit Esc to return to main menu.");

        string userDate = Console.ReadLine();
        while(userDate.Length!=10) {
            if(Convert.ToInt32(userDate[0]) == 0 || Convert.ToInt32(userDate[2]) == 0 || userDate.Length!=8){
            Console.WriteLine("Incorrect format. Please try again.");
            userDate = Console.ReadLine();
            } else if(userDate.Length == 8){
                break;
            }
        }
                
        
        if(memoList.Count()>0){
            foreach(Memo m in memoList){
                //Console.WriteLine(userDate.Equals(m.date));
                int i = 1;
                if(m.date.Equals(userDate)){
                    Console.WriteLine($"{i}.) {m.title} - {m.date}");
                }
                i++;
            }
        } else if(memoList.Count()==0){
            Console.WriteLine("List is empty. Nothing to search.");
            
        } else if(userDate == "0"){
            return;
        } else{
            Console.WriteLine("Date not found. Please try again.");
        }
        

    }

    public static void viewMemoByTitle(){
        Console.Clear();
        Console.WriteLine("\n \n \nPlease enter the title of the menu:");
    }

    public static string getUserInput(){
        return Console.ReadLine();
    }
}