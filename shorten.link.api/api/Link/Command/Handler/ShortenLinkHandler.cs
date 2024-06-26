using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using shorten.link.api.Implementation.Abstraction;
using shorten.link.api.Link.Command;
using shorten.link.api.Model;

namespace api.Link.Command.Handler
{
    public class ShortenLinkHandler : IRequestHandler<ShortenLinkCommand, ShortenLinkResponse>
    {
        private readonly ILinkService _linkService;

        public ShortenLinkHandler(ILinkService linkService)
        {
            _linkService = linkService;
        }

        public async Task<ShortenLinkResponse> Handle(ShortenLinkCommand request, CancellationToken cancellationToken)
        {
            return new ShortenLinkResponse
            {
                ShortenLink = await _linkService.ShortenLinkAsync(request.OriginalLink)
            };
        }
    }
}