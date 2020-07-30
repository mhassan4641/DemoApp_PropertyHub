using EVS370;
using EVS370.PropertyHub;
using EVS370.UsersMgt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVS370
{
    public class PropertyHubContext : DbContext 
    {
        public PropertyHubContext()  
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //this connection string should be read from configuration file
            optionsBuilder.UseSqlServer(@"Data Source=MHASSAN;Initial Catalog=PropertyHub370;" +
                "user id=sa;password=123");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasOne<Province>(c => c.Province)
                .WithMany().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Province>()
                .HasOne<Country>( p => p.Country)
                .WithMany().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>()
                .HasOne<City>(a => a.City)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne<Role>(u => u.Role)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            //1 to 1; must have foreign key on dependent table
            modelBuilder.Entity<User>()
                .HasOne<Address>(u => u.Address)
                .WithOne()
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Neighborhood>()
                .HasOne(a => a.City)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
                .HasOne<PropertyArea>(adv=>adv.Area)
                .WithOne()
                .HasForeignKey<PropertyArea>(adv=>adv.AdvId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<PropertyArea>()
                .HasOne<PropertyAreaUnit>(a => a.PropertyAreaUnit)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
                .HasOne<AdvType>(adv => adv.Type)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropertyAdv>()
               .HasOne<AdvStatus>(adv => adv.Status)
               .WithMany()
               .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<PropertyAdv>()
               .HasOne<User>(adv => adv.PostedBy)
               .WithMany()
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PropertyAdv>()
              .HasMany<AdvImage>(adv => adv.Images)
              .WithOne()
              .OnDelete(DeleteBehavior.Cascade);


        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User>  Users { get; set; }
        public DbSet<AdvType> AdvTypes { get; set; }
        public DbSet<AdvStatus> AdvStatus { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<PropertyAreaUnit> PropertyAreaUnits { get; set; }
        public DbSet<PropertyAdv> PropertyAdvs { get; set; }







    }
}
