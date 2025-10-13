using LaundryLibrary.Repository;
using LaundryLibrary.Service;

namespace LaundryBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IMachineRepository, MachineRepository>();
            builder.Services.AddSingleton<MachineService>();
            builder.Services.AddSingleton<IBookingRepository, BookingRepository>();
            builder.Services.AddSingleton<BookingRepository>();
            builder.Services.AddSingleton<IResidentRepository, ResidentRepository>();
            builder.Services.AddSingleton<ResidentService>();


            // Add services to the container.
            builder.Services.AddRazorPages();
            // Add session services
            builder.Services.AddSession();
            // Add HttpContextAccessor to access session in non-page classes
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            // Enable session before UseAuthorization
            app.UseSession(); 

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
