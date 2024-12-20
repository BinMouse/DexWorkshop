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
    /// <param name="country">Ссылка на страну производителя</param>
    public Drug(string name, string manufacturer, Country country)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = country.Code;
        Country = country;
        _drugItems = new List<DrugItem>();
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
    public Country Country { get; private set; } // nav
    
    // Скрытый список связей, закрытый от внешних изменений
    private readonly List<DrugItem> _drugItems;

    /// <summary>
    /// Список связей между препаратом и аптеками
    /// </summary>
    public IReadOnlyCollection<DrugItem> DrugItems => _drugItems.AsReadOnly(); // nav

    
    /// <summary>
    /// Добавление связи с аптекой
    /// </summary>
    /// <param name="item">Сущность связи</param>
    /// <exception cref="ArgumentNullException">Передан пустой объект</exception>
    public void AddDrugItem(DrugItem item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (!_drugItems.Contains(item))
        {
            _drugItems.Add(item);
        }
    }
    
    /// <summary>
    /// Удаление связи с аптекой
    /// </summary>
    /// <param name="item">Сущность связи</param>
    /// <exception cref="ArgumentNullException">Передан пустой объект</exception>
    public void RemoveDrugItem(DrugItem item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (_drugItems.Contains(item))
        {
            _drugItems.Remove(item);
        } 
    }
}