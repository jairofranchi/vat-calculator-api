namespace VATCalculatorAPI.DTOs;

public class PurchaseAmountRequest
{
    public decimal? GrossAmount { get; set; }
    public decimal? NetAmount { get; set; }
    public decimal? VATAmount { get; set; }
    public decimal VATRate { get; set; }
}