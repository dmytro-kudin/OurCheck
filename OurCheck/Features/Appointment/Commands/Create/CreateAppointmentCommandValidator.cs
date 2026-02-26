using FluentValidation;

namespace OurCheck.Features.Appointment.Commands.Create;

public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentCommandValidator()
    {
        RuleFor(p => p.Note).NotEmpty().MaximumLength(500);
        RuleFor(p => p.AppointmentTime).GreaterThan(DateTimeOffset.UtcNow);
    }
}