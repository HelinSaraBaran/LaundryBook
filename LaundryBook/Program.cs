using LaundryLibrary.Repository;
using LaundryLibrary.Service;

namespace LaundryBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

       
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

         
            IMachineRepository machineRepositoryInstance = new MachineRepository(connectionString);
            IBookingRepository bookingRepositoryInstance = new BookingRepository(connectionString);
            IResidentRepository residentRepositoryInstance = new ResidentRepository(connectionString);

     
            builder.Services.AddSingleton<IMachineRepository>(machineRepositoryInstance);
            builder.Services.AddSingleton<IBookingRepository>(bookingRepositoryInstance);
            builder.Services.AddSingleton<IResidentRepository>(residentRepositoryInstance);

      
            builder.Services.AddSingleton<MachineService>();
            builder.Services.AddSingleton<BookingService>();
            builder.Services.AddSingleton<ResidentService>();

  
            builder.Services.AddRazorPages();
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages().WithStaticAssets();

            app.Run();
        }
    }
}
