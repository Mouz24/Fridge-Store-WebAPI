using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FridgeProducts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<fridge, FridgeDTO>();
            CreateMap<FridgeForAddingDTO, fridge>();
            CreateMap<FridgeForAddingDTO, fridge_model>();
            CreateMap<FridgeForUpdateDTO, fridge>();
            CreateMap<fridge_products, FridgeProductsDTO>();
            CreateMap<ProductsForAddingDTO, fridge_products>();
            CreateMap<ProductsForAddingDTO, products>();
            CreateMap<FridgeProductsDTO, fridge_products>();
            CreateMap<products, ProductsDTO>();
            CreateMap<ProductsForUpdateDTO, products>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<IEnumerable<fridge_products>, FridgeProductsDTO>();
            CreateMap<IEnumerable<fridge>, FridgeDTO>();
            CreateMap<User, UserForAuthenticationDTO>();
        }
    }
}
