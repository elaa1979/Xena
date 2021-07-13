using FluentValidation;
using Xena.Application.Common.Exceptions;

namespace Xena.Application.Commands.Amazon.Campaigns.UpdateCampaign
{
    public class UpdateCampaignCommandValidator:AbstractValidator<UpdateCampaignCommand>
    {
        public UpdateCampaignCommandValidator()
        {
        }
    }
}