using Microsoft.AspNetCore.Mvc;
using urlShortener.Interfaces;

namespace urlShortener.Controller;

[Route("api/[controller]")]
[ApiController]
public class CreateShortenedUrlController: ControllerBase
{
    private readonly IUrlMapping _urlMappingRepository;
    
    public CreateShortenedUrlController(IUrlMapping urlMappingRepository)
    {
        _urlMappingRepository = urlMappingRepository;
    }
    [HttpPost("{longUrl}")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(404)]
    public IActionResult ShortenUrl(string longUrl)
    {
        try
        {
            string shortenedUrl = _urlMappingRepository.CreateShortenedUrl(Uri.UnescapeDataString(longUrl));
            return Ok(shortenedUrl);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}