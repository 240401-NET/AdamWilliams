using System.Net;
using System.Runtime.Serialization;

namespace memoKeeper;

public class Program
{

    static void Main(string[] args){
        List<Memo> memoList;

        //load memoList from file, if none make assign to new list
        //maybe make into hashmap in the future if necessary
        memoList = new();
        Data.LoadMemos(ref memoList);

        bool inMenu = true;
        string userInput = "0";

        Console.Clear();

        

        /*start with Menu UI
            Menu:
                View memo list
                 |-->select/view
                     |-->edit-->save
                     |-->delete
                View memo by name/date
                 |-->take input-->display memo
                              |-->handle incorrect/non-existent case
                              |-->edit-->save
                              |-->delete
                Create new Memo
                 |-->save
                 |-->discard
                Exit(save changes)
        */
        


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
                    Memo newMemo = MemoManipulation.createMemo(memoList);
                    break;
                
                case "0":
                    inMenu = false;
                    break;
                default:
                    Console.WriteLine("Entry not valid. Please try again.");
                    break;


            }



        }
                



        //Tests:
            //|--> Creation of memo
            //|--> Appending to obj list
            //|--> editing message

        Data.PersistMemo(ref memoList);

    }
}