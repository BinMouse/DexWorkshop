namespace LibraryDomain.Entities;

/// <summary>
/// Лекарственный препарат
/// </summary>
public class Drug : BaseEntity
{
    public Drug(string name, string manufacturer, string CountryCodeId)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = CountryCodeId;
    }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; private set; }
    
    public string Manufacturer { get; private set; }
    
    public string CountryCodeId { get; private set; }
}