namespace OurCheck.API.Persistence.Domain;

public class SavedPlace : EntityBase
{
    public SavedPlace() {}

    public SavedPlace(string name, string? url)
    {
        Name = name;
        Url = url;
    }
    
    public string Name { get; set;} = string.Empty;

    public string? Url { get; set; }
    
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}