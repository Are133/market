namespace market.Core.Entities.Especifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseEspecifications<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification(ProductoSpecificationParams productoSpecificationParams)
            :base(mc => (!productoSpecificationParams.Marca.HasValue || mc.MarcaId == productoSpecificationParams.Marca)&&
                        (!productoSpecificationParams.Categoria.HasValue || mc.CategoriaId == productoSpecificationParams.Categoria))
        {
            AddInclude(producto => producto.Categoria);
            AddInclude(producto => producto.Marca);

            ApplyPagin(productoSpecificationParams.PageSize * (productoSpecificationParams.PageIndex - 1), productoSpecificationParams.PageSize );

            if (!string.IsNullOrEmpty(productoSpecificationParams.Sort))
            {
                switch (productoSpecificationParams.Sort)
                {
                    case "nombreAsc":
                        AddOrderBy(producto => producto.Nombre);
                        break;

                    case "nombreDesc":
                        AddOrderByDescending(producto => producto.Nombre);
                        break;

                    case "precioAsc":
                        AddOrderBy(producto => producto.Precio);
                        break;

                    case "precioDesc":
                        AddOrderByDescending(producto => producto.Precio);
                        break;

                    case "descripcionAsc":
                        AddOrderBy(producto => producto.Descripcion);
                        break;

                    case "descripcionDesc":
                        AddOrderByDescending(producto => producto.Descripcion);
                        break;

                    default:
                        AddOrderBy(producto => producto.Nombre);
                        break;
                }
            }

        }

        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(expresion => expresion.Id == id)
        {
            AddInclude(producto => producto.Categoria);
            AddInclude(producto => producto.Marca);
        }
    }
}
