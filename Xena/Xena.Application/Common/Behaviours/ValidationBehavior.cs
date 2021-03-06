using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Xena.Application.Common.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
               where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var failures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(f => f != null)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                if (failures.Count != 0)
                {
                    throw new Exceptions.ValidationException(failures);
                }
            }
            return await next();
        }
    }
}