using FluentValidation;

namespace OurCheck.Features.SavedPlace.Commands.Update;

public class UpdateSavedPlaceCommandValidator : AbstractValidator<UpdateSavedPlaceCommand>
{
    public UpdateSavedPlaceCommandValidator()
    {
        RuleFor(savedPlaceCommand => savedPlaceCommand.Name).NotEmpty().MaximumLength(50);
        RuleFor(savedPlaceCommand => savedPlaceCommand.Url).MaximumLength(500);
    }
}