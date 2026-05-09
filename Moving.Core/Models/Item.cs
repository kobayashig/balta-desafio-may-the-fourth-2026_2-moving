using System.ComponentModel.DataAnnotations;

namespace Moving.Core.Models;

public class Item
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    public int Box { get; set; }
}