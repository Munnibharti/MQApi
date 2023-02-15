using FluentValidation;

namespace HotelManagementProjectfeb.Validators
{
    public class UpdateReceptionistRequestValidator : AbstractValidator<Model.DTO.UpdateReceptionistRequest>
    {
        public UpdateReceptionistRequestValidator()
        {
            RuleFor(x => x.Receptionist_Name).NotEmpty();

            RuleFor(x => x.address).NotEmpty();

            RuleFor(x => x.salary).GreaterThanOrEqualTo(15000.90);
        }
    }
}
