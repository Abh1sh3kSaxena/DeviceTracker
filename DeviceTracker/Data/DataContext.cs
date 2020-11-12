using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceTracker.Model;
using Microsoft.EntityFrameworkCore;

namespace DeviceTracker.Data
{
    
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>().HasData(
                new Device { Id = 1 , DeviceId = 1 , Data = 1},
                new Device { Id = 2, DeviceId = 1, Data = 2 },
                new Device { Id = 3, DeviceId = 1, Data = 3 },
                new Device { Id = 4, DeviceId = 1, Data = 4 },
                new Device { Id = 5, DeviceId = 1, Data = 5 },
                new Device { Id = 6, DeviceId = 2, Data = 1 }
                );
        }
    }
}
