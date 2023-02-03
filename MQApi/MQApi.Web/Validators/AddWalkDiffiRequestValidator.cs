using FluentValidation;

namespace MQApi.Web.Validators
{
    public class AddWalkDiffiRequestValidator:AbstractValidator<Model.DTO.AddDifficultyWalkRequest>
    {
        public AddWalkDiffiRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();

        }
    }
}
