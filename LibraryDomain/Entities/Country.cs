namespace LibraryDomain.Entities;

/// <summary>
/// Страна
/// </summary>
public class Country : BaseEntity
{
    /// <summary>
    /// Конструктор с внутренней инициализацией пустой коллекции препаратов
    /// </summary>
    /// <param name="name">Название страны</param>
    /// <param name="code">Код страны</param>
    public Country(string name, string code)
    {
        Name = name;
        Code = code;
    }

    /// <summary>
    /// Название страны
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Код страны
    /// </summary>
    public string Code { get; private set; }
    
    /// <summary>
    /// Список препаратов
    /// </summary>
    private ICollection<Drug> Drugs { get; } = new List<Drug>();

    /// <summary>
    /// Добавить препарат в список производимых в стране
    /// </summary>
    /// <param name="drug">Препарат</param>
    /// <exception cref="Exception">Передан пустой объект</exception>
    public void AddDrug(Drug drug)
    {
        if (drug == null) throw new ArgumentNullException(nameof(drug));
        if (!Drugs.Contains(drug))
        {
            Drugs.Add(drug);
        }
    }
    
    /// <summary>
    /// Удалить препарат из списка производимых в стране
    /// </summary>
    /// <param name="drug">Препарат</param>
    /// <exception cref="Exception">Передан пустой объект</exception>
    public void RemoveDrug(Drug drug)
    {
        if (drug == null) throw new ArgumentNullException(nameof(drug));
        if (Drugs.Contains(drug))
        {
            Drugs.Remove(drug);
        }
    }
}