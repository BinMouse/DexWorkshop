namespace LibraryDomain.ValueObjects;

public class Adress
{
    public Adress(string city, string street, string house)
    {
        Street = street;
        City = city;
        House = house;
    }
    
    public string City { get; private set; }
    public string Street { get; private set; }
    public string House { get; private set; }

    public override string ToString()
    {
        return $"{City}, {Street}, {House}";
    }
}