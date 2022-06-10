using Microsoft.EntityFrameworkCore;
using NHibernate.Mapping;

namespace minnimalAPI.Models
{
    public class KioscoDBContext:DbContext
    {
        public KioscoDBContext(DbContextOptions<KioscoDBContext> options) : base(options)
        {

        }
        public DbSet<Producto> Producto=> Set<Producto>();
        public DbSet<Caracteristicas> Caracteristica=> Set<Caracteristicas>();
    }
}
