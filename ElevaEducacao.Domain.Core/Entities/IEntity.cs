namespace ElevaEducacao.Domain.Core.Entities
{

    public interface IEntity<TPrimaryKey> :  IDomainEntity
    {
        TPrimaryKey Id { get; set; }
    }

}
