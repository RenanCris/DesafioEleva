using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ElevaEducacao.Domain.Core.Validators
{
    public static class ValidatorHelper
    {
        public static IValidator GetFrom(Type type)
        {
            var types = Assembly.GetAssembly(type).GetTypes();
            var validators = types.Where(x => x.GetInterface(nameof(IValidator)) != null);
            var t = validators.FirstOrDefault(x => x.BaseType != null && x.BaseType.GetGenericArguments().Contains(type));

            if (t == null)
                throw new ArgumentException($"Validator not found for {type.Name}");

            return (IValidator)Activator.CreateInstance(t);
        }
    }
}
