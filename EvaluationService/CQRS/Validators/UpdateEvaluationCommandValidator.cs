using FluentValidation;
using EvaluationService.CQRS.Commands;

namespace EvaluationService.CQRS.Validators;

public class UpdateEvaluationCommandValidator : AbstractValidator<UpdateEvaluationCommand>
{
    public UpdateEvaluationCommandValidator()
    {
        RuleFor(x => x.EvaluationId)
            .NotEmpty().WithMessage("El ID de la evaluación es obligatorio.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("El título es obligatorio.")
            .MaximumLength(100).WithMessage("El título no puede superar los 100 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("La descripción es obligatoria.");

        RuleFor(x => x.Score)
            .InclusiveBetween(0, 10).WithMessage("El puntaje debe estar entre 0 y 10.");
    }
}
