using White.Auth.Api.Models;
using White.Auth.Core.Entities;

namespace White.Auth.Api.AutoMapper
{
    public class MapperProfile : global::AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<Hero, HeroModel>().ReverseMap();
            CreateMap<Categoria, CategoriaModel>().ReverseMap();
        }
    }
}
