using System.Runtime.CompilerServices;

namespace memoKeeper;

class MemoManipulation {

    //handle creating, editing, saving, and deleting memos

    public static Memo createMemo(){
        Memo newMemo = new Memo();
        //Console.Clear();
        //get a title and date and save them to newMemo
        Console.WriteLine("Please enter a title for you memo:");
        newMemo.title = Console.ReadLine();
        newMemo.date = DateTime.Now.ToShortDateString();
        newMemo.message = " ";
        //Console.Clear();

        //display title, followed by date, and then prompt for memo message
        displayMemo(newMemo);
        Console.WriteLine("\n");
        Console.WriteLine("(Please enter your note below then press Enter:)");
        newMemo.message = Console.ReadLine()  ?? " ";

        //Console.Clear();

        saveMenu(newMemo);

        return newMemo;
    }

    public static Memo editMemo(Memo m){

        displayMemo(m);
        Console.WriteLine("\n \n \n");
        Console.WriteLine("(Please enter your revised note below then press Enter:)");
        m.message = Console.ReadLine()  ?? " ";
        return m;

    }

    private static void saveMenu(Memo m){
        Console.WriteLine("\n \n \n");
        Console.WriteLine("1.) Save and Return to Menu");
        Console.WriteLine("2.) Continue editing");
        Console.WriteLine("3.) Discard and Return to Menu");
        Console.WriteLine("\n\nPlease enter your selection.");
        
        int userInput = Convert.ToInt32(Console.ReadLine());

        switch (userInput)
        {
            case 1: // Save and Return to Menu
                break;
            case 2: // Edit message
                editMemo(m);
                break;
            case 3: // Discard message and Return to Menu
                m = null;
                break;
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
        Console.WriteLine("\n \n \n");
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