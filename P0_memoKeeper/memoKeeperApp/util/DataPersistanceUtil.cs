using System.IO;
using System.Text.Json;

namespace memoKeeper;

public class DataPersistanceUtil{
    //handle operations to save/load data to/from file

    public static List<Memo> LoadMemos(){

        try
        {
            string filePath = "./data/memoList.json";
            string jsonMemos = File.ReadAllText(filePath);
    
            List<Memo> memoList = JsonSerializer.Deserialize<List<Memo>>(jsonMemos);
            return memoList;
        }
        catch (Exception e)
        {
            
            Console.WriteLine("Memo list not found. First time execution. Creating new list.");
            Thread.Sleep(2000);
            return new List<Memo>();
        }

    }

    public static void PersistMemos(List<Memo> memoList){

            string jsonMemos = JsonSerializer.Serialize(memoList);
            string filePath = "./data/memoList.json";

            Console.WriteLine(jsonMemos);

            File.WriteAllText(filePath, jsonMemos);

    }
}