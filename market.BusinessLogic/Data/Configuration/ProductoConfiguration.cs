
namespace market.BusinessLogic.Data.Configuration
{
    using market.Core.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(producto => producto.Nombre).IsRequired().HasMaxLength(250);
            builder.Property(producto => producto.Descripcion).IsRequired().HasMaxLength(500);
            builder.Property(producto => producto.Imagen).HasMaxLength(1000);
            builder.Property(producto => producto.Precio).HasColumnType("decimal(18,2)");
            builder.HasOne(marca => marca.Marca).WithMany().HasForeignKey(producto => producto.MarcaId);
            builder.HasOne(categoria => categoria.Categoria).WithMany().HasForeignKey(producto => producto.CategoriaId);
            
            




        }
    }
}
