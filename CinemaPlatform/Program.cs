using CinemaPlatform.BLL.Services;
using CinemaPlatform.DAL;
using CinemaPlatform.DAL.Interfaces;
using CinemaPlatform.DAL.Repositories;
using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CinemaPlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Hall
            builder.Services.AddTransient<IGenericRepository<Hall>, GenericRepository<Hall>>();
            builder.Services.AddTransient<HallService>();

            // Film
            builder.Services.AddTransient<IGenericRepository<Film>, GenericRepository<Film>>();
            builder.Services.AddTransient<FilmService>();

            // Session
            builder.Services.AddTransient<IGenericRepository<Session>, GenericRepository<Session>>();
            builder.Services.AddTransient<SessionService>();

            // Ticket
            builder.Services.AddTransient<IGenericRepository<Ticket>, GenericRepository<Ticket>>();
            builder.Services.AddTransient<TicketService>();

            // PlaceStatus
            builder.Services.AddTransient<IGenericRepository<PlaceStatus>, GenericRepository<PlaceStatus>>();

            builder.Services.AddControllers();
            string defaultConnectionString = builder.Configuration.GetConnectionString("CinemaPlatformConnection");
            builder.Services.AddDbContext<CinemaDbContext>(options => options.UseSqlServer(defaultConnectionString));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
           
        }
    }
}