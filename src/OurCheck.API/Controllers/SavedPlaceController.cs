using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OurCheck.API.Features.SavedPlace.Commands.Create;
using OurCheck.API.Features.SavedPlace.Commands.Delete;
using OurCheck.API.Features.SavedPlace.Commands.Update;
using OurCheck.API.Features.SavedPlace.Queries.Get;
using OurCheck.API.Features.SavedPlace.Queries.List;

namespace OurCheck.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SavedPlaceController(ISender mediatr) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetSavedPlaces()
    {
        var savedPlaces = await mediatr.Send(new ListSavedPlacesQuery());
        return TypedResults.Ok(savedPlaces);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetSavedPlaceById([FromRoute] Guid id)
    {
        var savedPlace = await mediatr.Send(new GetSavedPlaceQuery(id));
        if (savedPlace == null) return TypedResults.NotFound();
        return TypedResults.Ok(savedPlace);
    }

    [HttpPost]
    public async Task<IResult> CreateSavedPlace([FromBody] CreateSavedPlaceCommand command)
    {
        var savedPlaceId = await mediatr.Send(command);
        if (Guid.Empty == savedPlaceId) return Results.BadRequest();
        return TypedResults.Created($"{Request.Path}/{savedPlaceId}", new { id = savedPlaceId });
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteSavedPlace([FromRoute] Guid id)
    {
        await mediatr.Send(new DeleteSavedPlaceCommand(id));
        return Results.NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateSavedPlace([FromRoute] Guid id, [FromBody] CreateSavedPlaceCommand command)
    {
        await mediatr.Send(new UpdateSavedPlaceCommand(id, command.Name, command.Url));
        return Results.NoContent();
    }
}