namespace EventCommands.Models;
public class TodoItem
{
    public string Description { get; set; } = string.Empty;
    public string OwnerName { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
}
