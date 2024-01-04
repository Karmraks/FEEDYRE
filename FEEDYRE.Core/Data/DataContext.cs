using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FEEDYRE.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FEEDYRE.Core.Data
{
    public class DataContext : DbContext
    {
        private readonly Guid _adminUserId = Guid.NewGuid();
        private readonly Guid _adminRoleId = Guid.NewGuid();
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedUserWithRoles(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedUserWithRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    Id = _adminRoleId,
                    Name = "Admin"
                });

            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sensei"
                });

            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    Id = Guid.NewGuid(),
                    Name = "Trainee"
                });

            modelBuilder.Entity<User>()
                .HasData(new User()
                {
                    Id = _adminUserId,
                    Email = "admin",
                    Password = "admin"
                });

            modelBuilder.Entity<UserRole>()
                .HasData(new UserRole()
                {
                    Id = Guid.NewGuid(),
                    UserId = _adminUserId,
                    RoleId = _adminRoleId
                });
        }
    }
}
