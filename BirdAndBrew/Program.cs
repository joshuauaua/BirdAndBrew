using System.Text;
using BirdAndBrew.Data;
using BirdAndBrew.Repositories;
using BirdAndBrew.Repositories.CustomerRepositories;
using BirdAndBrew.Repositories.MenuItemRepositories;
using BirdAndBrew.Repositories.ReservationRepositories;
using BirdAndBrew.Repositories.TableRepositories;
using BirdAndBrew.Services.AdminServices;
using BirdAndBrew.Services.BookingAvailabilityServices;
using BirdAndBrew.Services.CustomerServices;
using BirdAndBrew.Services.MenuItemServices;
using BirdAndBrew.Services.ReservationServices;
using BirdAndBrew.Services.TableServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


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
        
        builder.Services.AddControllers();
        
        //Add authentication to allow auth only endpoints
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["AppSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["AppSettings:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Token"]!))
                };
            });

        
        builder.Services.AddAuthorization();
        
        
        //Add scopes of all controllers
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<ICustomerService, CustomerService>();
        
        builder.Services.AddScoped<ITableRepository, TableRepository>();
        builder.Services.AddScoped<ITableService, TableService>();
        
        builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
        builder.Services.AddScoped<IReservationService, ReservationService>();


        builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        builder.Services.AddScoped<IMenuItemService, MenuItemService>();
        
        
        builder.Services.AddScoped<IBookingAvailabilityService, BookingAvailabilityService>();

        builder.Services.AddScoped<IAuthService, AuthService>();
        

        
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

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}