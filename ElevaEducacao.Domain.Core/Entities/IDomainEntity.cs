using FluentValidation.Results;

namespace ElevaEducacao.Domain.Core.Entities
{
    public interface IDomainEntity
    {
        ValidationResult ValidationResult { get; set; }
        bool IsValid();
        void AddValidationError(string prop, string message);
    }
}
