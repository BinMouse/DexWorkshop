using LibraryDomain.ValueObjects;

namespace LibraryDomain.Entities;

/// <summary>
/// Лекарственный препарат
/// </summary>
public class Drug : BaseEntity
{
    /// <summary>
    /// Конструктор с внутренней инициализацией пустой коллекции связей с аптеками
    /// </summary>
    /// <param name="name">Имя препарата</param>
    /// <param name="manufacturer">Производитель</param>
    /// <param name="сountryсodeid">Код страны производителя</param>
    /// <param name="country">Ссылка на страну производителя</param>
    public Drug(string name, string manufacturer, string сountryсodeid, Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = сountryсodeid;
        Country = country;
        DrugItems = new List<DrugItem>();
    }
    
    /// <summary>
    /// Конструктор c передачей коллекции связей с аптеками
    /// <param name="name">Имя препарата</param>
    /// <param name="manufacturer">Производитель</param>
    /// <param name="сountryсodeid">Код страны производителя</param>
    /// <param name="country">Ссылка на страну производителя</param>
    /// <param name="drugItems">Список связей с аптеками</param>
    public Drug(string name, string manufacturer, string сountryсodeid, Country country, List<DrugItem> drugItems)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = сountryсodeid;
        Country = country;
        DrugItems = drugItems.Select(item => item).ToList();
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
    
    /// <summary>
    /// Страна-производитель
    /// </summary>
    public Country Country { get; private set; }
    
    /// <summary>
    /// Список связей между препаратом и аптеками
    /// </summary>
    public List<DrugItem> DrugItems { get; private set; }
}