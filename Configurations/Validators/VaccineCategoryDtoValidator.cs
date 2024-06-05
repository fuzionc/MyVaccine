using FluentValidation;
using MyVaccine.WebApi.Dtos.NewFolder;

namespace MyVaccine.WebApi.Configurations.Validators
{
    public class VaccineCategoryDtoValidator : AbstractValidator <VaccineCategoryRequestDto>
    {
        public VaccineCategoryDtoValidator()
        {
            RuleFor(dto => dto.Name).NotEmpty().MaximumLength(255);
        }
    }
}
