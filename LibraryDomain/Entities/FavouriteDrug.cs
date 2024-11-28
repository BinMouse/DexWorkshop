namespace LibraryDomain.Entities;

/// <summary>
/// Избранный препарат
/// </summary>
public class FavouriteDrug
{
    public FavouriteDrug(Profile profile, Drug drug, DrugStore store)
    {
        Profile = profile;
        Drug = drug;
        Store = store;
        ProfileId = profile.Id;
        DrugId = drug.Id;
        DrugStoreId = store.Id;
    }

    /// <summary>
    /// Идентификатор профиля пользователя
    /// </summary>
    public Guid ProfileId { get; private set; }
    
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public Guid DrugId { get; private set; }
    
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public Guid DrugStoreId { get; private set; } 
    
    /// <summary>
    /// Навигационное свойство к профилю пользователя
    /// </summary>
    public Profile Profile { get; private set; } // nav
    
    /// <summary>
    /// Навигационное свойство к препарату
    /// </summary>
    public Drug Drug { get; private set; } // nav
    
    /// <summary>
    /// Навигационное свойство к аптеке
    /// </summary>
    public DrugStore Store { get; private set; } // nav
}