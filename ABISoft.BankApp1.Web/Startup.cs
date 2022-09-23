using ABISoft.BankApp1.Web.Data.Context;
using ABISoft.BankApp1.Web.Data.Interfaces;
using ABISoft.BankApp1.Web.Data.Repositories;
using ABISoft.BankApp1.Web.Data.UnitOfWork;
using ABISoft.BankApp1.Web.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ABISoft.BankApp1.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BankContext>(options => options.UseSqlServer("Data Source=DESKTOP-473BNVL; Initial Catalog=Bank2Db; User id=sa; Password=mssql1234;"));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountMapper, AccountMapper>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
