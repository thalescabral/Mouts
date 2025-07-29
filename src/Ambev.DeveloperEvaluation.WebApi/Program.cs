using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.HealthChecks;
using Ambev.DeveloperEvaluation.Common.Logging;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Middleware;
using Ambev.DeveloperEvaluation.IoC;
using FluentValidation;
using MediatR;
using Serilog;
using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.WebApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        try
        {


            var builder = WebApplication.CreateBuilder(args);
            builder.AddDefaultLogging();


            builder.Services.AddDbContext<Ambev.DeveloperEvaluation.ORM.DefaultContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.RegisterModuleInitializers();
            builder.Services.AddJwtAuthentication(builder.Configuration);

            Console.WriteLine("Configurando serviços...");
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHealthChecks();
            builder.Services.AddSwaggerGen();


            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateSaleHandler).Assembly);
            });
            builder.Services.AddAutoMapper(
                typeof(CreateSaleHandler).Assembly,
                typeof(Program).Assembly
            );


            builder.Services.AddScoped<IValidator<CreateSaleCommand>, CreateSaleValidator>();

            var app = builder.Build();


            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseBasicHealthChecks();
            app.MapControllers();


            await app.RunAsync();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
