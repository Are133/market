namespace market.Core.Entities.Especifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseEspecifications<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification(string sort, int? marca, int? categoria)
            :base(mc => (!marca.HasValue || mc.MarcaId == marca)&&
                        (!categoria.HasValue || mc.CategoriaId == categoria))
        {
            AddInclude(producto => producto.Categoria);
            AddInclude(producto => producto.Marca);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
