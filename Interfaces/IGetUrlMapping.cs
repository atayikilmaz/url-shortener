namespace urlShortener.Interfaces;

public interface IGetUrlMapping
{
   string? GetLongUrl(string shortenedUrl);
   
}