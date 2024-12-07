using Ardalis.GuardClauses;
using LibraryDomain.Primitives;

namespace LibraryDomain.Entities;

/// <summary>
/// Избранный препарат
/// </summary>
public class FavouriteDrug
{
    /*
     *  Поля -----------------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Идентификатор профиля пользователя
    /// </summary>
    public Guid ProfileId { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к профилю пользователя
    /// </summary>
    public Profile Profile { get; private set; } // nav
    
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public Guid DrugId { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к препарату
    /// </summary>
    public Drug Drug { get; private set; } // nav
    
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public Guid DrugStoreId { get; private set; } 
    
    /// <summary>
    /// Навигационное свойство к аптеке
    /// </summary>
    public DrugStore Store { get; private set; } // nav
    
    /*
     *  Конструкторы ---------------------------------------------------------------------------------------------------
     */
    
    public FavouriteDrug(Profile profile, Drug drug, DrugStore store)
    {
        try
        {
            Profile = Guard.Against.Null(profile, nameof(profile));
            Drug = Guard.Against.Null(drug, nameof(drug));
            Store = Guard.Against.Null(store, nameof(store));
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ValidationMessage.NullException);
            throw;
        }
        ProfileId = profile.Id;
        DrugId = drug.Id;
        DrugStoreId = store.Id;
    }

}