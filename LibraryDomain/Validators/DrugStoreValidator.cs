using FluentValidation;
using LibraryDomain.Entities;
using LibraryDomain.Primitives;

namespace LibraryDomain.Validators;
/// <summary>
/// Валидатор для аптеки. Проверяет соответсвие аптеки ограничениям бизнесс-логики.
/// </summary>
public class DrugStoreValidator : AbstractValidator<DrugStore>
{
    public DrugStoreValidator()
    {
        RuleFor(ds => ds.DrugNetwork)
            .Length(2, 100).WithMessage(ValidationMessage.LenghtRangeMessage);
    }
}