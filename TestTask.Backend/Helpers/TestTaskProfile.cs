using AutoMapper;
using TestTask.Backend.DTO;
using TestTask.Backend.Models;

namespace TestTask.Backend.Helpers
{
    public class TestTaskProfile : Profile
    {
        public TestTaskProfile() 
        {
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();

            CreateMap<Doctor, DoctorTableView>()
                .ForMember(dest => dest.CabinetNumber, opt => opt.MapFrom(src => src.Cabinet.CabinetNumber))
                .ForMember(dest => dest.AreaName, opt => opt.MapFrom(src => src.Area.AreaName))
                .ForMember(dest => dest.SpecName, opt => opt.MapFrom(src => src.Spec.SpecName));

            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();

            CreateMap<Patient, PatientTableView>()
                .ForMember(dest => dest.AreaName, opt => opt.MapFrom(src => src.Area.AreaName))
                .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex == 1 ? "М" : "Ж"));
        }
    }
}
