using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MushroomServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MushroomServer.Models
{
    public class DBContext : DbContext
    {
        public DbSet<Result> Results { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=server.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Characters)
                .WithOne(c => c.Player);
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Items)
                .WithOne(i => i.Player);

            base.OnModelCreating(modelBuilder);
        }
    }
}
