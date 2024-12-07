using Ardalis.GuardClauses;
using LibraryDomain.Primitives;
using LibraryDomain.Validators;
using LibraryDomain.ValueObjects;

namespace LibraryDomain.Entities;

/// <summary>
/// Профиль
/// </summary>
public class Profile : BaseEntity
{
    /*
     *  Поля -----------------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string FirstName { get; private set; }
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; private set; }
    
    /// <summary>
    /// Электронная почта пользователя
    /// </summary>
    public string Email { get; private set; }

    private readonly List<FavouriteDrug> _favouriteDrugs;
    /// <summary>
    /// Список избранных препаратов
    /// </summary>
    public IReadOnlyCollection<FavouriteDrug> FavouriteDrugs => _favouriteDrugs.AsReadOnly();
    
    /// <summary>
    /// Адрес покупателя
    /// </summary>
    public Adress Adress { get; private set; }
    
    /*
     *  Конструкторы ---------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="email">Электронная почта</param>
    /// <param name="adress">Адрес</param>
    public Profile(string firstName, string lastName, string email, Adress adress)
    {
        try{
            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Adress = Guard.Against.Null(adress, nameof(adress));
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ValidationMessage.NullException);
            throw;
        }
        
        var validator = new ProfileValidator();
        validator.Validate(this);
        
        _favouriteDrugs = new List<FavouriteDrug>();
    }
    
    /*
     *  Методы ---------------------------------------------------------------------------------------------------------
     */

    /// <summary>
    /// Добавление препарата в избранное
    /// </summary>
    /// <param name="item">Сущность связи</param>
    /// <exception cref="ArgumentNullException">Передан пустой объект</exception>
    public void AddDrugItem(FavouriteDrug item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (!_favouriteDrugs.Contains(item))
        {
            _favouriteDrugs.Add(item);
        }
    }
    
    /// <summary>
    /// Удаление препарата из избранного
    /// </summary>
    /// <param name="item">Избранный препарат</param>
    /// <exception cref="ArgumentNullException">Передан пустой объект</exception>
    public void RemoveDrugItem(FavouriteDrug item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (_favouriteDrugs.Contains(item))
        {
            _favouriteDrugs.Remove(item);
        } 
    }
}