using FluentValidation;

namespace MQApi.Web.Validators
{
    public class LoginRequestValidator: AbstractValidator<Model.DTO.LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
