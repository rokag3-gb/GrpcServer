using GrpcServer;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

//public class Program
//{
//    private static void Main(String[] args)
//    {
//    }
//}


//public static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureWebHostDefaults(webBuilder =>
//        {
//            // Setup a HTTP/2 endpoint without TLS.
//            webBuilder.ConfigureKestrel(options =>
//            {
//                options.ListenLocalhost(5001, o => o.Protocols = HttpProtocols.Http2);
//            });
//            webBuilder.UseStartup<Startup>();
//        });
//}