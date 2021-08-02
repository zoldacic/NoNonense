using NowWhat.Application.Features.Notes.Commands.AddEdit;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace NowWhat.Application.Validators.Features.Notes.Commands.AddEdit
{
    public class AddEditNoteCommandValidator : AbstractValidator<AddEditNoteCommand>
    {
        public AddEditNoteCommandValidator(IStringLocalizer<AddEditNoteCommandValidator> localizer)
        {
            RuleFor(request => request.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Name is required!"]);
            RuleFor(request => request.Barcode)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Barcode is required!"]);
            RuleFor(request => request.Description)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(x => localizer["Description is required!"]);
            RuleFor(request => request.TagId)
                .GreaterThan(0).WithMessage(x => localizer["Tag is required!"]);
            RuleFor(request => request.Rate)
                .GreaterThan(0).WithMessage(x => localizer["Rate must be greater than 0"]);
        }
    }
}