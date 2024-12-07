namespace LibraryDomain.Primitives;

public static class ValidationMessage
{
    public const string LenghtMessage = "Поле {PropertyName} должно содержать от {MinLenght} до {MaxLenght} символов";
    public const string WrongCharacterMassege = "Поле {PropertyName} может содержать символы русского и латинского алфавита и пробелы";
}