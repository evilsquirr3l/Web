using AutoMapper;
using BLL.Models;
using Data.Entities;

namespace Business.Implementation.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Detail, DetailModel>().ReverseMap();

            CreateMap<Category, CategoryModel>().ReverseMap();

            CreateMap<DetailTemplate, DetailTemplateModel>().ReverseMap();

            CreateMap<Production, ProductionModel>().ReverseMap();
        }
    }
}