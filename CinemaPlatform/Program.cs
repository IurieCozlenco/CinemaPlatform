using CinemaPlatform.API.Extensions;
using CinemaPlatform.BLL.Services;
using CinemaPlatform.DAL;
using CinemaPlatform.DAL.Interfaces;
using CinemaPlatform.DAL.Repositories;
using CinemaPlatform.Domain.Auth;
using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaPlatform
{
    public class Program
    {
        public static async Task Main(string[] args)
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

            builder.Services.AddControllers().AddNewtonsoftJson();
            string defaultConnectionString = builder.Configuration.GetConnectionString("CinemaPlatformConnection");
            builder.Services.AddDbContext<CinemaDbContext>(options => options.UseSqlServer(defaultConnectionString))
                .AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<CinemaDbContext>();

            var authOptions = builder.Services.ConfigureAuthOptions(builder.Configuration);
            builder.Services.AddJwtAuthentication(authOptions);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger(builder.Configuration);

            var app = builder.Build();
            await app.SeedData();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync();

        }
    }
}