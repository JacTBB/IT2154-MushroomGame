using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MushroomPocket.Models
{
    public class PocketContext : DbContext
    {
        public DbSet<Character> Pocket { get; set; }
        public DbSet<Coins> Coins { get; set; }
        public DbSet<Item> Inventory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mushroom.db");
        }
    }
}
