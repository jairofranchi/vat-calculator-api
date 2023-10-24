using VATCalculatorAPI.Models;

namespace VATCalculatorAPI.Services;
public class VATCalculatorService : IVATCalculatorService
{
    public PurchaseVATCalculated CalculateVAT(PurchaseAmount data)
    {
        var purchaseAmountDTO = new PurchaseVATCalculated();

        if (data.NetAmount is not null)
        {
            purchaseAmountDTO.NetAmount = data.NetAmount.Value;
            purchaseAmountDTO.VATAmount = data.NetAmount.Value * data.VATRate;
            purchaseAmountDTO.GrossAmount = purchaseAmountDTO.NetAmount + purchaseAmountDTO.VATAmount;
        }
        else if (data.GrossAmount is not null)
        {
            purchaseAmountDTO.GrossAmount = data.GrossAmount.Value;
            purchaseAmountDTO.NetAmount = data.GrossAmount.Value / (1 + data.VATRate);
            purchaseAmountDTO.VATAmount = purchaseAmountDTO.NetAmount * data.VATRate;
        }
        else
        {
            purchaseAmountDTO.VATAmount = data.VATAmount.Value;
            purchaseAmountDTO.NetAmount = data.VATAmount.Value / data.VATRate;
            purchaseAmountDTO.GrossAmount = purchaseAmountDTO.VATAmount + purchaseAmountDTO.NetAmount;
        }

        return purchaseAmountDTO;
    }
}