using MemoKeeper.Models;
using MemoKeeper.Data;

namespace MemoKeeper.Services;

public class MemoService : IMemoService
{
    private readonly IRepository _memoRepo;
    
    public MemoService(IRepository repo)
    {
        _memoRepo = repo;
    }


    public IEnumerable<Memo> GetAllMemos()
    {
        return _memoRepo.GetAllMemos();
    }
    public Memo CreateNewMemo(Memo memo)
    {
        return _memoRepo.CreateNewMemo(memo);
    }

    public void DeleteMemo(int id)
    {
        _memoRepo.DeleteMemo(id);
    }

    public Memo EditMemo(int id, Memo editedMemo)
    {
        Memo updatedMemo = _memoRepo.EditMemo(id, editedMemo);
        return updatedMemo;
    }

    public void DeleteAllMemos()
    {
        _memoRepo.DeleteAllMemos();
    }
}