using FluentValidation;

namespace HotelManagementProjectfeb.Validators
{
    public class AddReceptionistRequestValidator : AbstractValidator<Model.DTO.AddReceptionistRequest>
    {
        public AddReceptionistRequestValidator()
        {
            RuleFor(x=>x.Receptionist_Name).NotEmpty();

            RuleFor(x=>x.address).NotEmpty();

            RuleFor(x => x.salary).GreaterThanOrEqualTo(15000.90);
        }
    }
}
