using MemoKeeper.Models;

namespace MemoKeeper.Data;

public interface IRepository
{
    IEnumerable<Memo> GetAllMemos();
    Memo CreateNewMemo(Memo memo);

    void DeleteMemo(int id);

    Memo EditMemo(int id, Memo editedMemo);

    void DeleteAllMemos();
}