namespace washbook_backend.Exceptions.Machine;

public class MachineNotFoundException: Exception
{
    public MachineNotFoundException() : base("Machine not found.")
    {
    }
}