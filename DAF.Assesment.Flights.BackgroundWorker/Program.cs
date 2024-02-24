using DAF.Assesment.Flights.BackgroundWorker;
using DAF.Assesment.Flights.BackgroundWorker.NotificationService;
using DAF.Assesment.Flights.BackgroundWorker.OpenSkyServices;
using DAF.Assesment.Flights.Infrastructure;
using Microsoft.EntityFrameworkCore;
public class Program
{
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddHttpClient();
                services.AddDbContext<DafAssesmentContext>(options =>
        options.UseSqlServer(context.Configuration.GetConnectionString("DAFAssementDb")));

                services.AddHttpClient<FlightsClient>();
                services.AddSingleton<MailClient>();
                services.AddHostedService<Worker>();
            })
            .Build();

        host.Run();
    }
}
