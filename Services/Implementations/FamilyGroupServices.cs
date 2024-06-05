using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class FamilyGroupServices : IFamilyGroupServices

    {
        private readonly IBaseRepository<FamilyGroup> _familyRepository;
        private readonly IMapper _mapper;
        public FamilyGroupServices(IBaseRepository<FamilyGroup> familyRepository, IMapper mapper)
        {
            _familyRepository = familyRepository;
            _mapper = mapper;
        }
        public async Task<FamilyGroupResponseDto> Add(FamilyGroupRequestDto request)
        {
            var family = new FamilyGroup();
            family.Name = request.Name;
            

            await _familyRepository.Add(family);
            var response = _mapper.Map<FamilyGroupResponseDto>(family);
            return response;
        }

        public async Task<FamilyGroupResponseDto> Delete(int id)
        {
            var family = await _familyRepository.FindBy(x => x.FamilyGroupId == id).FirstOrDefaultAsync();

            await _familyRepository.Delete(family);
            var response = _mapper.Map<FamilyGroupResponseDto>(family);
            return response;
        }

        public async Task<IEnumerable<FamilyGroupResponseDto>> GetAll()
        {
            var familyGroup = await _familyRepository.GetAll().AsNoTracking().ToListAsync();
            var response = _mapper.Map<IEnumerable<FamilyGroupResponseDto>>(familyGroup);
            return response;
        }

        public async Task<FamilyGroupResponseDto> GetById(int id)
        {
            var family = await _familyRepository.FindByAsNoTracking(x => x.FamilyGroupId == id).FirstOrDefaultAsync();
            var response = _mapper.Map<FamilyGroupResponseDto>(family);
            return response;
        }

        public async Task<FamilyGroupResponseDto> Update(FamilyGroupRequestDto request, int id)
        {
            var family = await _familyRepository.FindBy(x => x.FamilyGroupId == id).FirstOrDefaultAsync();
            family.Name = request.Name;
        

            await _familyRepository.Update(family);
            var response = _mapper.Map<FamilyGroupResponseDto>(family);
            return response;
        }
    }
}
