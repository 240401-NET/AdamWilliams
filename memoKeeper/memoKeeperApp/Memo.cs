namespace memoKeeper;

public class Memo{

    public string title{get;set;}
    public string date{get;set;}
    public string message{get;set;}

    public Memo() {}
    public Memo(string t, string d, string m) {
        title = t;
        date = d;
        message = m;
        // AddToList(ref memoList, this);
    }

    public static Memo createMemo(string title, string message){
        Memo newMemo = new Memo(title, DateTime.Now.ToShortDateString(), message);
        return newMemo;
        
    }

    public static Memo editMemo(Memo memo, string newMessage){
        
        //update the message and date
        memo.message = newMessage;
        memo.date = DateTime.Now.ToShortDateString();
        return memo;

    }

    public static void deleteMemo(ref List<Memo> memoList, Memo memo){

        //if the memo exists, get rid of it, if not, nothing to do
        if (memoList.Contains(memo))
        {
            memoList.Remove(memo);
        }
    }

    public static void displayMemo(Memo m){
 
        int dashLengthTop = 0;                                  //when drawing the dynamically sized 
        if(m.title.Length+m.date.Length+4<m.message.Length+3){  //border this variable determines
            dashLengthTop = m.message.Length+3;                 //the length of the line adjoining the
        }else{                                                  //title box to the message box.
            dashLengthTop = m.title.Length+m.date.Length+4;
        }
        Console.Clear();                                        //draw dynamically sized border
        Console.Write(" ");                                     //|
        for(int x=0; x <= m.title.Length+m.date.Length+4;x++){  //|
            Console.Write("-");                                 //|
        }                                                       //|
        Console.WriteLine($"\n| {m.title} - {m.date} |");       //|
        Console.Write(" ");                                     //|
        for(int x=0; x <= dashLengthTop;x++){                   //|
            Console.Write("-");                                 //|
        }                                                       //|
        Console.Write("\n");                                    //|
        Console.Write("|");                                     //|
        for(int x=0; x <= m.message.Length+3;x++){              //|
            Console.Write(" ");                                 //|
        }                                                       //|
        Console.Write("|\n");                                   //|
        Console.WriteLine($"|  {m.message}  |");                //|   message in the middle
        Console.Write("|");                                     //|
        for(int x=0; x <= m.message.Length+3;x++){              //|
            Console.Write(" ");                                 //|
        }                                                       //|
        Console.Write("|\n");                                   //|
        Console.Write(" ");                                     //|
        for(int x=0; x <= m.message.Length+3;x++){              //|
            Console.Write("-");                                 //|______________________________
        }
        Console.Write("\n \n");
    }

    public static void saveMemo(List<Memo> memoList, ref Memo m, Memo mEdit){
        if(m != null && !memoList.Contains(m)){//add the message to the list if it's new.
                        memoList.Add(m);
                    } else if(mEdit.title != m.title){//Update the individual message properties if they have changed.
                        m.title = mEdit.title;                        
                    } else if (mEdit.date != m.date){
                        m.date = mEdit.date;
                    } else if (mEdit.message != m.message){
                        m.message = mEdit.message;
                    }
    }
    // private static List<Memo> AddToList(ref List<Memo> memoList, Memo m){
    //     memoList.Add(m);
    //     return memoList;
    // }

}