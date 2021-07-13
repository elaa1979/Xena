using FluentValidation;
using Xena.Application.Common.Exceptions;

namespace Xena.Application.Commands.Amazon.Profiles.UpdateProfile
{
    public class UpdateProfileCommandValidator:AbstractValidator<UpdateProfileCommand>
    {
        public UpdateProfileCommandValidator()
        {
        }
    }
}