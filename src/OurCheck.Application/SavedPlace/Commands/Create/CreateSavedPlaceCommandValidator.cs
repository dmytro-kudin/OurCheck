using FluentValidation;

namespace OurCheck.Application.SavedPlace.Commands.Create;

public class CreateSavedPlaceCommandValidator : AbstractValidator<CreateSavedPlaceCommand>
{
    public CreateSavedPlaceCommandValidator()
    {
        RuleFor(savedPlaceCommand => savedPlaceCommand.Name).NotEmpty().MaximumLength(50);
        RuleFor(savedPlaceCommand => savedPlaceCommand.Url).MaximumLength(500);
    }
}