using FluentValidation;
using PriorityService.CQRS.Commands;

namespace PriorityService.CQRS.Validators;

public class CreatePriorityCommandValidator : AbstractValidator<CreatePriorityCommand>
{
    public CreatePriorityCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("El título es obligatorio");
        RuleFor(x => x.Description).NotEmpty().WithMessage("La descripción es obligatoria");
        RuleFor(x => x.DueDate).GreaterThan(DateTime.Now).WithMessage("La fecha debe ser futura");
    }
}
