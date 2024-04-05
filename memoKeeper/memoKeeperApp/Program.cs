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
        
        
        Menu.mainMenu(ref memoList);            

        
        //Tests:
            //|--> Creation of memo
            //|--> Appending to obj list
            //|--> editing message

        Data.PersistMemo(ref memoList);

    }

    
}