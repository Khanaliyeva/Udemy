using AutoMapper;
using Udemy.Business.DTOs.CategoryDtos;
using Udemy.Core.Entities;

namespace Udemy.API
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<Category, CategoryUpdateDtos>().ReverseMap();
            CreateMap<Category, CategoryUpdateDtos>();
            CreateMap<Category, CategoryGetDto>().ReverseMap();
            CreateMap<Category, CategoryGetDto>();
        }
           
    }
}
