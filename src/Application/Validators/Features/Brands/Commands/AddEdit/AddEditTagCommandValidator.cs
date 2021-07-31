using NoNonense.Application.Features.Tags.Commands.AddEdit;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace NoNonense.Application.Validators.Features.Tags.Commands.AddEdit
{
    public class AddEditTagCommandValidator : AbstractValidator<AddEditTagCommand>
    {
        public AddEditTagCommandValidator(IStringLocalizer<AddEditTagCommandValidator> localizer)
        {
            RuleFor(request => request.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Name is required!"]);
            RuleFor(request => request.Description)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Description is required!"]);
            RuleFor(request => request.Tax)
                .GreaterThan(0).WithMessage(x => localizer["Tax must be greater than 0"]);
        }
    }
}