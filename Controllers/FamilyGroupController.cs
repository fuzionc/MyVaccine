using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyGroupController : ControllerBase

    {
        private readonly IFamilyGroupServices _familyGroupServices;
        private readonly IValidator<FamilyGroupRequestDto> _validator;

        public FamilyGroupController(IFamilyGroupServices familyGroupServices, IValidator<FamilyGroupRequestDto> validator)
        {
            _familyGroupServices = familyGroupServices;
            _validator = validator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var family = await _familyGroupServices.GetAll();
            return Ok(family);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var family = await _familyGroupServices.GetById(id);
            return Ok(family);
        }
        [HttpPost]
        public async Task<IActionResult> Create(FamilyGroupRequestDto familyDto)
        {
            var validationResult = await _validator.ValidateAsync(familyDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var family = await _familyGroupServices.Add(familyDto);
            return Ok(family);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var family = await _familyGroupServices.Delete(id);
            if (family == null)
            {
                return NotFound();
            }

            return Ok(family);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FamilyGroupRequestDto familyDto)
        {

            var family = await _familyGroupServices.Update(familyDto, id);
            if (family == null)
            {
                return NotFound();
            }

            return Ok(family);
        }

    }
}
