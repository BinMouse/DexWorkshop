namespace LibraryDomain.Primitives;

public static class ValidationMessage
{
    public const string LenghtRangeMessage = "Поле {PropertyName} должно содержать от {MinLenght} до {MaxLenght} символов";
    public const string LenghtMessage = "Поле {PropertyName} должно содержать {Lenght} символов";
    public const string WrongCharacterMassege = "Поле {PropertyName} содержит недопустимые символы";
    public const string WrongCountryCode = "Страны с данным кодом страны не существует";
    public const string OnlyTwoDecimal = "Число может иметь только 2 цифры после запятой";
    public const string TooManyCount = "Максималько допустимое значение для поля {PropertyName} - {MaxCount}";
}