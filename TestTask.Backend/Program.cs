
using Microsoft.EntityFrameworkCore;
using TestTask.Backend.Helpers;
using TestTask.Backend.Models;
using TestTask.Backend.Services;

namespace TestTask.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(TestTaskProfile));

            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TestTaskContext>(options => options.UseSqlServer(connection));

            builder.Services.AddScoped<IDoctorsService, DoctorsService>();
            builder.Services.AddScoped<IPatientsService, PatientsService>();

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
