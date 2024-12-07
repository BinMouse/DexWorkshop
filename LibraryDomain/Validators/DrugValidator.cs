using FluentValidation;
using LibraryDomain.Primitives;
using LibraryDomain.Entities;

namespace LibraryDomain.Validators;

public class DrugValidator : AbstractValidator<Drug>
{
    public DrugValidator()
    {
        RuleFor(d => d.Name)
            .Length(2, 100).WithMessage(ValidationMessage.LenghtMessage)
            .Matches(@"[a-zA-Zа-яА-Я0-9\s]+").WithMessage(ValidationMessage.WrongCharacterMassege);
    }
}