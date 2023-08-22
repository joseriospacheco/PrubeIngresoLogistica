using Microsoft.EntityFrameworkCore;
using PrubeIngresoLogistica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Infrastructure.Data
{
    public class PersistenceContext:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<TipoProducto> TipoProductos { get; set; }

        public DbSet<LugarDestino> LugaresDestinos { get; set; }

        public DbSet<MedioTransporte> MediosTransportes { get; set; }

        public PersistenceContext(DbContextOptions options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
