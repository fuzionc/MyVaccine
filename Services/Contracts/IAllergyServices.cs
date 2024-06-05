using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Dependent;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IAllergyServices
    {

        Task<IEnumerable<AllergyResponseDto>> GetAll();
        Task<AllergyResponseDto> GetById(int id);
        Task<AllergyResponseDto> Add(AllergyRequestDto request);
        Task<AllergyResponseDto> Update(AllergyRequestDto request, int id);
        Task<AllergyResponseDto> Delete(int id);
    }
}
