
using AutoMapper;
using Dto = DAL.Models;
using Domain = DomainTypes.DataStoreTypes;

namespace DAL.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dto.Employee, Domain.Employee>().ReverseMap();
        }
    }
}
