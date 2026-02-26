namespace OurCheck.Persistence.Domain;

public class Appointment : EntityBase
{
    public Appointment() {}

    public Appointment(string? note, DateTimeOffset appointmentTime)
    {
        Note = note;
        AppointmentTime = appointmentTime;
    }
    
    public string? Note { get; set;}

    public DateTimeOffset AppointmentTime { get; set; }
    
    public Guid? SavedPlaceId { get; set; }

    public SavedPlace? SavedPlace { get; set; }
}