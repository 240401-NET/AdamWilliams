using MemoKeeper.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoKeeper.Data;

public class MemoRepository : IRepository
{
    private readonly MemoDbContext _context;
    public MemoRepository(MemoDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Memo> GetAllMemos()
    {
        return _context.Memo;
    }
    public Memo CreateNewMemo(Memo memo)
    {
        memo.Date = DateTime.Now.ToShortDateString();
        _context.Memo.Add(memo);
        _context.SaveChanges();

        return memo;
    }
    public void DeleteMemo(int id)
    {
        Memo memo = GetMemoById(id);
        _context.Memo.Remove(memo);
        _context.SaveChanges();
    }

    public Memo GetMemoById(int id)
    {
        return _context.Memo.Find(id);
    }

    public Memo EditMemo(int id, Memo editedMemo)
    {
        Memo memo = GetMemoById(id);
        memo.Title = memo.Title.Equals(editedMemo.Title)?memo.Title:editedMemo.Title;
        memo.Date = memo.Date.Equals(editedMemo.Date)?memo.Date:DateTime.Now.ToShortDateString();
        memo.Message = memo.Message.Equals(editedMemo.Message)?memo.Message:editedMemo.Message;
        _context.SaveChanges();
        return memo;
    }

    public void DeleteAllMemos()
    {
        _context.Memo.ExecuteDelete();
    }
}