using MediatR;
using shorten.link.api.Model;

namespace shorten.link.api.Link.Command;

public class ShortenLinkCommand : IRequest<ShortenLinkResponse>
{
    public string OriginalLink { get; set; } = string.Empty;
}