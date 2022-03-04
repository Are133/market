namespace market.BusinessLogic.Data
{
    using market.Core.Entities;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class MarketDbContextData
    {
   
        public static async Task CargarDataAsync(MarketDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Marcas.Any())
                {
                    var marcasData = File.ReadAllText(@"C:\Projects\market\market.BusinessLogic\CargarData\marca.json");
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(marcasData);

                    foreach (var marca in marcas)
                    {
                        context.Marcas.Add(marca);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Categorias.Any())
                {
                    var categoriaData = File.ReadAllText(@"C:\Projects\market\market.BusinessLogic\CargarData\categoria.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(categoriaData);

                    foreach (var categoria in categorias)
                    {
                        context.Categorias.Add(categoria);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Productos.Any())
                {
                    var productoData = File.ReadAllText(@"C:/Projects/market/market.BusinessLogic/CargarData/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(productoData);

                    foreach (var product in productos)
                    {
                        context.Productos.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<MarketDbContextData>();
                logger.LogError(ex.Message);
            }
        }
    }
}
