using FluentValidation;
using LibraryDomain.Primitives;
using LibraryDomain.ValueObjects;
    
namespace LibraryDomain.Validators;

public class AdressValidator : AbstractValidator<Adress>
{
    public AdressValidator()
    {
        RuleFor(a => a.Country)
            .Must(CountryValidator.IsValidCountryCode).WithMessage(ValidationMessage.WrongCountryCode);
    }
}