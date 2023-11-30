using Microsoft.OpenApi.Models;
using EDCL.WebAPI.Service.Interfaces;
using EDCL.WebAPI.Service;
using EDCL.WebAPI.Data.Repositories;
using EDCL.WebAPI.Data.Repositories.Interfaces;
using EDCL.WebAPI.Services;
using EDCL.WebAPI.Services.Interfaces;





namespace EDCL.WebAPI
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
            string connectionString = Configuration["DatabaseSettings:DefaultConnection"];

            services.AddTransient<IProductRepository, ProductRepository>(provider => new ProductRepository(connectionString));
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IDriverRepository, DriverRepository>(provider => new DriverRepository(connectionString));
            services.AddTransient<IDriverService, DriverService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EDCL.API", Version = "v1" });
            });

            // Configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EDCL.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }



    }
}
