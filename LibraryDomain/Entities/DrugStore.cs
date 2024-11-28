using LibraryDomain.ValueObjects;

namespace LibraryDomain.Entities;
/// <summary>
/// Аптека
/// </summary>
public class DrugStore : BaseEntity
{
    /// <summary>
    /// Конструктор с внутренней инициализацией пустого списка препаратов
    /// </summary>
    /// <param name="drugNetwork">Сеть аптек</param>
    /// <param name="number">Номер аптеки в реестре</param>
    /// <param name="adress">Адрес аптеки</param>
    public DrugStore(string drugNetwork, int number, Adress adress)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Adress = adress;
        DrugItems = new List<DrugItem>();
    }
    
    /// <summary>
    /// Конструктор с внешней инициализацией списка препаратов
    /// </summary>
    /// <param name="drugNetwork">Сеть аптек</param>
    /// <param name="number">Номер аптеки в реестре</param>
    /// <param name="adress">Адрес аптеки</param>
    /// <param name="drugItems">Список препаратов, доступных в аптеке</param>
    public DrugStore(string drugNetwork, int number, Adress adress, List<DrugItem> drugItems)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Adress = adress;
        DrugItems = drugItems.Select(item => item).ToList();
    }
    
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
    
    /// <summary>
    /// Список препаратов, доступных в аптеке
    /// </summary>
    public List<DrugItem> DrugItems { get; private set; }
}