using FluentValidation;
using Xena.Application.Common.Exceptions;

namespace Xena.Application.Commands.Amazon.Keywords.UpdateKeyword
{
    public class UpdateKeywordCommandValidator:AbstractValidator<UpdateKeywordCommand>
    {
        public UpdateKeywordCommandValidator()
        {
        }
    }
}