using LibraryDomain.ValueObjects;

namespace LibraryDomain.Entities;
/// <summary>
/// Аптека
/// </summary>
public class DrugStore : BaseEntity
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugNetwork">Сеть аптек</param>
    /// <param name="number">Номер аптеки в реестре</param>
    /// <param name="adress">Адрес аптеки</param>
    public DrugStore(string drugNetwork, int number, Adress adress)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Adress = adress;
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
}