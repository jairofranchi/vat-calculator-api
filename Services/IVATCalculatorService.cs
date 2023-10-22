using VATCalculatorAPI.Models;

namespace VATCalculatorAPI.Services
{
    public interface IVATCalculatorService
    {
        PurchaseVATCalculated CalculateVAT(PurchaseAmount data);
    }
}