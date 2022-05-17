using CinemaPlatform.DAL.EntityConfigurations;
using CinemaPlatform.Domain;
using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaPlatform.DAL

{
    public class CinemaDbContext : DbContext
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
        }
    }
}