namespace memoKeeper;
    
    
public class SaveMenuView{

        private bool _saveMenuFlag = true;
        Memo mEdit = new();
 

    public void displaySaveMenu(){
        
            DisplayUtils.drawBanner();
            DisplayUtils.displayMemo(mEdit);
            Console.WriteLine("1.) Save and Return to Menu");
            Console.WriteLine("2.) Edit Message");
            Console.WriteLine("3.) Delete Memo");
            Console.WriteLine("\n0.) Discard changes and Return to Menu");
            Console.Write("\n\nPlease enter selection number: ");
            
    }
       
    

    public void Execute(MemoController memoControl, Memo m){

            List<Memo> memoList = memoControl.GetMemos();
            mEdit.Message = m.Message;
            mEdit.Date = m.Date;
            mEdit.Title = m.Title;

            int userInputInt = -1;

        while (_saveMenuFlag){

            displaySaveMenu();
            userInputInt = Validator.getIntUserInput(Validator.getUserInput());
            Console.WriteLine("entering save menu");

                switch (userInputInt)
            {
                case 1: // Save and Return to Menu
                    memoControl.saveMemo(m, mEdit);
                    _saveMenuFlag = false;
                    break;
                case 2: // Edit message
                    DisplayUtils.displayMemo(mEdit);
                    Console.WriteLine("(Please enter your revised note below then press Enter:)");
                    string newMessage = Validator.getUserInput();
                    mEdit = memoControl.editMemo(mEdit, newMessage);
                    break;
                case 3: // Delete Memo
                    bool deleted = memoControl.deleteMemo(m);
                    if (deleted){
                        Console.WriteLine("Memo deleted.");
                        Thread.Sleep(2000);
                    }
                    _saveMenuFlag = false;
                    break;
                case 0: // Discard message and Return to Menu
                    _saveMenuFlag = false;
                    break;
                default:
                    Console.WriteLine("Invalid entry. Press Enter to continue");
                    DisplayUtils.pauseForEnter();
                    break;
            }
            
        }
    }

}