using kruger.test.luis.pita.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kruger.test.luis.pita.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<VehiculoModel> tbVehiculo { get; set; }
        public DbSet<EventoModel> tbEvento { get; set; }
        public DbSet<CobroModel> tbCobro { get; set; }
        public DbSet<ParametroModel> tbParametro { get; set; }
    }
}
