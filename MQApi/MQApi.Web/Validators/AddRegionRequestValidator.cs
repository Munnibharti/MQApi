using FluentValidation;

namespace MQApi.Web.Validators
{
    //we are building this class for validation
    public class AddRegionRequestValidator :AbstractValidator<Model.DTO.AddRegionRequest>
    {
        public AddRegionRequestValidator()
        {
            RuleFor(x=>x.Code).NotEmpty();
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Area).GreaterThan(0);
            RuleFor(x=>x.Population).GreaterThanOrEqualTo(0);

        }
    }
}
