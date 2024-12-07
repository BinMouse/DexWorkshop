using Ardalis.GuardClauses;
using LibraryDomain.Validators;

namespace LibraryDomain.ValueObjects;

/// <summary>
/// Адрес
/// </summary>
public class Adress : BaseValueObject
{
    /*
     *  Поля -----------------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; private set; }
    
    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; private set; }
    
    /// <summary>
    /// Дом
    /// </summary>
    public string House { get; private set; }
    
    /// <summary>
    /// Почтоый код
    /// </summary>
    public int PostalCode { get; private set; }
    
    /// <summary>
    /// Код страны
    /// </summary>
    public string Country { get; private set; }
    
    /*
     *  Конструктор ---------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="city">Город</param>
    /// <param name="street">Улица</param>
    /// <param name="house">Дом</param>
    public Adress(string city, string street, string house, int postalCode, string country)
    {
        Street = Guard.Against.NullOrWhiteSpace(city, nameof(city));
        City = Guard.Against.NullOrWhiteSpace(street, nameof(street));
        House = Guard.Against.NullOrWhiteSpace(house, nameof(house));
        PostalCode = Guard.Against.OutOfRange(postalCode, nameof(postalCode), 10000, 100000);
        Country = Guard.Against.NullOrWhiteSpace(country, nameof(country));

        var validator = new AdressValidator();
        validator.Validate(this);

    }
    
    /*
     *  Методы ---------------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Преобразование адреса в строку.
    /// </summary>
    /// <returns>Строка вида: "{Город}, {Улица}, {Дом}, {Почтовый код}, {ISO-код страны}"</returns>
    public override string ToString()
    {
        return $"{City}, {Street}, {House}, {PostalCode}, {Country}";
    }
}