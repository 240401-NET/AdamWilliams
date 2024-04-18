using System.ComponentModel.DataAnnotations;

namespace MemoKeeper.Models;

public class Memo
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Date { get; set; }
    public string? Message { get; set; }
}
