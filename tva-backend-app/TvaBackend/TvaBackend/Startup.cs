using Application.Interfaces;
using Application.Services;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Validators;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });

            services.AddDbContext<TvaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

            services.AddSwaggerGen();

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PersonValidator>());

            // Add CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Use CORS policy
            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TvaBackend API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}