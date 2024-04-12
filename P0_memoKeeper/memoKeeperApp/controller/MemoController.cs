namespace memoKeeper;


public class MemoController{

    private List<Memo> _memoList;

    public MemoController(){
        _memoList = DataPersistanceUtil.LoadMemos();

    }


    public Memo createMemo(string title, string message){
        string _date = DateTime.Now.ToShortDateString();
        Memo newMemo = new Memo (title, _date, message);
        return newMemo;
        
    }

    public Memo editMemo(Memo memo, string newMessage){
        
        //update the message and date
        memo.Message = newMessage;
        memo.Date = DateTime.Now.ToShortDateString();
        return memo;

    }

    public bool deleteMemo(Memo memo){

        //if the memo exists, get rid of it, if not, nothing to do
        if (_memoList.Contains(memo))
        {
            bool memoRemoved = _memoList.Remove(memo);
            if (memoRemoved){
                DataPersistanceUtil.PersistMemos(_memoList);
            }
            return memoRemoved;
        } else{
            return true;
        }
        
    }

    public void saveMemo(Memo m, Memo mEdit){
        if(m != null && !_memoList.Contains(m)){//add the message to the list if it's new.
            _memoList.Add(m);
        } else if(mEdit.Title != m.Title){//Update the individual message properties if they have changed.
            m.Title = mEdit.Title;                        
        } else if (mEdit.Date != m.Date){
            m.Date = mEdit.Date;
        } else if (mEdit.Message != m.Message){
            m.Message = mEdit.Message;
        }

        DataPersistanceUtil.PersistMemos(_memoList);
    }

    public List<Memo> GetMemos(){
        return _memoList;
    }

}