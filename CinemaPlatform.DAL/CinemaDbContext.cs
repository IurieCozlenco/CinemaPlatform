using CinemaPlatform.DAL.Constants;
using CinemaPlatform.DAL.EntityConfigurations;
using CinemaPlatform.Domain;
using CinemaPlatform.Domain.Auth;
using CinemaPlatform.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaPlatform.DAL

{
    public class CinemaDbContext :  IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {

        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
        {
            
        }


        public DbSet<Film>? Films { get; set; } 
        public DbSet<Session>? Sessions { get; set; }
        public DbSet<Hall>? Halls { get; set; }
        public DbSet<Row>? Rows { get; set; }
        public DbSet<Place>? Places { get; set; }
        public DbSet<PlaceStatus>? PlaceStatuses { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(SessionConfig).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            ApplyIdentityMapConfiguration(modelBuilder);
            
        }
        

        private void ApplyIdentityMapConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", SchemaConstants.Auth);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", SchemaConstants.Auth);
            modelBuilder.Entity<UserToken>().ToTable("UserRoles", SchemaConstants.Auth);
            modelBuilder.Entity<Role>().ToTable("Roles", SchemaConstants.Auth);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", SchemaConstants.Auth);
        }
    }
}