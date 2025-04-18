// CQRS/Validators/CreateFeedbackCommandValidator.cs
using FeedbackService.CQRS.Commands;
using FluentValidation;

namespace FeedbackService.CQRS.Validators;

public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
{
    public CreateFeedbackCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Message).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}
