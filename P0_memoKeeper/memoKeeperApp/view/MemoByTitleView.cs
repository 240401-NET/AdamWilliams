namespace memoKeeper;


public class MemoByTitleView{

    private bool _menuFlag = true;
    public void viewMemoByTitle(List<Memo> memoList){
        
        
        
        DisplayUtils.drawBanner();
        Console.WriteLine("Search for Memo by Title\n");
        Console.WriteLine("\n \n 0.) Back to Main Menu.\n");
        Console.Write("Please enter the title of the memo (case and space sensitive): ");

    }

    public void viewMemoByTitleBL(MemoController memoControl, List<Memo> memoList){
        string userInput = Validator.getUserInput();

        List<Memo> matchingMemos = new();

        if(userInput == "0"){
            _menuFlag = false;
        } else {
            DisplayUtils.drawBanner();
            Console.WriteLine($"Memos containing {userInput} in the title: \n");
            matchingMemos = getMatchingTitles(memoList, ref matchingMemos, userInput);
            DisplayUtils.displayMemoList(matchingMemos);
            
            if(matchingMemos.Count == 0){
                    Console.WriteLine($"No titles found containing \"{userInput}\".\nPress Enter to continue.\n");
                    DisplayUtils.pauseForEnter();
            }
        Console.WriteLine("\n 0.) Back to Main Menu\n \nPlease enter your selection below:\n");
        }
        if (userInput != "0" && matchingMemos.Count() != 0)
        {

            bool selecting = true;

            while (selecting)
            {
                userInput = Validator.getUserInput();
                if(userInput == "0"){
                    selecting = false;
                    _menuFlag = false;
                } else if(matchingMemos.Count()>0) {
                    try{
                        int index = Convert.ToInt32(userInput);
                        if (index>0)
                        {
                            Memo m = matchingMemos[index-1];
                            DisplayUtils.displayMemo(m);
                            SaveMenuView saveMenuView = new();
                            saveMenuView.Execute(memoControl, m);
                            selecting = false;
                            _menuFlag = false;
                        }else {
                            Console.WriteLine("Invalid Respone. Please try again.");
                        }
                    } catch(Exception e) {
                        Console.WriteLine("Invalid Response. Please try again.");
                    }
                }
            }
        }
    }

    public static List<Memo> getMatchingTitles(List<Memo> memoList, ref List<Memo> matchingMemos, string userInput){
        foreach(Memo m in memoList){            
            if(m.Title.Contains(userInput)){
                matchingMemos.Add(m);
            }                    
        }
        return matchingMemos;
    }

    public void Execute(MemoController memoControl){

        List<Memo> memoList = memoControl.GetMemos();

        while (_menuFlag)
        {
            viewMemoByTitle(memoList);
            viewMemoByTitleBL(memoControl, memoList);
        }
    
    }
}