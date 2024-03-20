using urlShortener.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace urlShortener.Controller;

[Route("api/[controller]")]
[ApiController]
public class GetLongUrlController: ControllerBase
{
    private readonly IUrlMapping _urlMappingRepository;

    public GetLongUrlController(IUrlMapping urlMappingRepository)
    {
        _urlMappingRepository = urlMappingRepository;
    }

    [HttpGet("{shortenedUrl}")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(404)]
    public IActionResult GetLongUrl(string shortenedUrl)
    {
        try
        {
            string? longUrl = _urlMappingRepository.GetLongUrl(shortenedUrl);
            if (string.IsNullOrEmpty(longUrl))
                return NotFound();

            return Ok(longUrl);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}