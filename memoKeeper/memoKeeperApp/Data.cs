using System.IO;
using System.Text.Json;

namespace memoKeeper;

class Data{
    //handle operations to save/load data to/from file

    public static void LoadMemos(ref List<Memo> memoList){

        try
        {
            string filePath = "memoList.json";
            string jsonMemos = File.ReadAllText(filePath);
    
            memoList = JsonSerializer.Deserialize<List<Memo>>(jsonMemos);
        }
        catch (Exception e)
        {
            
            Console.WriteLine("File not found. First time execution.");
        }

    }

    public static void PersistMemo(ref List<Memo> memoList){

            string jsonMemos = JsonSerializer.Serialize(memoList);
            string filePath = "memoList.json";

            Console.WriteLine(jsonMemos);

            File.WriteAllText(filePath, jsonMemos);

    }
}