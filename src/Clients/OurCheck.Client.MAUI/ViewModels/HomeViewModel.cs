using System.Collections.ObjectModel;
using MediatR;
using OurCheck.Client.Application.Features.Appointment.Queries.List;
using OurCheck.Client.MAUI.ViewModels.Base;
using OurCheck.Dto.Appointment;

namespace OurCheck.Client.MAUI.ViewModels;

public class HomeViewModel(ISender mediatr) : BasePageViewModel
{
    public ObservableCollection<AppointmentDto> Appointments { get; } = new();

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        
        var appointmentDtos = await mediatr.Send(new ListAppointmentsQuery());
        Appointments.Clear();
        foreach (var appointment in appointmentDtos)
        {
            Appointments.Add(appointment);
        }
    }
}