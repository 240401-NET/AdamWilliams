using System.Runtime.CompilerServices;

namespace memoKeeper;

public class MemoManipulation {

    //handle creating, editing, saving, and deleting memos

    public static void createMemo(ref List<Memo> memoList){
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
        

        saveMenu(ref memoList, ref newMemo);
        
    }

    public static Memo editMemo(ref Memo m){

        displayMemo(m);
        Console.WriteLine("\n \n \n");
        Console.WriteLine("(Please enter your revised note below then press Enter:)");
        m.message = Console.ReadLine()  ?? " ";
        m.date = DateTime.Now.ToShortDateString();
        return m;

    }

    public static void saveMenu(ref List<Memo> memoList, ref Memo m){
        bool saveMenuFlag = true;
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
                    }
                    break;
                case 2: // Edit message
                    m = editMemo(ref m);
                    break;
                case 3: // Delete Memo
                    if (memoList.Contains(m))
                    {
                        deleteMemo(ref memoList, m);
                    }
                    Menu.mainMenu(ref memoList);
                    break;
                case 0: // Discard message and Return to Menu
                    m = null;
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