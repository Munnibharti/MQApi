using FluentValidation;

namespace MQApi.Web.Validators
{
    public class AddWalkRequestValidator:AbstractValidator<Model.DTO.AddWalkRequest>
    {
        public AddWalkRequestValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();

           RuleFor(x => x.Length).GreaterThan(0);
        }
    }
}
