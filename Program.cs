using EmployeeManagement.Data;
using EmployeeManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>
            (
                options => options.UseInMemoryDatabase("EmployeeDb")
            
            );
            
            //adding CORS policy to flag that the API is available for specific locations/domains
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("https://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            
            // add the employee repository to the DI ( dependency injection)
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //add controller config before the build
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            
            
            //add the middleware of swagger for the interactive UI only when we are in the dev env
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseCors("MyCors");
            
            app.MapControllers();
            
            app.Run();
        }
    }
}
