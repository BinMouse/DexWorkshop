using FluentValidation;
using LibraryDomain.Primitives;
using LibraryDomain.Entities;

namespace LibraryDomain.Validators;

/// <summary>
/// Валидатор для препаратов. Проверяет на соответсвие препарата ограничениям БД.
/// </summary>
public class DrugValidator : AbstractValidator<Drug>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public DrugValidator()
    {
        // Критерии валидации названия препарата
        RuleFor(d => d.Name)
            .Length(2, 100).WithMessage(ValidationMessage.LenghtRangeMessage)
            .Matches(@"[a-zA-Zа-яА-Я0-9\s]+").WithMessage(ValidationMessage.WrongCharacterMassege);
        
        // Критерии валидации названия производителя
        RuleFor(d => d.Manufacturer)
            .Length(2, 100).WithMessage(ValidationMessage.LenghtRangeMessage)
            .Matches(@"[a-zA-Zа-яА-Я0-9\s\-]+");
    }
}