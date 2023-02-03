using FluentValidation;

namespace MQApi.Web.Validators
{
    public class UpdateWalkDiffRequestVali:AbstractValidator<Model.DTO.updateWalkDifficultyRequest>
    {
        public UpdateWalkDiffRequestVali()
        {
            RuleFor(x=>x.Code).NotEmpty();  
            
        }
    }
}
