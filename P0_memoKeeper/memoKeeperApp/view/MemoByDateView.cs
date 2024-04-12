using Microsoft.IdentityModel.Tokens;

namespace memoKeeper;


public class MemoByDateView{

    private bool _menuFlag = true;
    List<Memo> matchingMemos = new();
    public void viewMemoByDate(MemoController memoControl, List<Memo> memoList){
        
        

        while (_menuFlag)
        {            
            
            DisplayUtils.drawBanner();
            Console.WriteLine("Search for Memo by date\n");
            Console.WriteLine("\n \n 0.) Back to Main Menu.\n");
            Console.Write("Please enter the date of the memo's you wish to display"+
                                        $"(in the format dd/mm/yyyy not including leading 0's): ");
            
            viewMemoByDateBL(memoControl, memoList);
        
        }
        

    }

    public void viewMemoByDateBL(MemoController memoControl, List<Memo> memoList){

        string userDate = Validator.getUserInput();

        if (userDate == "0"){
            _menuFlag = false;
        } else if (userDate != "0"){
            if(userDate.Length!=10) {
                if(userDate.Length!=8 && userDate != "0"){
                    Console.WriteLine("Incorrect format. Please try again. Press Enter to continue");
                    DisplayUtils.pauseForEnter();
                } else {

                    if(memoList.Count()>0){
                        getMatchingDates(memoList, userDate);
                        if(matchingMemos.Count()==0){
                            Console.WriteLine("\n \nDate not found. Please try again. Press Enter to continue.\n \n");
                            DisplayUtils.pauseForEnter();
                        } else {
                            DisplayUtils.drawBanner();
                            Console.WriteLine($"Memos from {userDate}: \n");
                            DisplayUtils.displayMemoList(matchingMemos);
                        }
                    } else if(memoList.Count()==0){
                        DisplayUtils.drawBanner();
                        Console.WriteLine("List is empty. Nothing to search.\n \nPress Enter to continue.");
                        DisplayUtils.pauseForEnter();  
                    }
                    if (matchingMemos.Count()>0)
                    {
                        Console.WriteLine("\n 0.) Back to Main Menu\n \nPlease enter selection number below:\n");
                        try
                        {
                            var userInput = Validator.getIntUserInput(Validator.getUserInput());
                            bool selecting = true;
        
                            while (selecting)
                            {
                                if (userInput>0 && matchingMemos.Count()>0)
                                {
                                    Memo m = matchingMemos[userInput-1];
                                    DisplayUtils.displayMemo(m);
                                    SaveMenuView saveMenuView = new SaveMenuView();
                                    saveMenuView.Execute(memoControl, m);
                                    _menuFlag = false;
                                    selecting = false;
                                } else if(userInput == 0){
                                    _menuFlag = false;
                                    selecting = false;
                                } else {
                                    Console.WriteLine("Invalid Respone. Please try again. Press Enter to continue.");
                                    DisplayUtils.pauseForEnter();
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Please enter a valid selection. Press Enter to continue.");
                            DisplayUtils.pauseForEnter();
                        }
                    }
                }
            }
        }
        

    }

    public void getMatchingDates(List<Memo> memoList, string userDate){
        foreach(Memo m in memoList){            
            if(m.Date.Equals(userDate)){
                matchingMemos.Add(m);
            }                    
        }
    }

    public void Execute(MemoController memoControl){

        List<Memo> memoList = memoControl.GetMemos();

        viewMemoByDate(memoControl, memoList);

    }

}