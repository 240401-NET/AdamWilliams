using System.Net;
using System.Runtime.Serialization;

namespace memoKeeper;

public class Program
{

    static void Main(string[] args){
        List<Memo> memoList;

        //load memoList from json file, if none make assign to new list
        //maybe make into hashmap in the future if necessary
        memoList = new();
        Data.LoadMemos(ref memoList);
       
        Menu.mainMenu(ref memoList);            

        //save data to json file
        Data.PersistMemo(ref memoList);

    }

    
}