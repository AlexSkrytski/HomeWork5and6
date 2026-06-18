
using HomeWork5and6.Domains;
using HomeWork5and6.services;

namespace HomeWork5and6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<DynamicDiscountService>();

            builder.Services.AddSingleton<AccountService>();

            builder.Services.AddScoped<ProductService>();

            builder.Services.AddScoped<DevideService>();

            builder.Services.AddScoped<IDiscountRule>(provider => new PercentageDiscountRule(10));
            builder.Services.AddScoped<IDiscountRule>(provider => new FixedAmountDiscountRule(50));
            builder.Services.AddScoped<DiscountService>();
                       
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
