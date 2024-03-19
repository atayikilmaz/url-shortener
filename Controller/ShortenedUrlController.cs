using urlShortener.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace urlShortener.Controller;

[Route("api/[controller]")]
[ApiController]
public class ShortenedUrlController: Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IUrlMapping _urlMappingRepository;

    public ShortenedUrlController(IUrlMapping urlMappingRepository)
    {
        _urlMappingRepository = urlMappingRepository;

    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(string))]
    public IActionResult GetShortenedUrl()
    {
        var shortenedUrl = _urlMappingRepository.GetShortenedUrl();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(shortenedUrl);
    }
}