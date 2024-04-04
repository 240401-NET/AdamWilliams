using System.Runtime.CompilerServices;

namespace memoKeeper;

public class MemoManipulation {

    //handle creating, editing, saving, and deleting memos

    public static Memo createMemo(List<Memo> memoList){
        Memo newMemo = new Memo();
        Console.Clear();
        //get a title and date and save them to newMemo
        Console.WriteLine("Please enter a title for you memo:");
        newMemo.title = Console.ReadLine();
        newMemo.date = DateTime.Now.ToShortDateString();
        newMemo.message = " ";
        Console.Clear();

        //display title, followed by date and an empty message, 
        //and then prompt for memo message
        displayMemo(newMemo);
        Console.WriteLine("\n");
        Console.WriteLine("(Please enter your note below then press Enter:)");
        newMemo.message = Console.ReadLine()  ?? " ";

        Console.Clear();
        displayMemo(newMemo);
        

        saveMenu(memoList, newMemo);
        if(newMemo != null){
            memoList.Add(newMemo);
        }
        return newMemo;
    }

    public static Memo editMemo(Memo m){

        displayMemo(m);
        Console.WriteLine("\n \n \n");
        Console.WriteLine("(Please enter your revised note below then press Enter:)");
        m.message = Console.ReadLine()  ?? " ";
        m.date = DateTime.Now.ToShortDateString();
        return m;

    }

    public static void saveMenu(List<Memo> memoList, Memo m){
        Console.WriteLine("\n \n");
        Console.WriteLine("1.) Save and Return to Menu");
        Console.WriteLine("2.) Edit Message");
        Console.WriteLine("3.) Delete Memo");
        Console.WriteLine("\n0.) Discard changes and Return to Menu");
        Console.WriteLine("\n\nPlease enter your selection.");
        
        //TODO: handle non-int and null inputs
        int userInput = Convert.ToInt32(Console.ReadLine());
        

        switch (userInput)
        {
            case 1: // Save and Return to Menu
                
                break;
            case 2: // Edit message
                editMemo(m);
                saveMenu(memoList,m);
                break;
            case 3: // Delete Memo
                if (memoList.Contains(m))
                {
                    deleteMemo(memoList, m);
                }
                break;
            case 0: // Discard message and Return to Menu
                m = null;
                break;
            default:
                Console.WriteLine("Invalid selection. Please try again.");
                saveMenu(memoList, m);
                break;
        }
       
    }

    public static void deleteMemo(List<Memo> memoList, Memo memo){
        memoList.Remove(memo);
    }

    public static void displayMemo(Memo m){
        int dashLengthTop = 0;
        if(m.title.Length+m.date.Length+4<m.message.Length+3){
            dashLengthTop = m.message.Length+3;
        }else{
            dashLengthTop = m.title.Length+m.date.Length+4;
        }
        Console.Clear();
        Console.Write(" ");
        for(int x=0; x <= m.title.Length+m.date.Length+4;x++){
            Console.Write("-");
        }
        Console.WriteLine($"\n| {m.title} - {m.date} |");
        Console.Write(" ");
        for(int x=0; x <= dashLengthTop;x++){
            Console.Write("-");
        }
        Console.Write("\n");
        Console.Write("|");
        for(int x=0; x <= m.message.Length+3;x++){
            Console.Write(" ");
        }
        Console.Write("|\n");
        Console.WriteLine($"|  {m.message}  |");
        Console.Write("|");
        for(int x=0; x <= m.message.Length+3;x++){
            Console.Write(" ");
        }
        Console.Write("|\n");
        Console.Write(" ");
        for(int x=0; x <= m.message.Length+3;x++){
            Console.Write("-");
        }
        Console.Write("\n \n");
    }

}