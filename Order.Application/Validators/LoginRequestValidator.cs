using FluentValidation;
using Order.Application.Features.User.Login;

namespace Order.Application.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email can`t be empty").WithErrorCode(errorCode: "400")
                .EmailAddress().WithMessage("Write email correctly").WithErrorCode(errorCode: "400");

            RuleFor(x => x.Password)
                .NotEmpty().WithErrorCode(errorCode: "400");
        }
    }
}
