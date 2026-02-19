using ApiEnglish.Application.CommandHandler.Auth;
using ApiEnglish.Domain.Interfaces;
using FluentValidation;

namespace ApiEnglish.Application.Validator
{
    public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly IUserRepository _userRepository;
        public RegisterCommandValidator(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            ClassLevelCascadeMode = CascadeMode.Stop;
            this.AddCommonRules();
        }

        private void AddCommonRules()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100)
                .Matches(@"^[a-zA-ZÀ-ÿ\s'-]+$")
                .WithMessage("Name contains invalid characters.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(254)
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .MustAsync(async (email, cancellation) =>
                    !await _userRepository.EmailExistsAsync(email)
                )
                .WithMessage("The email is already in use.");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .MinimumLength(8)
                .WithMessage("Password must contain a length upper than 8.")
                .Must(p => p.Any(char.IsUpper))
                .WithMessage("Password must contain an uppercase letter.")
                .Must(p => p.Any(char.IsLower))
                .WithMessage("Password must contain an lowercase letter.")
                .Must(p => p.Any(char.IsDigit))
                .WithMessage("Password must contain a number.")
                .Must(p => p.Any(c => !char.IsLetterOrDigit(c)))
                .WithMessage("Password must contain a special character.")
                .Must((command, password) => password == command.ConfirmPassword)
                .WithMessage("Password and Confirm Password must be provided and match.");
        }
    }
}