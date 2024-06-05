using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.NewFolder;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineCategoryController : ControllerBase
    {

        private readonly IVaccineCategoryServices _vaccineCategoryServices;
        private readonly IValidator<VaccineCategoryRequestDto> _validator;

        public VaccineCategoryController(IVaccineCategoryServices vaccineCategoryServices, IValidator<VaccineCategoryRequestDto> validator)
        {
            _vaccineCategoryServices = vaccineCategoryServices;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccineCategory = await _vaccineCategoryServices.GetAll();
            return Ok(vaccineCategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaccineCategory = await _vaccineCategoryServices.GetById(id);
            return Ok(vaccineCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VaccineCategoryRequestDto vaccinCategoryDto)
        {
            var validationResult = await _validator.ValidateAsync(vaccinCategoryDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var vaccine = await _vaccineCategoryServices.Add(vaccinCategoryDto);
            return Ok(vaccinCategoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vaccineCategory = await _vaccineCategoryServices.Delete(id);
            if (vaccineCategory == null)
            {
                return NotFound();
            }

            return Ok(vaccineCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VaccineCategoryRequestDto vaccineCategoryRequestDto)
        {

            var vaccineCategory = await _vaccineCategoryServices.Update(vaccineCategoryRequestDto, id);
            if (vaccineCategory == null)
            {
                return NotFound();
            }

            return Ok(vaccineCategory);
        }
    }
}
