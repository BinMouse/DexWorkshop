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
    
    /// <summary>
    /// Список избранных препаратов
    /// </summary>
    public List<FavouriteDrug> FavouriteDrugs { get; private set; } = new();
    
    public Adress Adress { get; private set; }
}