using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSCI511_Project_4
{
    public class CSCI511_Proj4_DB : DbContext
    {
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Examine> Examines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veterinarian>()
                .HasKey(vet => new { vet.Vid });
            modelBuilder.Entity<Dog>()
                .HasKey(dog => new { dog.Did });
            modelBuilder.Entity<Examine>()
            .HasKey(e => new { e.Vid, e.Did });
            modelBuilder.Entity<Examine>()
                .HasOne(e => e.Veterinarian)
                .WithMany(v => v.Examines)
                .HasForeignKey(e => e.Vid);
            modelBuilder.Entity<Examine>()
                .HasOne(e => e.Dog)
                .WithMany(d => d.Examines)
                .HasForeignKey(e => e.Did);
        }
            
        public string DbPath { get; private set; }

        public CSCI511_Proj4_DB()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}EF_DB_Folder\\CSCI511_Proj4_DB.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Veterinarian
    {
        public int Vid { get; set; } 
        public string Name { get; set; }

        public List<Examine> Examines { get; } = new List<Examine>();
    }

    public class Dog
    {
        public int Did { get; set; }
        public string DogName { get; set; }
        public int Age { get; set; }

        public List<Examine> Examines { get; } = new List<Examine>();
    }

    public class Examine
    {
        public int Vid { get; set; }
        public int Did { get; set; }
        public int Fee { get; set; }

        public Veterinarian Veterinarian { get; set; }
        public Dog Dog { get; set; }
    }
}
