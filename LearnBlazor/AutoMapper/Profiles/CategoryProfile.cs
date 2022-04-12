using AutoMapper;
using LearnBlazor.AutoMapper.Dtos;
using LearnBlazor.Data;

namespace LearnBlazor.AutoMapper.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
