using Newtonsoft.Json;

namespace VATCalculatorAPI.Models;
public class PurchaseAmount
{
    public decimal? GrossAmount { get; set; }
    public decimal? NetAmount { get; set; }
    public decimal? VATAmount { get; set; }
    public decimal VATRate { get; set; }
}