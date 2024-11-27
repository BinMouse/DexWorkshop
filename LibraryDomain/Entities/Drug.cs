namespace LibraryDomain.Entities;

/// <summary>
/// Лекарственный препарат
/// </summary>
public class Drug : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Имя препарата</param>
    /// <param name="manufacturer">Производитель</param>
    /// <param name="CountryCodeId">Код страны производителя</param>
    public Drug(string name, string manufacturer, string CountryCodeId)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = CountryCodeId;
    }
    
    /// <summary>
    /// Имя препарата
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Производитель
    /// </summary>
    public string Manufacturer { get; private set; }
    
    /// <summary>
    /// Код страны производителя
    /// </summary>
    public string CountryCodeId { get; private set; }
}