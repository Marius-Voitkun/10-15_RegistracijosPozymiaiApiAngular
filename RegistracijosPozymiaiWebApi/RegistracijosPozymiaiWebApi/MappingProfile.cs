using AutoMapper;
using RegistracijosPozymiaiWebApi.Dtos;
using RegistracijosPozymiaiWebApi.Models;

namespace RegistracijosPozymiaiWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Feature, FeatureDto>();
            CreateMap<DropDownOption, DropDownOptionDto>();
        }
    }
}
