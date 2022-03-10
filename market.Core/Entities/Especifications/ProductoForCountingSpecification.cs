namespace market.Core.Entities.Especifications
{
    public class ProductoForCountingSpecification : BaseEspecifications<Producto>
    {
        public ProductoForCountingSpecification(ProductoSpecificationParams productoParams)
            : base(mc => (!productoParams.Marca.HasValue || mc.MarcaId == productoParams.Marca) &&
                         (!productoParams.Categoria.HasValue || mc.CategoriaId == productoParams.Categoria))
        {

        }
    }
}
