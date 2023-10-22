using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VATCalculatorAPI.Models;
using VATCalculatorAPI.Services;

namespace VATCalculatorAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VATCalculatorController : ControllerBase
{
    private readonly ILogger<VATCalculatorController> _logger;
    private readonly IValidator<PurchaseAmount> _validator;
    private readonly IVATCalculatorService _purchaseService;

    public VATCalculatorController(
        ILogger<VATCalculatorController> logger,
        IValidator<PurchaseAmount> validator,
        IVATCalculatorService purchaseService)
    {
        _logger = logger;
        _validator = validator;
        _purchaseService = purchaseService;
    }

    [HttpPost("calculate-vat-austria")]
    public IActionResult CalculateVATAustria([FromBody] PurchaseAmount purchaseAmount)
    {
        var validationResult = _validator.Validate(purchaseAmount);
        if (validationResult.IsValid)
        {
            var calculatedVAT = _purchaseService.CalculateVAT(purchaseAmount);
            _logger.LogInformation($"VAT Calculations: { JsonSerializer.Serialize(calculatedVAT) }");

            return Ok(calculatedVAT);
        }
        else
        {
            _logger.LogError("Validation failed: {@ValidationResult}", validationResult);

            return BadRequest(validationResult.Errors);
        }
    }
}
