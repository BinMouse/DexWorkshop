using LibraryDomain.ValueObjects;

namespace LibraryDomain.Entities;

public class DrugStore : BaseEntity
{
    public DrugStore(string drugNetwork, int number, Adress adress)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Adress = adress;
    }
    
    public string DrugNetwork { get; private set; }
    public int Number { get; private set; }
    
    public Adress Adress { get; private set; }
}