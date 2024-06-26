namespace shorten.link.api.Implementation.Abstraction;

public interface ILinkService
{
    Task<string> ShortenLinkAsync(string originalLink);
}