using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineServices _vaccineServices;
        private readonly IValidator<VaccineRequestDto> _validator;

        public VaccineController(IVaccineServices vaccineServices, IValidator<VaccineRequestDto> validator)
        {
            _vaccineServices = vaccineServices;
            _validator = validator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccine = await _vaccineServices.GetAll();
            return Ok(vaccine);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaccine = await _vaccineServices.GetById(id);
            return Ok(vaccine);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VaccineRequestDto vaccinDto)
        {
            var validationResult = await _validator.ValidateAsync(vaccinDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var vaccine = await _vaccineServices.Add(vaccinDto);
            return Ok(vaccine);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vaccine = await _vaccineServices.Delete(id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return Ok(vaccine);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VaccineRequestDto vaccineDto)
        {

            var vaccine = await _vaccineServices.Update(vaccineDto, id);
            if (vaccine == null)
            {
                return NotFound();
            }

            return Ok(vaccine);
        }

    }
}
