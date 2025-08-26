using BirdAndBrew.Data;
using BirdAndBrew.Repositories;
using BirdAndBrew.Repositories.CustomerRepositories;
using BirdAndBrew.Repositories.TableRepositories;
using BirdAndBrew.Services.CustomerServices;
using BirdAndBrew.Services.TableServices;
using Microsoft.EntityFrameworkCore;

namespace BirdAndBrew;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        
        builder.Services.AddDbContext<AppDBContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        
        builder.Services.AddScoped<ITableRepository, TableRepository>();
        builder.Services.AddScoped<ITableService, TableService>();
        
        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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