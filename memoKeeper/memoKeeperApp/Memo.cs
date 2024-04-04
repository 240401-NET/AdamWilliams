namespace memoKeeper;

public class Memo{

    public string title{get;set;}
    public string date{get;set;}
    public string message{get;set;}

    public Memo() {}
    public Memo(string t, string d, string m, ref List<Memo> memoList) {
        title = t;
        date = d;
        message = m;
        AddToList(ref memoList, this);
    }

    private static List<Memo> AddToList(ref List<Memo> memoList, Memo m){
        memoList.Add(m);
        return memoList;
    }

}