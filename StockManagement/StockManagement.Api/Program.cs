using StockManagement.Api;
using Serilog;

public partial class Program {
    private static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

        Log.Information("stockmanagement API starting");

        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
             .WriteTo.Console()
             .ReadFrom.Configuration(context.Configuration));

        builder.Configuration.AddUserSecrets<Program>();


        var app = builder
               .ConfigureServices()
               .ConfigurePipeline();


        await app.ResetDatabaseAsync();

        app.Run();
    }
}

public partial class Program { }