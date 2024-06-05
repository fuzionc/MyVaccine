using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.NewFolder;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class VaccineCategoryServices : IVaccineCategoryServices
    {

        private readonly IBaseRepository<VaccineCategory> _vaccineCategoryRepository;
        private readonly IMapper _mapper;
        public VaccineCategoryServices(IBaseRepository<VaccineCategory> vaccineCategoryRepository, IMapper mapper)
        {
            _vaccineCategoryRepository = vaccineCategoryRepository;
            _mapper = mapper;
        }
        public async Task<VaccineCategoryResponseDto> Add(VaccineCategoryRequestDto request)
        {
            var vaccineCategory = new VaccineCategory();
            vaccineCategory.Name = request.Name;
            


            await _vaccineCategoryRepository.Add(vaccineCategory);
            var response = _mapper.Map<VaccineCategoryResponseDto>(vaccineCategory);
            return response;
        }

        public async Task<VaccineCategoryResponseDto> Delete(int id)
        {
            var vaccineCategory = await _vaccineCategoryRepository.FindBy(x => x.VaccineCategoryId == id).FirstOrDefaultAsync();

            await _vaccineCategoryRepository.Delete(vaccineCategory);
            var response = _mapper.Map<VaccineCategoryResponseDto>(vaccineCategory);
            return response;
        }

        public async Task<IEnumerable<VaccineCategoryResponseDto>> GetAll()
        {
            var vaccineCategory = await _vaccineCategoryRepository.GetAll().AsNoTracking().ToListAsync();
            var response = _mapper.Map<IEnumerable<VaccineCategoryResponseDto>>(vaccineCategory);
            return response;
        }

        public  async Task<VaccineCategoryResponseDto> GetById(int id)
        {
            var vaccine = await _vaccineCategoryRepository.FindByAsNoTracking(x => x.VaccineCategoryId == id).FirstOrDefaultAsync();
            var response = _mapper.Map<VaccineCategoryResponseDto>(vaccine);
            return response;
        }

        public async  Task<VaccineCategoryResponseDto> Update(VaccineCategoryRequestDto request, int id)
        {
            var vaccineCategory = await _vaccineCategoryRepository.FindBy(x => x.VaccineCategoryId == id).FirstOrDefaultAsync();
            vaccineCategory.Name = request.Name;
            


            await _vaccineCategoryRepository.Update(vaccineCategory);
            var response = _mapper.Map<VaccineCategoryResponseDto>(vaccineCategory);
            return response;
        }
    }
}
