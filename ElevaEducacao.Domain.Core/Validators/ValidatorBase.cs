using ElevaEducacao.Domain.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElevaEducacao.Domain.Core.Validators
{
    public abstract class ValidatorBase<TEntity>: AbstractValidator<TEntity> where TEntity : Entity
    {
        public ValidatorBase()
        {
            ToValidate();
        }

        public abstract void ToValidate();
    }
}
