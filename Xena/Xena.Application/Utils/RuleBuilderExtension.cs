using FluentValidation;

namespace Xena.Application.Utils
{
    public static class RuleBuilderExtension
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 14)
        {
            var options = ruleBuilder
                .NotEmpty();
                // .MinimumLength(minimumLength).WithMessage(ErrorMessages.PasswordLength)
                // .Matches("[A-Z]").WithMessage(ErrorMessages.PasswordUppercaseLetter)
                // .Matches("[a-z]").WithMessage(ErrorMessages.PasswordLowercaseLetter)
                // .Matches("[0-9]").WithMessage(ErrorMessages.PasswordDigit)
                // .Matches("[^a-zA-Z0-9]").WithMessage(ErrorMessages.PasswordSpecialCharacter);
            return options;
        }        
    }
}