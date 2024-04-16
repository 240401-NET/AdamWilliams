using MemoKeeper.Models;

namespace MemoKeeper.Data;

public class MemoRepository
{
    private readonly MemoDbContext _context;
    public MemoRepository(MemoDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Memo> GetAllMemos()
    {
        return _context.Memo.ToList();
    }
    public Memo CreateNewMemo(Memo memo)
    {
        _context.Memo.Add(memo);
        _context.SaveChanges();

        return memo;
    }
}