using Microsoft.AspNetCore.Mvc;
using UnitConverter.Core.Interfaces;
using UnitConverter.Core.Models;
using System;

namespace UnitConverter.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ConversionsController : ControllerBase
{
    private readonly IConversionService _conversionService;

    public ConversionsController(IConversionService conversionService)
    {
        _conversionService = conversionService;
    }

    [HttpGet]
    public ActionResult<ConversionResponse> Get([FromQuery] decimal value, [FromQuery] string fromUnit, [FromQuery] string toUnit)
    {
        if (string.IsNullOrWhiteSpace(fromUnit) || string.IsNullOrWhiteSpace(toUnit))
        {
            return BadRequest("Both fromUnit and toUnit are required.");
        }

        try
        {
            var request = new ConversionRequest { Value = value, FromUnit = fromUnit, ToUnit = toUnit };
            return Ok(_conversionService.Convert(request));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}
