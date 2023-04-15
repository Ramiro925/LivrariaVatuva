
using Livraria.Data;
using Livraria.Repositorio;
using Livraria.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Livraria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            _ = builder.Services.AddEntityFrameworkSqlServer()
              .AddDbContext<SistemaTarefasDBContext>(
                  options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
              );

            builder.Services.AddScoped<IAutorRepositorio, AutorRepositorio>();
            builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();

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