using MediatR;
using OurCheck.Application.Repositories;

namespace OurCheck.Application.Appointment.Commands.Delete;

public class DeleteAppointmentCommandHandler(IAppointmentRepository appointmentRepository) : IRequestHandler<DeleteAppointmentCommand>
{
    public async Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        await appointmentRepository.DeleteAsync(request.Id);
    }
}