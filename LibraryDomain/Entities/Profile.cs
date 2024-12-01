using LibraryDomain.ValueObjects;

namespace LibraryDomain.Entities;

/// <summary>
/// Профиль
/// </summary>
public class Profile : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    public Profile(string firstName, string lastName, string email)
    {
        Firstname = firstName;
        Lastname = lastName;
        Email = email;
        _favouriteDrugs = new List<FavouriteDrug>();
    }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Firstname { get; private set; }
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string Lastname { get; private set; }
    
    /// <summary>
    /// Электронная почта пользователя
    /// </summary>
    public string Email { get; private set; }

    private readonly List<FavouriteDrug> _favouriteDrugs;
    /// <summary>
    /// Список избранных препаратов
    /// </summary>
    public IReadOnlyCollection<FavouriteDrug> FavouriteDrugs => _favouriteDrugs.AsReadOnly();
    
    public Adress Adress { get; private set; }
    
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