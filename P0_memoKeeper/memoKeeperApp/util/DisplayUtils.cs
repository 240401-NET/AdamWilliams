namespace memoKeeper;

class DisplayUtils{


    public static void drawBanner(){
            Console.Clear();
            Console.WriteLine(@"                                                   
   __  ___                 __ __                    
  /  |/  /__ __ _  ___    / //_/__ ___ ___  ___ ____
 / /|_/ / -_)  ' \/ _ \  / ,< / -_) -_) _ \/ -_) __/
/_/  /_/\__/_/_/_/\___/ /_/|_|\__/\__/ .__/\__/_/   
                                    /_/             ");
    }



    public static void displayMemoList(List<Memo> memos){
        int i = 1;
        foreach(Memo m in memos){
            if(m != null){
                Console.WriteLine($"{i}.) {m.Title} - {m.Date}");
            }
            i++;
        }
    }

    public static void displayMemo(Memo m){
        int chunkSize = 50;
        int dashLengthTop = 0;                                  //when drawing the dynamically sized 
        if(m.Title.Length+m.Date.Length+4<m.Message.Length+3){  //border this variable determines
            dashLengthTop = m.Message.Length+3;                 //the length of the line adjoining the
        }else{                                                  //Title box to the Message box.
            dashLengthTop = m.Title.Length+m.Date.Length+4;
        }
        drawBanner();                                        //draw dynamically sized border
        Console.Write(" ");                                     //|
        for(int x=0; x <= m.Title.Length+m.Date.Length+4;x++){  //|
            Console.Write("-");                                 //|
        }                                                       //|
        Console.WriteLine($"\n| {m.Title} - {m.Date} |");       //|
        Console.Write(" ");                                     //|
        for(int x=0; x <= (dashLengthTop>chunkSize?chunkSize:dashLengthTop);x++){                   //|
            Console.Write("-");                                 //|
        }                                                       //|
        Console.Write("\n");                                    //|
        Console.Write("|");                                     //|
        for(int x=0; x <= m.Message.Length+3;x++){              //|
            Console.Write(" ");                                 //|
        }                                                       //|
        Console.Write("|\n");
        
        if (m.Message.Length>chunkSize) {
            
            int stringLength = m.Message.Length;
            for (int i = 0; i < stringLength ; i += chunkSize)
            {
                if (i + chunkSize > stringLength) chunkSize = stringLength  - i;
                Console.WriteLine($"|    {m.Message.Substring(i, chunkSize)}    |");
            }
        }  else {
            Console.WriteLine($"|  {m.Message}  |");
            }                                                    //|
                                                                //|   Message in the middle
        Console.Write("|");                                     //|
        for(int x=0; x <= m.Message.Length+3;x++){              //|
            Console.Write(" ");                                 //|
        }                                                       //|
        Console.Write("|\n");                                   //|
        Console.Write(" ");                                     //|
        for(int x=0; x <= m.Message.Length+3;x++){              //|
            Console.Write("-");                                 //|______________________________
        }
        Console.Write("\n \n");
    }

    public static void pauseForEnter(){
        ConsoleKeyInfo key;
        do{key = Console.ReadKey();} while(key.Key != ConsoleKey.Enter);
    }
}