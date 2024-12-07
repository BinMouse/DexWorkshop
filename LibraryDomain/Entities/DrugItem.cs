using Ardalis.GuardClauses;
using LibraryDomain.Primitives;
using LibraryDomain.Validators;

namespace LibraryDomain.Entities;

/// <summary>
/// Связь между препаратом и патекой.
/// </summary>
public class DrugItem : BaseEntity
{
    /*
     *  Поля -----------------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Идентификатор препарата
    /// </summary>
    public Guid DrugId  { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к препарату
    /// </summary>
    public Drug Drug { get; private set; } // nav
    
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public Guid DrugStoreId  { get; private set; }
    
    /// <summary>
    /// Навигационное свойство к аптеке
    /// </summary>
    public DrugStore Store { get; private set; } // nav
    
    /// <summary>
    /// Стоимость препарата
    /// </summary>
    public decimal Cost { get; private set; }
    
    /// <summary>
    /// Количество препарата на складе
    /// </summary>
    public int Count { get; private set; }
    
    /*
     *  Конструктор ----------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drug">Перпарат</param>
    /// <param name="store">Аптека</param>
    /// <param name="count">Количество препарата в аптеке</param>
    /// <param name="cost">Стоимость препарата в аптеке</param>
    public DrugItem(Drug drug, DrugStore store, int count, decimal cost)
    {
        try
        {
            Drug = Guard.Against.Null(drug, nameof(drug));
            Store = Guard.Against.Null(store, nameof(store));
            Count = Guard.Against.Negative(count, nameof(count));
            Cost = Guard.Against.NegativeOrZero(cost, nameof(cost));
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ValidationMessage.NullException);
            throw;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ValidationMessage.IncorrectDataInput);
            throw;
        }
        
        DrugId = drug.Id;
        DrugStoreId = store.Id;
        
        var validator = new DrugItemValidator();
        validator.Validate(this);
    }
}