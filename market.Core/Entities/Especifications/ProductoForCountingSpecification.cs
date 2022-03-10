namespace market.Core.Entities.Especifications
{
    using Core.Entities;
    public class ProductoForCountingSpecification : BaseEspecifications<Producto>
    {
        public ProductoForCountingSpecification(ProductoSpecificationParams productoParams)
            : base(mc => (string.IsNullOrEmpty(productoParams.Search) || mc.Nombre.Contains(productoParams.Search)) &&
            (!productoParams.Marca.HasValue || mc.MarcaId == productoParams.Marca) &&
            (!productoParams.Categoria.HasValue || mc.CategoriaId == productoParams.Categoria))
        {

        }
    }
}
