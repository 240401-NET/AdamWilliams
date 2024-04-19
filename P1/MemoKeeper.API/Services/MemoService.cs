using MemoKeeper.Models;
using MemoKeeper.Data;
using System.Text.RegularExpressions;

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

    public Memo GetMemoById(int id)
    {
        return _memoRepo.GetMemoById(id);
    }

    public List<Memo> GetMemoByDate(string date)
    {
        //date = date.Trim();
        Regex exp = new Regex(@"^(1[0-2]|0?[1-9])(\/|-)(3[01]|[12][0-9]|0?[1-9])\2([0-9]{2})?[0-9]{2}$");
        if (exp.IsMatch(date))
        {
            return _memoRepo.GetMemoByDate(date);
        }
        throw new FormatException("Date must be dd/mm/yyyy or dd-mm-yyyy format.");
    }

    public Memo CreateNewMemo(Memo memo)
    {
        return _memoRepo.CreateNewMemo(memo);
    }

    public Memo EditMemo(int id, Memo editedMemo)
    {
        Memo updatedMemo = _memoRepo.EditMemo(id, editedMemo);
        return updatedMemo;
    }

    public void DeleteMemo(int id)
    {
        _memoRepo.DeleteMemo(id);
    }

    public void DeleteAllMemos()
    {
        _memoRepo.DeleteAllMemos();
    }
}