using Microsoft.AspNetCore.Mvc;
using server.Domain.Interfaces.Service;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class EnvelopeController : ControllerBase
{
    private readonly ILogger<EnvelopeController> _logger;
    public readonly IEnvelopeService _envelopeService;

    public EnvelopeController(ILogger<EnvelopeController> logger,IEnvelopeService envelopeService)
    {
        _envelopeService=envelopeService;
        _logger = logger;
    }

    [HttpPost(Name = "Create")]
    public async Task<ActionResult<EnvelopeModel>> CreateEnvelope([FromBody] CreateEnvelopeModel data)
    {
        EnvelopeModel envelope = await _envelopeService.Create(data);
        return envelope;
    }

    /*[HttpGet(Name = "envelopeState")]
    public IEnumerable<string> GetEnvelopeState()
    {
       return "state";
    }*/
}
