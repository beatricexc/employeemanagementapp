using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;

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
            
            
            var app = builder.Build();
            app.UseCors("MyCors");
            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }
}
