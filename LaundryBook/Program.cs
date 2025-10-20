using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LaundryLibrary.Repository;
using LaundryLibrary.Service;

namespace LaundryBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            string connectionString = builder.Configuration.GetConnectionString("LaundryDb");

            builder.Services.AddScoped<IMachineRepository>(_ => new MachineRepository(connectionString));
            builder.Services.AddScoped<IBookingRepository>(_ => new BookingRepository(connectionString));
            builder.Services.AddScoped<IResidentRepository>(_ => new ResidentRepository(connectionString));

            builder.Services.AddScoped<MachineService>();
            builder.Services.AddScoped<BookingService>();
            builder.Services.AddScoped<ResidentService>();

            builder.Services.AddRazorPages();
            builder.Services.AddHttpContextAccessor();     
            builder.Services.AddDistributedMemoryCache();  
            builder.Services.AddSession();

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession();      
            app.UseAuthorization();

            app.MapRazorPages();
            app.Run();
        }
    }
}
