

using ElevaEducacao.Domain.Core.Validators;
using FluentValidation.Results;
using System.Linq;

namespace ElevaEducacao.Domain.Core.Entities
{
    public abstract class DomainEntity : IDomainEntity
    {
        protected DomainEntity()
        {
            ValidationResult = new ValidationResult();
        }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            var validador = ValidatorHelper.GetFrom(GetType());
            var validationResult = validador.Validate(this);

            if (!validationResult.Errors.Any()) return ValidationResult.IsValid;
            foreach (var error in validationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }
        public void AddValidationError(string prop, string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(prop, message));
        }
    }

}
