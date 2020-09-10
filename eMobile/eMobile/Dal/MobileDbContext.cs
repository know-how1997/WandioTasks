using eMobile.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMobile.Dal
{
    public class MobileDbContext : DbContext
    {
        public MobileDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Mobile> Mobiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mobile>().HasKey(x => x.Id);
        }
    }
}
