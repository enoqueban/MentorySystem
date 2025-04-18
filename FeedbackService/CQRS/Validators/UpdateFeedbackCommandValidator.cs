// CQRS/Validators/UpdateFeedbackCommandValidator.cs
using FeedbackService.CQRS.Commands;
using FluentValidation;

namespace FeedbackService.CQRS.Validators;

public class UpdateFeedbackCommandValidator : AbstractValidator<UpdateFeedbackCommand>
{
    public UpdateFeedbackCommandValidator()
    {
        RuleFor(x => x.FeedbackId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Message).NotEmpty();
    }
}
