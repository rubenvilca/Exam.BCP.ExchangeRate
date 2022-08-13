using BCP.ExchangeRate.Domain.ExchangeRate;
using FluentValidation;

namespace BCP.ExchangeRate.WebAPI.Validators
{
    public class PostExchangeRateValidator : AbstractValidator<PostExchangeRate>
    {
        public PostExchangeRateValidator()
        {
            RuleFor(x => x.OriginCurrency).NotEmpty().MaximumLength(3);
            RuleFor(x => x.DestinationCurrency).NotEmpty().MaximumLength(3);
            RuleFor(x => x.ExchangeRate).NotNull();
        }
    }
}