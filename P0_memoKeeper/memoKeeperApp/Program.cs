using System.Net;
using System.Runtime.Serialization;

namespace memoKeeper;

public class Program
{

    static void Main(string[] args){

        
        MemoController memoControl = new MemoController();
       
        //Run the Entry point for the program, the main menu
        MainMenu mainMenu = new();
        mainMenu.Execute(memoControl);          



    }

    
}