
using AutoMapper;
using Dto = ExternalServices.DTO;
using Domain = DomainTypes.ExternalServiceTypes;

namespace ExternalServices.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dto.Employee, Domain.Employee>();
        }
    }
}