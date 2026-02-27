namespace OurCheck.Domain.Entities;

public class Appointment : EntityBase
{
    public Appointment()
    {
    }

    public Appointment(string? note, DateTimeOffset appointmentTime, Guid? savedPlaceId)
    {
        Note = note;
        AppointmentTime = appointmentTime;
        SavedPlaceId = savedPlaceId;
    }
    
    public string? Note { get; set;}

    public DateTimeOffset AppointmentTime { get; set; }
    
    public Guid? SavedPlaceId { get; set; }

    public SavedPlace? SavedPlace { get; set; }
}