using System.Runtime.CompilerServices;

namespace memoKeeper;

public class MemoManipulation {

    //handle creating, editing, saving, and deleting memos

    public static Memo createMemo(string title, string message){
        Memo newMemo = new Memo();

        newMemo.title = title;
        newMemo.date = DateTime.Now.ToShortDateString();
        newMemo.message = message;

        return newMemo;
        
    }

    public static Memo editMemo(ref Memo memo){

        displayMemo(memo);
        Console.WriteLine("\n \n \n");
        Console.WriteLine("(Please enter your revised note below then press Enter:)");
        //update the message and date
        memo.message = Console.ReadLine()  ?? " ";
        memo.date = DateTime.Now.ToShortDateString();
        displayMemo(memo);
        return memo;

    }

    public static void saveMenu(ref List<Memo> memoList, ref Memo m){
        bool saveMenuFlag = true;
        Memo mEdit = new();
        mEdit.message = m.message;
        mEdit.date = m.date;
        mEdit.title = m.title; 
        while (saveMenuFlag)
        {
            Console.WriteLine("\n \n");
            Console.WriteLine("1.) Save and Return to Menu");
            Console.WriteLine("2.) Edit Message");
            Console.WriteLine("3.) Delete Memo");
            Console.WriteLine("\n0.) Discard changes and Return to Menu");
            Console.WriteLine("\n\nPlease enter your selection.\n");
            
            
            
            
            //TODO: handle non-int and null inputs
            int userInput = Convert.ToInt32(Console.ReadLine());
            
            
    
            switch (userInput)
            {
                case 1: // Save and Return to Menu
                    Console.WriteLine(memoList.Contains(m));
                    if(m != null && !memoList.Contains(m)){
                        memoList.Add(m);
                    } else if(mEdit.title != m.title){
                        m.title = mEdit.title;                        
                    } else if (mEdit.date != m.date){
                        m.date = mEdit.date;
                    } else if (mEdit.message != m.message){
                        m.message = mEdit.message;
                    }
                    saveMenuFlag = false;
                    break;
                case 2: // Edit message
                    editMemo(ref mEdit);
                    break;
                case 3: // Delete Memo
                    if (memoList.Contains(m))
                    {
                        deleteMemo(ref memoList, m);
                    }
                    saveMenuFlag = false;
                    break;
                case 0: // Discard message and Return to Menu
                    saveMenuFlag = false;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
        }
        }
       
    }

    public static void deleteMemo(ref List<Memo> memoList, Memo memo){
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