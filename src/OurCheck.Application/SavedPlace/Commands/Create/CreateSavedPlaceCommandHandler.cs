using MediatR;
using OurCheck.Application.Repositories;

namespace OurCheck.Application.SavedPlace.Commands.Create;

public class CreateSavedPlaceCommandHandler(ISavedPlaceRepository savedPlaceRepository) : IRequestHandler<CreateSavedPlaceCommand, Guid>
{
    public async Task<Guid> Handle(CreateSavedPlaceCommand command, CancellationToken cancellationToken)
    {
        var savedPlace = new Domain.Entities.SavedPlace(command.Name, command.Url);
        await savedPlaceRepository.AddAsync(savedPlace);
        return savedPlace.Id;
    }
}