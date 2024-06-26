using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using shorten.link.api.Link.Command;
using shorten.link.api.Model;

namespace shorten.link.api.Endpoint;

public static class LinkEndpoints
{
    public static WebApplication MapLinkEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/link");

        root.MapPost("/shorten", ShortenLinkAsync);
        
        return app;
    }

    public static async Task<ShortenLinkResponse> ShortenLinkAsync(
        [FromServices] IMediator mediator,
        [FromBody] ShortenLinkCommand command)
    {
        var result = await mediator.Send(command);
        return result;
    }
}