using System.Net;
using System.Runtime.Serialization;

namespace memoKeeper;

class Program
{

    static void Main(string[] args){
        List<Memo> memoList;

        //load memoList from file, if none make assign to new list (?hashmap?)
        //temporarily initiate to empty list (persistance no implemented)
        memoList = new();
        Data.LoadMemos(ref memoList);

        bool inMenu = true;
        string userInput = "0";

        

        //start with Menu UI
            //Menu:
                //View memo list
                //  |-->select/view
                //      |-->edit-->save
                //      |-->delete
                //View memo by name
                //  |-->take input-->display memo
                //              |--> handle incorrect/non-existent case
                //      |-->edit-->save
                //      |-->delete
                //Create new Memo
                //  |-->save
                //  |-->discard
                //Exit(save changes)
        


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
                    Menu.viewMemoByTitle();
                    break;
                
                case "4": //Write a new memo
                    Memo newMemo = MemoManipulation.createMemo();
                    if(newMemo == null){
                        break;
                    } else{
                        memoList.Add(newMemo);
                    }
                    break;
                
                case "0":
                    inMenu = false;
                    break;
                default:
                    Console.WriteLine("Entry not valid. Please try again.");
                    break;


            }



        }
                
        //Need a memo class
            //|--> Store by name/title
            //|--> Date/Time
            //|--> Contents/Message
        
        //Need list (?hashmap?) of memo objects

        //Tests:
            //|--> Creation of memo
            //|--> Appending to obj list
            //|--> editing message

        Data.PersistMemo(ref memoList);

    }
}