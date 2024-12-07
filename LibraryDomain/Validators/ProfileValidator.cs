using FluentValidation;
using LibraryDomain.Entities;
using LibraryDomain.Primitives;

namespace LibraryDomain.Validators;

/// <summary>
/// Валидатор для профиля. Проверяет соответсвие профиля ограничениям бизнесс-логики.
/// </summary>
public class ProfileValidator : AbstractValidator<Profile>
{
    public ProfileValidator()
    {
        RuleFor(p => p.FirstName)
            .Length(0,20).WithMessage(ValidationMessage.LenghtRangeMessage)
            .Matches(@"^[A-ZА-Я][a-zа-яё]+$").WithMessage(ValidationMessage.WrongCharacterMassege);
        
        RuleFor(p => p.LastName)
            .Length(0,20).WithMessage(ValidationMessage.LenghtRangeMessage)
            .Matches(@"^[A-ZА-Я][a-zа-яё-]+$").WithMessage(ValidationMessage.WrongCharacterMassege);
        
        RuleFor(p => p.Email)
            .Length(0,20).WithMessage(ValidationMessage.LenghtRangeMessage)
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage(ValidationMessage.WrongCharacterMassege);
    }
}