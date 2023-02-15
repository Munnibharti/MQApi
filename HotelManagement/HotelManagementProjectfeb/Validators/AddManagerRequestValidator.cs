using FluentValidation;

namespace HotelManagementProjectfeb.Validators
{
    public class AddManagerRequestValidator : AbstractValidator<Model.DTO.AddManagerRequest>
    {
        public AddManagerRequestValidator()
        {
            RuleFor(x => x.manager_name).NotEmpty();

            RuleFor(x => x.address).NotEmpty();

            RuleFor(x=>x.salary).NotEmpty();
        }
    }
}
