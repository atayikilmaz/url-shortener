using urlShortener.Data;
using urlShortener.Interfaces;


namespace urlShortener.Repository;

public class UrlRepository: IUrlMapping
{
    private readonly AppDbContext _context;

    public UrlRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    public string GetShortenedUrl()
    {
        return _context.url_mappings.OrderBy(p => p.ShortenedUrl).ToString();
    }

    public string GetLongUrl()
    {
        throw new NotImplementedException();
    }
}