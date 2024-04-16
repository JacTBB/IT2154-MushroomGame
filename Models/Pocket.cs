using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MushroomPocket.Models
{
    public class PocketContext : DbContext
    {
        public DbSet<Character> Pocket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mushroom.db");
        }
    }
}
