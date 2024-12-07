using Ardalis.GuardClauses;
using LibraryDomain.Primitives;
using LibraryDomain.Validators;

namespace LibraryDomain.Entities;

/// <summary>
/// Страна
/// </summary>
public class Country : BaseEntity
{
    /*
     *  Поля -----------------------------------------------------------------------------------------------------------
     */

    /// <summary>
    /// Название страны
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Код страны
    /// </summary>
    public string Code { get; private set; }
    
    // Скрытый список для предотвращения модификации через методы 
    private readonly List<Drug> _drugs;
    
    /// <summary>
    /// Список препаратов
    /// </summary>
    public IReadOnlyCollection<Drug> Drugs => _drugs.AsReadOnly();
    
    /*
     *  Конструктор ----------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Конструктор с внутренней инициализацией пустой коллекции препаратов
    /// </summary>
    /// <param name="name">Название страны</param>
    /// <param name="code">Код страны</param>
    public Country(string name, string code)
    {
        try
        {
            Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
            Code = Guard.Against.NullOrWhiteSpace(code, nameof(code));
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(ValidationMessage.NullException);
            throw;
        }
        
        var validator = new CountryValidator();
        validator.Validate(this);
        
        _drugs = new List<Drug>();
    }
    
    /*
     *  Методы ---------------------------------------------------------------------------------------------------------
     */

    /// <summary>
    /// Добавить препарат в список производимых в стране
    /// </summary>
    /// <param name="drug">Препарат</param>
    /// <exception cref="Exception">Передан пустой объект</exception>
    public void AddDrug(Drug drug)
    {
        if (drug is null) throw new ArgumentNullException(nameof(drug));
        if (!_drugs.Contains(drug))
        {
            _drugs.Add(drug);
        }
    }
    
    /// <summary>
    /// Удалить препарат из списка производимых в стране
    /// </summary>
    /// <param name="drug">Препарат</param>
    /// <exception cref="Exception">Передан пустой объект</exception>
    public void RemoveDrug(Drug drug)
    {
        if (drug is null) throw new ArgumentNullException(nameof(drug));
        if (_drugs.Contains(drug))
        {
            _drugs.Remove(drug);
        }
    }
}