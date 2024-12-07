using Ardalis.GuardClauses;
using LibraryDomain.Validators;
using LibraryDomain.ValueObjects;

namespace LibraryDomain.Entities;
/// <summary>
/// Аптека
/// </summary>
public class DrugStore : BaseEntity
{
    /*
     *  Поля -----------------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Сеть аптек
    /// </summary>
    public string DrugNetwork { get; private set; }
    
    /// <summary>
    /// Номер аптеки в реестре
    /// </summary>
    public int Number { get; private set; }
    
    /// <summary>
    /// Адрес аптеки
    /// </summary>
    public Adress Adress { get; private set; }

    // Скрытый список связей
    private readonly List<DrugItem> _drugItems;

    /// <summary>
    /// Список препаратов, доступных в аптеке
    /// </summary>
    public IReadOnlyCollection<DrugItem> DrugItems  => _drugItems.AsReadOnly();
    
    /*
     *  Конструктор ----------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Конструктор с внутренней инициализацией пустого списка препаратов
    /// </summary>
    /// <param name="drugNetwork">Сеть аптек</param>
    /// <param name="number">Номер аптеки в реестре</param>
    /// <param name="adress">Адрес аптеки</param>
    public DrugStore(string drugNetwork, int number, Adress adress)
    {
        DrugNetwork = Guard.Against.NullOrWhiteSpace(drugNetwork, nameof(drugNetwork));
        Number = Guard.Against.NegativeOrZero(number, nameof(number));
        Adress = Guard.Against.Null(adress, nameof(adress));

        var validator = new DrugStoreValidator();
        validator.Validate(this);
        
        _drugItems = new List<DrugItem>();
    }
    
    /*
     *  Методы ---------------------------------------------------------------------------------------------------------
     */
    
    /// <summary>
    /// Добавление связи с препаратом
    /// </summary>
    /// <param name="item">Сущность связи</param>
    /// <exception cref="ArgumentNullException">Передан пустой объект</exception>
    public void AddDrugItem(DrugItem item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (!_drugItems.Contains(item))
        {
            _drugItems.Add(item);
        }
    }
    
    /// <summary>
    /// Удаление связи с препаратом
    /// </summary>
    /// <param name="item">Сущность связи</param>
    /// <exception cref="ArgumentNullException">Передан пустой объект</exception>
    public void RemoveDrugItem(DrugItem item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        if (_drugItems.Contains(item))
        {
            _drugItems.Remove(item);
        } 
    }
}