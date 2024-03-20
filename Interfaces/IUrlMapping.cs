namespace urlShortener.Interfaces;

public interface IUrlMapping
{
   string? GetLongUrl(string shortenedUrl);

   string? CreateShortenedUrl(string longUrl);
}