using AutoMapper;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Dtos.NewFolder;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations.AutoMapperProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Dependent, DependentRequestDto>().ReverseMap();
            CreateMap<Dependent, DependentResponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DependentId)).ReverseMap();

            CreateMap<Allergy, AllergyRequestDto>().ReverseMap();

            CreateMap<Allergy, AllergyResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AllergyId)).ReverseMap();

            CreateMap<FamilyGroup, FamilyGroupRequestDto>().ReverseMap();

            CreateMap<FamilyGroup, FamilyGroupResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FamilyGroupId)).ReverseMap();

            CreateMap<Vaccine, VaccineRequestDto>().ReverseMap();

            CreateMap<Vaccine, VaccineResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VaccineId)).ReverseMap();

            CreateMap<VaccineCategory, VaccineCategoryRequestDto>().ReverseMap();

            CreateMap<VaccineCategory, VaccineCategoryResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VaccineCategoryId)).ReverseMap();

            CreateMap<VaccineRecord, VaccineRecordRequestDto>().ReverseMap();

            CreateMap<VaccineRecord, VaccineRecordResponseDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VaccineRecordId)).ReverseMap();
        }
    }
}
