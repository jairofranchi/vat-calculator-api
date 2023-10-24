namespace VATCalculatorAPI.Models;

public class PurchaseVATCalculated
{
    private decimal _grossAmount;
    private decimal _vatAmount;
    private decimal _netAmount;

    public decimal GrossAmount
    {
        get => Math.Round(_grossAmount, 2);
        set => _grossAmount = value;
    }

    public decimal NetAmount
    {
        get => Math.Round(_netAmount, 2);
        set => _netAmount = value;
    }

    public decimal VATAmount
    {
        get => Math.Round(_vatAmount, 2);
        set => _vatAmount = value;
    }
}