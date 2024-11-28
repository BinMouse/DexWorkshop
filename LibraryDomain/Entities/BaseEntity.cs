namespace LibraryDomain.Entities;

/// <summary>
///  Базова сущность
/// </summary>
public class BaseEntity
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Время создания сущности
    /// </summary>
    public DateTime CreatedDate { get; set; }
    
    /// <summary>
    /// Проверка сущности на равенство. Принимает в себя любой объект. 
    /// </summary>
    /// <param name="obj">Референс для сравнения</param>
    /// <returns>True - если id сущностей равны, false - если нет. Если тип объекта не совпадает или передан null, возвращает false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }
        var id = ((BaseEntity)obj).Id;
        
        return id == Id;
    }

    
    // Скрытая логика сравнения сущностей. Позволяет делегировать ей сравнение сущностей по id без проверки типа (если известно, что тип other - BaseEntity).
    protected bool Equals(BaseEntity other)
    {
        return Id.Equals(other.Id);
    }
    
    
    /// <summary>
    /// Генерирует хэш-код сущности. Хэш-код предназначен для эффективной вставки и поиска в коллекциях, основанных на хэш-таблице. Хэш-код не является постоянным значением.
    /// Одинаковый хэш-код не гарантирует равенство объектов (сущностей), но одинаковые сущности гарантируют равенство их хэш-кодов. (https://learn.microsoft.com/ru-ru/dotnet/fundamentals/runtime-libraries/system-object-gethashcode)
    /// </summary>
    /// <returns>Хэш-код сущности</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Оператор проверки сущностей на равенство.
    /// </summary>
    /// <param name="left">Левая сущность выражения</param>
    /// <param name="right">Правая сущность выражения</param>
    /// <returns>true - если сущности равны и false - если нет</returns>
    public static bool operator ==(BaseEntity left, BaseEntity right)
    {
        if (left is null || right is null)
        {
            return false;
        }
        
        return left.Equals(right);
    }
    
    /// <summary>
    /// Оператор проверки сущностей на неравенство.
    /// </summary>
    /// <param name="left">Левая сущность выражения</param>
    /// <param name="right">Правая сущность выражения</param>
    /// <returns>false - если сущности равны и true - если нет</returns>
    public static bool operator !=(BaseEntity left, BaseEntity right)
    {
        if (left is null || right is null)
        {
            return false;
        }
        
        return !(left==right);
    }
}