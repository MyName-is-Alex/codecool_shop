using Codecool.CodecoolShop.DAL;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Codecool.CodecoolShop.Daos.Implementations.Memory;
using Codecool.CodecoolShop.Daos.Implementations.Database;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        public string DbMode { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DbMode = Configuration.GetValue<string>("Mode");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            
            services.AddMvc();
            services.AddSession();
            
            services.AddControllersWithViews();

            if (DbMode == "sql")
            {
                services.AddDbContext<CodecoolShopContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

                services.AddScoped<IProductDao, ProductDaoDatabase>();
                services.AddScoped<IProductCategoryDao, ProductCategoryDaoDatabase>();
                services.AddScoped<ISupplierDao, SupplierDaoDatabase>();
                services.AddScoped<CartDaoDatabase>();
                services.AddScoped<UserDaoDatabase>();
            }
            else if (DbMode == "inMemory")
            {
                services.AddSingleton<IProductDao>(ProductDaoMemory.GetInstance());
                services.AddSingleton<IProductCategoryDao>(ProductCategoryDaoMemory.GetInstance());
                services.AddSingleton<ISupplierDao>(SupplierDaoMemory.GetInstance());
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            if (DbMode == "inMemory") 
                SetupInMemoryDatabases();
            
        }

        private void SetupInMemoryDatabases()
        {

            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            Supplier amazon = new Supplier{ Name = "Amazon", Description = "Digital content and services"};
            supplierDataStore.Add(amazon);

            Supplier emag = new Supplier{ Name = "EMag", Description = "Everything you think of" };
            supplierDataStore.Add(emag);
            Supplier lenovo = new Supplier{Name = "Lenovo", Description = "Computers"};
            supplierDataStore.Add(lenovo);
            
            ProductCategory tablet = new ProductCategory { Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            productCategoryDataStore.Add(tablet);
            ProductCategory phone = new ProductCategory { Name = "Phone", Department = "Hardware", Description = "A phone, commonly shortened to phone, is a thin, flat mobile computer with a touchscreen display." };
            productCategoryDataStore.Add(phone);

            productDataStore.Add(new Product { Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
            productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });
            
        }
    }
}
