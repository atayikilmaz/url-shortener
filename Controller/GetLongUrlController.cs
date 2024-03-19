using urlShortener.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace urlShortener.Controller;

[Route("api/[controller]")]
[ApiController]
public class GetLongUrlController: ControllerBase
{
    private readonly IGetUrlMapping _getUrlMappingRepository;

    public GetLongUrlController(IGetUrlMapping getUrlMappingRepository)
    {
        _getUrlMappingRepository = getUrlMappingRepository;
    }

    [HttpGet("{shortenedUrl}")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(404)]
    public IActionResult GetLongUrl(string shortenedUrl)
    {
        try
        {
            string? longUrl = _getUrlMappingRepository.GetLongUrl(shortenedUrl);
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