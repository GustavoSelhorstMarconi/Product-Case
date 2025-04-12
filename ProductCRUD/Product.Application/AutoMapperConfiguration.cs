using AutoMapper;
using Product.Application.DTOs;
using Product.Domain.Entities;

namespace Product.Application
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
        }
    }
}
