using urlShortener.Data;
using urlShortener.Interfaces;
using urlShortener.Models;
using urlShortener.Services;

namespace urlShortener.Repository;



public class UrlRepository: IUrlMapping
{
    private readonly AppDbContext _context;
    
    private readonly UrlShortenerService _urlShortenerService;

    public UrlRepository(AppDbContext context, UrlShortenerService urlShortenerService)
    {
        _context = context;
        _urlShortenerService = urlShortenerService;

    }
    
    
   

    public string? GetLongUrl(string shortenedUrl)
    {
        Console.WriteLine($"Aranıyor: {shortenedUrl}");
        var urlMapping = _context.url_mappings
            .FirstOrDefault(u => u.ShortenedUrl == shortenedUrl);

        if (urlMapping == null)
        {
            Console.WriteLine($"Uzun Url Bulunamadı: {shortenedUrl}");
        }
        else
        {
            Console.WriteLine($"Uzun Url Bulundu: {urlMapping.LongUrl}");
        }

        return urlMapping?.LongUrl;
    }

    public string CreateShortenedUrl(string longUrl)
    {
        string shortenedUrl = _urlShortenerService.GenerateShortenedUrl(longUrl);
        
        UrlMapping urlMapping = new UrlMapping
        {
            LongUrl = longUrl.ToString(),
            ShortenedUrl = shortenedUrl
        };
        Console.WriteLine(longUrl);
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