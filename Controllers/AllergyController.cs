using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IAllergyServices _allergyServices;
        private readonly IValidator<AllergyRequestDto> _validator;

        public AllergyController(IAllergyServices allergyServices, IValidator<AllergyRequestDto> validator)
        {
            _allergyServices = allergyServices;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allergy = await _allergyServices.GetAll();
            return Ok(allergy);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AllergyRequestDto allergyDto)
        {
            var validationResult = await _validator.ValidateAsync(allergyDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var allergy = await _allergyServices.Add(allergyDto);
            return Ok(allergy);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var allergy = await _allergyServices.Delete(id);
            if (allergy == null)
            {
                return NotFound();
            }

            return Ok(allergy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AllergyRequestDto allergyDto)
        {

            var allergy = await _allergyServices.Update(allergyDto, id);
            if (allergy == null)
            {
                return NotFound();
            }

            return Ok(allergy);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var allergy = await _allergyServices.GetById(id);
            return Ok(allergy);
        }
    }
}
