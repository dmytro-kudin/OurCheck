using FluentValidation;

namespace OurCheck.API.Features.Appointment.Commands.Create;

public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentCommandValidator()
    {
        RuleFor(appointmentCommand => appointmentCommand.Note).MaximumLength(500);
        RuleFor(appointmentCommand => appointmentCommand.AppointmentTime).GreaterThan(DateTimeOffset.UtcNow);
        When(appointmentCommand => appointmentCommand.Note == null,
            () => RuleFor(appointmentCommand => appointmentCommand.SavedPlaceId)
                .NotNull()
                .WithMessage("At least one of the fields is required: Note, SavedPlaceId"));
    }
}