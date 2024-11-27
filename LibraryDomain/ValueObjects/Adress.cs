namespace LibraryDomain.ValueObjects;

/// <summary>
/// Адрес
/// </summary>
public class Adress
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="city">Город</param>
    /// <param name="street">Улица</param>
    /// <param name="house">Дом</param>
    public Adress(string city, string street, string house)
    {
        Street = street;
        City = city;
        House = house;
    }
    
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
    /// Преобразование адреса в строку.
    /// </summary>
    /// <returns>Строка вида: "{Город}, {Улица}, {Дом}"</returns>
    public override string ToString()
    {
        return $"{City}, {Street}, {House}";
    }
}