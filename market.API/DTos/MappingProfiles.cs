
namespace market.API.DTos
{
    using AutoMapper;
    using market.Core.Entities;
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Producto, ProductoDto>()
                .ForMember(producto => producto.CategoriaNombre, origen => origen.MapFrom(categoria => categoria.Categoria.Nombre))
                .ForMember(producto => producto.MarcaNombre, origin => origin.MapFrom(marca => marca.Marca.Nombre));
        }
    }
}
