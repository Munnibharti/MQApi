using FluentValidation;

namespace HotelManagementProjectfeb.Validators
{
    public class UpdateManagerRequestValidator : AbstractValidator<Model.DTO.UpdateManagerRequest>
    {
        public UpdateManagerRequestValidator()
        {
            RuleFor(x => x.manager_name).NotEmpty();

            RuleFor(x => x.address).NotEmpty();

            RuleFor(x => x.salary).NotEmpty();
        }
    }
}
