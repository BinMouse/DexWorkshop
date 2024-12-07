using FluentValidation;
using LibraryDomain.Primitives;
using LibraryDomain.ValueObjects;
    
namespace LibraryDomain.Validators;

/// <summary>
/// Валидатор для адроеса. Проверяет соответсвие адреса ограничениям бизнесс-логики.
/// </summary>
public class AdressValidator : AbstractValidator<Adress>
{
    public AdressValidator()
    {
        RuleFor(a => a.Country)
            .Must(CountryValidator.IsValidCountryCode).WithMessage(ValidationMessage.WrongCountryCode);
    }
}