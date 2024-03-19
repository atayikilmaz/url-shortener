using urlShortener.Data;
using urlShortener.Interfaces;


namespace urlShortener.Repository;

public class GetUrlRepository: IGetUrlMapping
{
    private readonly AppDbContext _context;

    public GetUrlRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
   

    public string? GetLongUrl(string shortenedUrl)
    {
        Console.WriteLine($"Searching for shortened URL: {shortenedUrl}");
        var urlMapping = _context.url_mappings
            .FirstOrDefault(u => u.ShortenedUrl == shortenedUrl);

        if (urlMapping == null)
        {
            Console.WriteLine($"No URL mapping found for shortened URL: {shortenedUrl}");
        }
        else
        {
            Console.WriteLine($"Found long URL: {urlMapping.LongUrl}");
        }

        return urlMapping?.LongUrl;
    }
}