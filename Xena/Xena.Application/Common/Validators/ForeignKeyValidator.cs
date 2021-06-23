using System;
using FluentValidation.Validators;
using Xena.Application.Abstractions.Repositories;

namespace Xena.Application.Common.Validators
{
    public class ForeignKeyValidator<T> : PropertyValidator
    where T : class
    {
        private readonly IRepository<T> _repo;
        public ForeignKeyValidator(IRepository<T> repo)
        {
            _repo = repo;
        }
        protected override string GetDefaultMessageTemplate()
            => "{PropertyName} ({PropertyValue}) Not Found";

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var prop = context.PropertyValue;
            return _repo.GetAsync(prop).GetAwaiter().GetResult() != null;
        }
    }
}