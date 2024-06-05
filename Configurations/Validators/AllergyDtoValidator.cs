using FluentValidation;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Dependent;

namespace MyVaccine.WebApi.Configurations.Validators
{
    public class AllergyDtoValidator : AbstractValidator<AllergyRequestDto>
    {
        public AllergyDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().MaximumLength(255);
            RuleFor(dto => dto.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
