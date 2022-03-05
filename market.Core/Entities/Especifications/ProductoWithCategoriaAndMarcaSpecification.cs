namespace market.Core.Entities.Especifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductoWithCategoriaAndMarcaSpecification:BaseEspecifications<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification()
        {
            AddInclude(producto => producto.Categoria);
            AddInclude(producto => producto.Marca);
        }

        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(expresion => expresion.Id == id)
        {
            AddInclude(producto => producto.Categoria);
            AddInclude(producto => producto.Marca);
        }
    }
}
