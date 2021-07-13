using FluentValidation;
using Xena.Application.Common.Exceptions;

namespace Xena.Application.Commands.Amazon.AdGroups.UpdateAdGroup
{
    public class UpdateAdGroupCommandValidator:AbstractValidator<UpdateAdGroupCommand>
    {
        public UpdateAdGroupCommandValidator()
        {
        }
    }
}