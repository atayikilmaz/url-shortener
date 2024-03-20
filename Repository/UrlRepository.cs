using urlShortener.Data;
using urlShortener.Interfaces;
using urlShortener.Models;
using urlShortener.Services;

namespace urlShortener.Repository;



public class UrlRepository: IUrlMapping
{
    private readonly AppDbContext _context;
    
    private readonly UrlShortenerService _urlShortenerService;

    public UrlRepository(AppDbContext context)
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

    public string CreateShortenedUrl(string longUrl)
    {
        string shortenedUrl = _urlShortenerService.GenerateShortenedUrl(longUrl);
        
        UrlMapping urlMapping = new UrlMapping
        {
            LongUrl = longUrl,
            ShortenedUrl = shortenedUrl
        };
        
        _context.url_mappings.Add(urlMapping);
        
        try
        {
            _context.SaveChanges();
            Console.WriteLine("Yeni Url Başarıyla Eklendi.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Url Eklenirken Hata Meydana Geldi: {ex.Message}");
        }

        return shortenedUrl;


    }
}