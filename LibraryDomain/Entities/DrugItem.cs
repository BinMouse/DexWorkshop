namespace LibraryDomain.Entities;

/// <summary>
/// Связь между препаратом и патекой.
/// </summary>
public class DrugItem : BaseEntity
{
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drug">Перпарат</param>
    /// <param name="store">Аптека</param>
    /// <param name="count">Количество препарата в аптеке</param>
    /// <param name="cost">Стоимость препарата в аптеке</param>
    public DrugItem(Drug drug, DrugStore store, int count, decimal cost)
    {
        Drug = drug;
        Store = store;
        Count = count;
        Cost = cost;
        DrugId = drug.Id;
        DrugStoreId = store.Id;
    }

    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public Guid DrugId  { get; private set; }
    
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public Guid DrugStoreId  { get; private set; }
    
    /// <summary>
    /// Стоимость препарата
    /// </summary>
    public decimal Cost { get; private set; }
    
    /// <summary>
    /// Количество препарата на складе
    /// </summary>
    public int Count { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к препарату
    /// </summary>
    public Drug Drug { get; private set; } // nav
    
    /// <summary>
    /// Навигационное свойство к аптеке
    /// </summary>
    public DrugStore Store { get; private set; } // nav
}