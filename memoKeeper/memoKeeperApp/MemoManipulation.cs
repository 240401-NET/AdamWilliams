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

    public static Memo editMemo(Memo memo, string newMessage){

        
        //update the message and date
        memo.message = newMessage;
        memo.date = DateTime.Now.ToShortDateString();
        return memo;

    }

    public static void deleteMemo(ref List<Memo> memoList, Memo memo){
        if (memoList.Contains(memo))
        {
            memoList.Remove(memo);
        }
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

    public static void saveMemo(List<Memo> memoList, ref Memo m, Memo mEdit){
        if(m != null && !memoList.Contains(m)){
                        memoList.Add(m);
                    } else if(mEdit.title != m.title){
                        m.title = mEdit.title;                        
                    } else if (mEdit.date != m.date){
                        m.date = mEdit.date;
                    } else if (mEdit.message != m.message){
                        m.message = mEdit.message;
                    }
    }

}