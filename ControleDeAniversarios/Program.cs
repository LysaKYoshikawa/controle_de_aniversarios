using ControleDeAniversarios.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeAniversarios
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer("Data Source=DESKTOP-CP9SP9G;Initial Catalog=Db_SistemaAniversariante;Integrated Security=True"));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}