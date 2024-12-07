using FluentValidation;
using LibraryDomain.Entities;
using LibraryDomain.Primitives;

namespace LibraryDomain.Validators;

public class DrugItemValidator  : AbstractValidator<DrugItem>
{
    public DrugItemValidator()
    {
        RuleFor(di => di.Count)
            .LessThan(10000).WithMessage(ValidationMessage.TooManyCount);
        RuleFor(di => di.Cost)
            .Must(cost => Decimal.Round(cost, 2) == cost).WithMessage(ValidationMessage.OnlyTwoDecimal);
    }
}