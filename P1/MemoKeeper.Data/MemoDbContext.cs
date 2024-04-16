using Microsoft.EntityFrameworkCore;
using MemoKeeper.Models;

namespace MemoKeeper.Data;

public class MemoDbContext: DbContext 
{

    public MemoDbContext() : base() {}
    public MemoDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Memo> Memo { get; set; }

}
