namespace memoKeeper;

public class DisplayAllMemoView{

    private bool _menuFlag = true;

    public void displayAllMemos(MemoController memoControl, List<Memo> memoList){
                
        

        while (_menuFlag)
        {
            DisplayUtils.drawBanner();
            //if there are no saved memos, or if it is the first time running:
            if (memoList.Count()<1){
                Console.WriteLine("Empty List. No memos.");
            }

            DisplayUtils.displayMemoList(memoList);
            
            //append directions at the end of the list.
            Console.WriteLine("\n 0.) Back to Main Menu.");
            Console.Write("\n \nPlease enter selection number: ");
    
            displayAllMemosBL(memoControl, memoList);

        }
    }

    public bool displayAllMemosBL(MemoController memoControl, List<Memo> memoList){
        
        int userInput = Validator.getIntUserInput(Validator.getUserInput());
        
        if(userInput > memoList.Count() || userInput < 0){
            Console.WriteLine("\nInvalid selection. Please try again.\n");
            DisplayUtils.pauseForEnter();
        } else if(userInput <= memoList.Count() && userInput > 0){
            Memo m = memoList[userInput-1];
            DisplayUtils.displayMemo(m);
            SaveMenuView saveMenuView = new();
            saveMenuView.Execute(memoControl, m);
            _menuFlag = false;       
        } else if (userInput == 0) {
            _menuFlag = false;}
        
        return _menuFlag;
    }

    public void Execute(MemoController memoControl){

        List<Memo> memoList = memoControl.GetMemos();

        while (_menuFlag)
        {
            displayAllMemos(memoControl, memoList);
        }

    }
         


}

