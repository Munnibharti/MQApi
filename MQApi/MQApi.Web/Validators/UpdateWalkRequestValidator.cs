using FluentValidation;

namespace MQApi.Web.Validators
{
    public class UpdateWalkRequestValidator: AbstractValidator<Model.DTO.UpdateWalkRequest>
    {
        public UpdateWalkRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x=>x.Length).GreaterThan(0);    
            
        }
    }
}
