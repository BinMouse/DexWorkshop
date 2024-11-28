using LibraryDomain.Entities;

namespace LibraryDomain.ValueObjects;

/// <summary>
/// Страна
/// </summary>
public class Country
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
        Drugs = new List<Drug>();
    }
    
    /// <summary>
    /// Конструктор c передачей коллекции препаратов
    /// </summary>
    /// <param name="name">Название страны</param>
    /// <param name="code">Код страны</param>
    /// <param name="drugs">Список препаратов</param>
    public Country(string name, string code, List<Drug> drugs)
    {
        Name = name;
        Code = code;
        Drugs = drugs.Select(drug => drug).ToList();
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
    public List<Drug> Drugs { get; private set; }
}