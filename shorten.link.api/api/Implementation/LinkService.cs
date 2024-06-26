using api.DbContext;
using api.Extension;
using api.Entities;
using shorten.link.api.Implementation.Abstraction;

namespace shorten.link.api.Implementation;

public class LinkService : ILinkService
{
    private readonly IConfiguration _config;
    private readonly ShortenLinkDbContext _dbContext;

    public LinkService(
        IConfiguration config,
        ShortenLinkDbContext dbContext)
    {
        _config = config;
        _dbContext = dbContext;
    }

    public async Task<string> ShortenLinkAsync(string originalLink)
    {
        var redirectorServiceEndpoint = _config["RedirectorService"];
        var hash = originalLink.ToCRC32Hash().ToLower();

        await SaveShortenLinkAsync(
            redirectorServiceEndpoint ?? string.Empty,
            originalLink,
            hash);

        return $"{redirectorServiceEndpoint}/{hash}";
    }

    protected async Task SaveShortenLinkAsync(
        string redirectorServiceEndpoint,
        string originalLink,
        string hash)
    {
        if(IsExistedAsync(hash))
            return;

        await _dbContext.ShortenLinks.AddAsync(new ShortenLink
        {
            RedirectorEndpoint = redirectorServiceEndpoint ?? string.Empty,
            Hash = hash,
            OriginalLink = originalLink,
        });

        await _dbContext.SaveChangesAsync();
    }

    protected bool IsExistedAsync(string hash)
    {
        var predicate = (ShortenLink link) =>
        {
            return link.Hash.Equals(hash, StringComparison.CurrentCultureIgnoreCase);
        };

        return _dbContext.ShortenLinks.Any(predicate);
    }
}