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
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Device> Devices { get; set; }
    }
}
