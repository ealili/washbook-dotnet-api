using System.ComponentModel.DataAnnotations;

namespace washbook_backend.Models;

public class Machine
{
    [Key] public int Id { get; set; }
    
    public string Name { get; set; }
    
    // TODO: Create machine status model and link to foreign key
    public string Status { get; set; }
}