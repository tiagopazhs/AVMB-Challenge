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

    [HttpPost(Name = "envelope")]
    public async Task<ActionResult<EnvelopeModel>> CreateEnvelope()
    {
        EnvelopeModel envelope = await _envelopeService.Create();
        return envelope;
    }

    /*[HttpGet(Name = "envelopeState")]
    public IEnumerable<string> GetEnvelopeState()
    {
       return "state";
    }*/
}
