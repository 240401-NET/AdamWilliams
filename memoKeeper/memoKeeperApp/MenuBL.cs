using System.Reflection.Metadata;
using System.Text;

namespace memoKeeper;

public class MenuBL(){
    public static bool displayAllMemosBL(ref List<Memo> memoList, ref bool menuFlag){
        int userInput = 0;
        
        try
        {
            
            
            userInput = Convert.ToInt32(Console.ReadLine());

            if(userInput > memoList.Count()){
                Console.WriteLine("\nInvalid selection. Please try again.\n");
            } else if(userInput <= memoList.Count() && userInput > 0){
                Memo m = memoList[userInput-1];
                MemoManipulation.displayMemo(m);
                MemoManipulation.saveMenu(ref memoList, ref m);
                menuFlag = false;       
            } else {
                menuFlag = false;
            }
        
        }
        catch (Exception e)
        {
            Console.WriteLine("\nInvalid entry. Please enter a number. Press Enter to continue.\n");
            Console.ReadLine();
            return menuFlag;
        }
        //Console.WriteLine(menuFlag);
        return menuFlag;
    }

    public static bool viewMemoByDateBL(ref List<Memo> memoList, ref bool menuFlag){

        try
        {
            string userDate = Menu.getUserInput();

            if (userDate == "0"){
                menuFlag = false;
            } else if (userDate != "0"){
                if(userDate.Length!=10) {
                    if(userDate.Length!=8 && userDate != "0"){
                        Console.WriteLine("Incorrect format. Please try again. Press Enter to continue");
                        Menu.getUserInput();
                    } 
                }
                List<Memo> matchingMemos = new();
                if(memoList.Count()>0){
                    matchingMemos = Menu.displayMatchingDates(memoList, ref matchingMemos, userDate);
                    if(matchingMemos.Count()==0){
                        Console.Clear();
                        Console.WriteLine("\n \nDate not found. Please try again. Press Enter to continue.\n \n");
                        Console.ReadLine();
                    }
                } else if(memoList.Count()==0){
                    Console.Clear();
                    Console.WriteLine("List is empty. Nothing to search.\n \nPress Enter to continue.");
                    Menu.getUserInput();                
                }  
                
                if (matchingMemos.Count()>0)
                {
                    Console.WriteLine("\n 0.) Back to Main Menu\n \nPlease enter your selection below:\n");
                    try
                    {
                        var userInput = Convert.ToInt32(Menu.getUserInput());
                        bool selecting = true;
    
                        while (selecting)
                        {
                            if (userInput>0 && matchingMemos.Count()>0)
                            {
                                Memo m = matchingMemos[userInput-1];
                                MemoManipulation.displayMemo(m);
                                MemoManipulation.saveMenu(ref memoList, ref m);
                                menuFlag = false;
                                selecting = false;
                            } else if(userInput == 0){
                                menuFlag = false;
                                selecting = false;
                            } else {
                                Console.WriteLine("Invalid Respone. Please try again. Press Enter to continue.");
                                Menu.getUserInput();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Please enter a valid selection. Press Enter to continue.");
                        Menu.getUserInput();
                    }
                }
            }
            
        }
        catch (Exception e)
        {
            return menuFlag;
        }
        return menuFlag;
    }

    public static bool viewMemoByTitleBL(ref List<Memo> memoList, ref bool menuFlag){
            string userInput = Menu.getUserInput();
            int i = 1;
            List<Memo> matchingMemos = new();
    
            if(userInput == "0"){
                menuFlag = false;
            } else {
                Console.Clear();
                Console.WriteLine($"Memos containing {userInput} in the title: \n");
                foreach(Memo m in memoList){
                    if(m.title.Contains(userInput)){
                        Console.WriteLine($"{i}.) {m.title} - {m.date}");
                        matchingMemos.Add(m);
                        i++;
                    }
                
                }
                if(matchingMemos.Count == 0){
                        Console.WriteLine($"No titles found containing \"{userInput}\".\nPress Enter to continue.\n");
                }
                Console.WriteLine("\n 0.) Back to search\n \nPlease enter your selection below:\n");
            }
            if (userInput == "0")
            {
    
                bool selecting = true;
    
                while (selecting)
                {
                    userInput = Menu.getUserInput();
                    if(userInput == "0"){
                        selecting = false;
                        // menuFlag = false;
                    } else if(matchingMemos.Count()>0) {
                        try{
                            int index = Convert.ToInt32(userInput);
                            if (index>0)
                            {
                                Memo m = matchingMemos[index-1];
                                MemoManipulation.displayMemo(m);
                                MemoManipulation.saveMenu(ref memoList, ref m);
                                selecting = false;
                            }else {
                                Console.WriteLine("Invalid Respone. Please try again.");
                            }
                        } catch(Exception e) {
                            Console.WriteLine("Invalid Response. Please try again.");
                        }
                    }
                }
            }
        return menuFlag;
    }



}