using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Services.Contracts;
using MyVaccine.WebApi.Services.Implementations;

namespace MyVaccine.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineRecordController : ControllerBase
    {
        private readonly IVaccineRecordServices _vaccineRecordServices;
        private readonly IValidator<VaccineRecordRequestDto> _validator;

        public VaccineRecordController(IVaccineRecordServices vaccineRecordServices, IValidator<VaccineRecordRequestDto> validator)
        {
            _vaccineRecordServices = vaccineRecordServices;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vaccineRecord = await _vaccineRecordServices.GetAll();
            return Ok(vaccineRecord);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var vaccineRecord = await _vaccineRecordServices.GetById(id);
            return Ok(vaccineRecord);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VaccineRecordRequestDto vaccinRecordDto)
        {
            var validationResult = await _validator.ValidateAsync(vaccinRecordDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var vaccineRecord = await _vaccineRecordServices.Add(vaccinRecordDto);
            return Ok(vaccineRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vaccineRecord = await _vaccineRecordServices.Delete(id);
            if (vaccineRecord == null)
            {
                return NotFound();
            }

            return Ok(vaccineRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VaccineRecordRequestDto vaccinRecordDto)
        {

            var vaccineRecord = await _vaccineRecordServices.Update(vaccinRecordDto, id);
            if (vaccineRecord == null)
            {
                return NotFound();
            }

            return Ok(vaccineRecord);
        }
    }
}
