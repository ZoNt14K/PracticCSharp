public class Command
{
    public string Description { get; set; }
    public DateTime Timestamp { get; set; }

    public Command(string description)
    {
        Description = description; 
        Timestamp = DateTime.Now;
    }
    
    public override string ToString()
    { 
        return $"[{Timestamp:HH:mm:ss}] {Description}";
    }
}
