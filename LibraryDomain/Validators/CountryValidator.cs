using System.Globalization;
using FluentValidation;
using LibraryDomain.Entities;
using LibraryDomain.Primitives;

namespace LibraryDomain.Validators;

/// <summary>
/// Валидатор для страны.  Проверяет оответсвие страны ограничениям бизнесс-логики.
/// </summary>
public class CountryValidator : AbstractValidator<Country>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public CountryValidator()
    {   
        // Критерии валидации названия страны
        RuleFor(country => country.Name)
            .Length(2, 100).WithMessage(ValidationMessage.LenghtRangeMessage)
            .Matches(@"[а-яА-Я\s]+").WithMessage(ValidationMessage.WrongCharacterMassege);
        
        // Критерии валидации кода страны
        RuleFor(c => c.Code)
            .Length(2).WithMessage(ValidationMessage.LenghtMessage)
            .Matches(@"[A-Z]").WithMessage(ValidationMessage.WrongCharacterMassege)
            .Must(IsValidCountryCode).WithMessage(ValidationMessage.WrongCountryCode);
    }
    
    /// <summary>
    /// Проверка кода страны на существование
    /// </summary>
    /// <param name="countryCode">Код страны</param>
    /// <returns>Существует ли страна с данным кодом</returns>
    public static bool IsValidCountryCode(string countryCode)
    {
        try
        {
            var region = new RegionInfo(countryCode);
            return true;
        }
        catch
        {
            return false;
        }
    }
}