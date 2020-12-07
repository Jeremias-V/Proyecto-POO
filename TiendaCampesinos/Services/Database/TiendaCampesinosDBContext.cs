using Microsoft.EntityFrameworkCore;
using TiendaCampesinos.Models;

namespace TiendaCampesinos.Services
{
    public class TiendaCampesinosDBContext : DbContext{
        public TiendaCampesinosDBContext(DbContextOptions<TiendaCampesinosDBContext> options) : base(options){}
        public DbSet<ProductoModel> Productos {get; set;}
        // Agregar el resto de productos
    }
}