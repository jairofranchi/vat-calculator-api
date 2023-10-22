using System.Data;
using FluentValidation;
using VATCalculatorAPI.Models;

namespace VATCalculatorAPI.Validators
{
    public class PurchaseAmountValidator : AbstractValidator<PurchaseAmount>
    {
        public PurchaseAmountValidator()
        {
            RuleFor(p => p)
                .NotNull();

            RuleFor(p => p.VATRate)
                .Must(HaveVATRateAllowed)
                .WithMessage("Vat Rate must be 0.1, 0.13 or 0.2!");

            RuleFor(model => model)
                .Must(HaveOnlyOneAmountFilled)
                .WithMessage("Only one of GrossAmount, NetAmount, or VATAmount should be filled.");

            RuleFor(model => model.GrossAmount)
                .Must(BeValidDecimalAndNotZero).WithMessage("GrossAmount must be a valid decimal greater than 0.")
                .When(model => model.GrossAmount != null);

            RuleFor(model => model.NetAmount)
                .Must(BeValidDecimalAndNotZero).WithMessage("NetAmount must be a valid decimal greater than 0.")
                .When(model => model.NetAmount != null);

            RuleFor(model => model.VATAmount)
                .Must(BeValidDecimalAndNotZero).WithMessage("VATAmount must be a valid decimal greater than 0.")
                .When(model => model.VATAmount != null);
        }

        private bool BeValidDecimalAndNotZero(decimal? value) => 
            value.HasValue && decimal.TryParse(value.ToString(), out decimal result) && result > 0;

        private bool HaveOnlyOneAmountFilled(PurchaseAmount model)
        {
            var decimals = new[] { model.GrossAmount, model.NetAmount, model.VATAmount };
            var filledDecimals = decimals.Where(d => d.HasValue).ToList();

            return filledDecimals.Count == 1;
        }

        private bool HaveVATRateAllowed(decimal vatRate) => vatRate is (decimal)0.1 or (decimal)0.13 or (decimal)0.2;
    }
}