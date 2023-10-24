using VATCalculatorAPI.Models;
using VATCalculatorAPI.DTOs;

namespace VATCalculatorAPI.Services;

public interface IVATCalculatorService
{
    PurchaseVATCalculated CalculateVAT(PurchaseAmountRequest data);
}