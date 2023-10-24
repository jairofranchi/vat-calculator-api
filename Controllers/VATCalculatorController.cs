using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VATCalculatorAPI.DTOs;
using VATCalculatorAPI.Services;

namespace VATCalculatorAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VATCalculatorController : ControllerBase
{
    private readonly ILogger<VATCalculatorController> _logger;
    private readonly IValidator<PurchaseAmountRequest> _validator;
    private readonly IVATCalculatorService _purchaseService;

    public VATCalculatorController(
        ILogger<VATCalculatorController> logger,
        IValidator<PurchaseAmountRequest> validator,
        IVATCalculatorService purchaseService)
    {
        _logger = logger;
        _validator = validator;
        _purchaseService = purchaseService;
    }

    [HttpPost("calculate-vat-austria")]
    public IActionResult CalculateVATAustria([FromBody] PurchaseAmountRequest purchaseAmountRequest)
    {
        var validationResult = _validator.Validate(purchaseAmountRequest);
        if (validationResult.IsValid)
        {
            var calculatedVAT = _purchaseService.CalculateVAT(purchaseAmountRequest);
            _logger.LogInformation($"VAT Calculations: {JsonConvert.SerializeObject(calculatedVAT)}");

            return Ok(calculatedVAT);
        }
        else
        {
            _logger.LogError("Validation failed: {@ValidationResult}", validationResult);

            return BadRequest(new { Message = "Validation failed", validationResult.Errors });
        }
    }
}
