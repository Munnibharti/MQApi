using FluentValidation;
namespace MQApi.Web.Validators
{
    public class UpdateRegionRequestValidator:AbstractValidator<Model.DTO.UpdateRegionRequest>
    {
        public UpdateRegionRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).GreaterThan(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);

        }

       
    }
}
