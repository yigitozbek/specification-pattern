namespace API.Common.Entities;

public interface IEntity<TKey> : IEntityBase
    where TKey : struct
{
    TKey Id { get; set; }
}