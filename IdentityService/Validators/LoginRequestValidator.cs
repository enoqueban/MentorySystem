using FluentValidation;
using IdentityService.Controllers;

namespace IdentityService.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El email es obligatorio")
            .EmailAddress().WithMessage("Debe ser un email válido");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("La contraseña es obligatoria")
            .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres");
    }
}
// This validator checks that the email is not empty, is a valid email format, and that the password is not empty and has a minimum length of 6 characters.
// It uses FluentValidation to define the validation rules.
// The LoginRequestValidator class inherits from AbstractValidator<LoginRequest> and defines the validation rules in the constructor.
// The RuleFor method is used to specify the property to validate and the validation rules.
// The WithMessage method is used to specify the error message to return if the validation fails.
// The LoginRequestValidator class can be used in the AuthController to validate the LoginRequest object before processing the login request.
// This ensures that the request is valid before proceeding with the authentication process.
// The LoginRequestValidator class can be registered in the Startup.cs file to enable automatic validation of the LoginRequest object.
// This can be done by adding the following line in the ConfigureServices method:
// services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
// This will automatically register all validators in the assembly containing the LoginRequestValidator class.
