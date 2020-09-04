namespace ElevaEducacao.Domain.Core.Entities
{
    public abstract class Entity : Entity<int>
    {

    }
    public abstract class Entity<TPrimaryKey> : DomainEntity, IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }

}
