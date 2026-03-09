using MediatR;
using OurCheck.Client.Application.Features.Appointment.Queries.List;
using OurCheck.Client.MAUI.ViewModels.Base;

namespace OurCheck.Client.MAUI.ViewModels;

public class HomeViewModel(ISender mediatr) : BasePageViewModel
{
    protected override async Task PageAppearingAsync()
    {
        await base.PageAppearingAsync();
        var appointmentDtos = await mediatr.Send(new ListAppointmentsQuery());
    }
}