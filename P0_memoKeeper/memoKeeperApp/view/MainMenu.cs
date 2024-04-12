// using System.ComponentModel.DataAnnotations;
// using System.Linq.Expressions;
// using System.Text.RegularExpressions;

using System.Diagnostics;

namespace memoKeeper;

public class MainMenu{

    private int _menuSelection = -1;

    public void printMainMenu(){
        DisplayUtils.drawBanner();
        Console.WriteLine("1.) View all memo's.");
        Console.WriteLine("2.) View memo's from a specific date.");
        Console.WriteLine("3.) Search and view memo by title.");
        Console.WriteLine("4.) Write new memo.");
        Console.WriteLine("\n0.) Exit.");
        Console.Write("\nPlease enter selection number: ");
    }

    public void Execute(MemoController MemoControl){

        
       
               
        while (_menuSelection != 0)
        {
            printMainMenu();            
            _menuSelection = Validator.getIntUserInput(Validator.getUserInput());
            switch(_menuSelection)
            {
                case 1: //View all memos
                    DisplayAllMemoView displayAllMemoView = new();
                    displayAllMemoView.Execute(MemoControl);
                    break;
                
                case 2: //View list by date
                    MemoByDateView memoByDateView = new();
                    memoByDateView.Execute(MemoControl);
                    break;
                
                case 3: //Search and View by title
                    MemoByTitleView memoByTitleView = new();
                    memoByTitleView.Execute(MemoControl);
                    break;
                
                case 4: //Write a new memo
                    CreateMemoView createMemoView = new();
                    createMemoView.Execute(MemoControl);
                    break;
                
                case 0:
                    break;
                default:
                    Console.WriteLine("Entry not valid. Please try again.");
                    break;
    
            }
        }
    
    }





}