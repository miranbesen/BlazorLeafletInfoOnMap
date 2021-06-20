using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLeaflet.Samples.Data
{
    public class EczaneDbContext:DbContext
    {
        #region Contructor
        public EczaneDbContext(DbContextOptions<EczaneDbContext> options)
                : base(options)
        {
        }
        #endregion
        #region Public properties
        public DbSet<Eczane> Eczane { get; set; }
        #endregion
        #region Overidden methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eczane>().HasData(GetEczane());
            base.OnModelCreating(modelBuilder);
        }
        #endregion
        #region Private methods
        private List<Eczane> GetEczane()
        {
            return new List<Eczane>
    {
        new Eczane { Id = 1, Name = "Faruk", Sehir="Mersin",Lat = 36.802468, Long = 34.373726},
        new Eczane { Id = 2, Name = "Cicek", Sehir="Mersin" ,Lat = 36.771617, Long = 34.312612},
        new Eczane { Id = 3, Name = "Gül",Sehir="Ankara", Lat = 39.972332, Long = 32.35655},
        new Eczane { Id = 4, Name = "Yepyeni",Sehir="Çanakkale" ,Lat = 40.096668, Long = 26.33746}
    };
        }
        #endregion
    }
}
