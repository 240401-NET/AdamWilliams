namespace memoKeeper;


public class CreateMemoView{

    Memo newMemo = new();

    


    public void Execute(MemoController memoControl){

        List<Memo> memoList = memoControl.GetMemos();

        DisplayUtils.drawBanner();
        Console.WriteLine("Please enter a title for your memo:");
        string title = Validator.getUserInput();
        Console.WriteLine("\nPlease enter a message for your memo:");
        string message = Validator.getUserInput();

        newMemo = memoControl.createMemo(title, message);

        //display full memo with options
        DisplayUtils.displayMemo(newMemo);
        
        SaveMenuView saveMenuView = new SaveMenuView();
        saveMenuView.Execute(memoControl, newMemo);
    }


}