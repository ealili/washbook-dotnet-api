namespace washbook_backend.DTOs;

public class MachineDto
{
    public int Id { get; set; }
    public required string Name  { get; set; }
    public required string Status { get; set; }
}