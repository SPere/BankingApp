using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BankingAppWebAPI.Services;
using BankingAppWebAPI.Services.Clients;
using BankingAppWebAPI.Services.Clients.Interfaces;
using BankingAppWebAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankingAppWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BankingAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("BankingApp"));
            });
            services.AddTransient<IExchangeService, ExchangeService>();
            services.AddTransient<IBalanceService, BalanceService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient(_ => Configuration);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy => policy.AllowAnyMethod().AllowAnyOrigin());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankingAppWebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankingAppWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
