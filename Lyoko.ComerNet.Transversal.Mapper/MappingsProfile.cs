using AutoMapper;
using System;
using Lyoko.ComerNet.Domain.Entity;
using Lyoko.ComerNet.Application.DTO;
namespace Lyoko.ComerNet.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {

        public MappingsProfile()
        {
            //Origen y destino iguales
            CreateMap<Customers, CustomersDTO>().ReverseMap();

            //Origen y destino diferentes
            //CreateMap<Customers, CustomersDTO>().ReverseMap()
            //    .ForMember(destino => destino.CustomerID, source => source.MapFrom(src => src.CustomerID))
            //.ForMember(destino => destino.CompanyName, source => source.MapFrom(src => src.CompanyName))
            //.ForMember(destino => destino.ContactName, source => source.MapFrom(src => src.ContactName))
            //.ForMember(destino => destino.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
            //.ForMember(destino => destino.Address, source => source.MapFrom(src => src.Address))
            //.ForMember(destino => destino.City, source => source.MapFrom(src => src.City))
            //.ForMember(destino => destino.Region, source => source.MapFrom(src => src.Region))
            //.ForMember(destino => destino.PostalCode, source => source.MapFrom(src => src.PostalCode))
            //.ForMember(destino => destino.Country, source => source.MapFrom(src => src.Country))
            //.ForMember(destino => destino.Phone, source => source.MapFrom(src => src.Phone))
            //.ForMember(destino => destino.Fax, source => source.MapFrom(src => src.Fax));




        }
    }   
}
