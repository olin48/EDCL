using EDCL.WebAPI;


public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        //host.MigrateDatabase<Program>();
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            //.UseSerilog(SeriLogger.Configure)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}